using Data.Domain.Context;
using Data.Domain.Models;
using Data.Interfaces;
using Data.Repositories;
using Logic.Interfaces;
using Logic.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TechTest.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TechTest.App_Start.NinjectWebCommon), "Stop")]

namespace TechTest.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DatabaseContext>().ToSelf().InRequestScope();
            kernel.Bind<IRepository<Person>>().To<Repository<Person>>().InRequestScope();
            kernel.Bind<IRepository<Colour>>().To<Repository<Colour>>().InRequestScope();
            kernel.Bind<IPeopleService>().To<PeopleService>().InRequestScope();
            kernel.Bind<IColourService>().To<ColourService>().InRequestScope();
        }        
    }
}
