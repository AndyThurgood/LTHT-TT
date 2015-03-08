using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Models;
using Data.Interfaces;
using Logic.Interfaces;

namespace Logic.Services
{
    public class PeopleService: IPeopleService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Colour> _colourRepository;

        public PeopleService(IRepository<Person> personRepository, IRepository<Colour> colourRepository)
        {
            _personRepository = personRepository;
            _colourRepository = colourRepository;
        }

        public IEnumerable<Person> GetPeople()
        {
            return _personRepository.All().OrderBy(x => x.FirstName);
        }

        public void SavePerson(Person person)
        {
            var existingPerson = _personRepository.Get(person.PersonId);
            existingPerson.IsAuthorised = person.IsAuthorised;
            existingPerson.IsEnabled = person.IsEnabled;
            existingPerson.IsValid = person.IsValid;
            existingPerson.Colours.Clear();

            foreach (var colour in person.Colours)
            {
                existingPerson.Colours.Add(_colourRepository.Get(colour.ColourId));
            }

            _personRepository.Update(existingPerson, person.PersonId);
        }

        public Person GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
