using CitiesDirectory.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace CitiesDirectory.DataAccess
{
    public class DataInitializer : CreateDatabaseIfNotExists<CityContext>
    {
        protected override void Seed(CityContext context)
        {
            context.Cities.AddRange
            (
                new List<City>
                {
                    new City{ NameSeed="Караганды +7-(7212)"},

                    new City{ NameSeed="Астана +7-(7172"},

                    new City{ NameSeed="Алматы +7-(727)"}
                }
            );
        }
    }
}
