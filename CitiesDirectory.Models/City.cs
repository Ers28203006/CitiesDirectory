using System.Collections.Generic;

namespace CitiesDirectory.Models
{
    public class City
    {
        public int Id { get; set; }

        public string NameSeed { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public City()
        {
            People = new List<Person>();
        }
    }
}
