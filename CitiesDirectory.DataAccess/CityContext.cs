namespace CitiesDirectory.DataAccess
{
    using CitiesDirectory.Models;
    using System.Data.Entity;

    public class CityContext : DbContext
    {
        public CityContext()
            : base("name=CityContext")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }


    }
}