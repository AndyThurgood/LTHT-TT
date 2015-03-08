using TechTest.Models;

namespace TechTest.App_Start
{
    public class MapperConfig
    {
        public static void SetupMappings()
        {
            AutoMapper.Mapper.CreateMap<Data.Domain.Models.Person, Person>();
            AutoMapper.Mapper.CreateMap<Data.Domain.Models.Colour, Colour>();
            AutoMapper.Mapper.CreateMap<Person, Data.Domain.Models.Person>();
            AutoMapper.Mapper.CreateMap<Colour, Data.Domain.Models.Colour>();
        }
    }
}