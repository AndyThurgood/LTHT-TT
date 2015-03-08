using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TechTest.Models
{
    public class Person
    {
        public Person()
        {
            Colours = new Collection<Colour>();
        }

        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAuthorised { get; set; }

        public bool IsValid { get; set; }

        public bool IsEnabled { get; set; }

        public string FullName
        {
            get { return string.Join(" ", FirstName, LastName); }
        }

        public bool IsPallindrome
        {

            get
            {
                var reversedString = new string(FullName.ToLower().Reverse().ToArray()).Replace(" ", string.Empty);
                var fullName = FullName.ToLower().Replace(" ", string.Empty);
                
                return fullName == reversedString; }
        }

        public ICollection<Colour> Colours { get; set; }
    }
}