using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Mvc;
using TechTest.Models;

namespace TechTest.Controllers {
  public class HomeController : Controller {
    
      public ActionResult Index() 
      {
            return View();
      }
  }
}