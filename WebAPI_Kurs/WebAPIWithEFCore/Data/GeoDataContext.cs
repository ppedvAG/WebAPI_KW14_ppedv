using Microsoft.EntityFrameworkCore;
using WebAPIWithEFCore.Models;

namespace WebAPIWithEFCore.Data
{
    public class GeoDataContext : DbContext
    {
        public GeoDataContext(DbContextOptions<GeoDataContext> dbContextOptions)
            :base(dbContextOptions)
        { 
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
    }


    //public class CountryDataContext : DbContext
    //{
    //    public CountryDataContext(DbContextOptions<CountryDataContext> dbContextOptions)
    //        : base(dbContextOptions)
    //    {
    //    }
    //    public DbSet<Country> Countries { get; set; }
    //    //public DbSet<City> Citites { get; set; }
    //}
}
