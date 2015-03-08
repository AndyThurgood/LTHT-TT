using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TechTest.Models
{
    public class Colour
    {
        //public Colour()
        //{
        //    People = new Collection<Person>();
        //}

        public int ColourId { get; set; }

        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        //public ICollection<Person> People { get; set; }
    }
}