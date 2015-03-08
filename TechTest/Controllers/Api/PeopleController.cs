using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Logic.Interfaces;
using TechTest.Models;

namespace TechTest.Controllers.Api
{
    public class PeopleController : ApiController
    {
        private readonly IPeopleService _personService;

        public PeopleController(IPeopleService personService)
        {
            _personService = personService;
        }

        // GET api/<controller>
        public IEnumerable<Person> Get()
        {
            return _personService.GetPeople().Select(Mapper.Map<Person>);
        }

        // GET api/<controller>/5
        public Person Get(int id)
        {
            return Mapper.Map<Person>(_personService.GetPerson(id));
        }

        // POST api/<controller>
        public void Post([FromBody]Person value)
        {
            _personService.SavePerson(Mapper.Map<Data.Domain.Models.Person>(value));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Person value)
        {
            _personService.SavePerson(Mapper.Map<Data.Domain.Models.Person>(value));
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _personService.DeletePerson(id);
        }
    }
}