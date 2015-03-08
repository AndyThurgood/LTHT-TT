using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Logic.Interfaces;
using TechTest.Models;

namespace TechTest.Controllers.Api
{
    public class ColourController : ApiController
    {
        private readonly IColourService _colourService;

        public ColourController(IColourService colourService)
        {
            _colourService = colourService;
        }

        // GET api/<controller>
        public IEnumerable<Colour> Get()
        {
            return _colourService.GetColours().Select(Mapper.Map<Colour>);
        }

        // GET api/<controller>/5
        public Colour Get(int id)
        {
            return new Colour();
        }

        // POST api/<controller>
        public void Post([FromBody]Colour value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Colour value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}