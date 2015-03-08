using System.Collections.Generic;
using Data.Domain.Models;

namespace Logic.Interfaces
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetPeople();
        void SavePerson(Person person);
        Person GetPerson(int id);
        void DeletePerson(int id);
    }
}
