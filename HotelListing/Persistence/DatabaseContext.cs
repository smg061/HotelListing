using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Persistence
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options): base(options){}

        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Mexico",
                    ShortName = "MX"

                },
                new Country
                {
                    Id = 2,
                    Name = "United State",
                    ShortName = "US"

                },
                new Country
                {
                    Id = 3,
                    Name = "Costa Rice",
                    ShortName = "CR"

                }

                );
            builder.Entity<Hotel>()
                .HasData(
                new Hotel
                {
                    Id=1,
                    Name = "Sandals Resort and Spa",
                    Address = "123 Street Avenue",
                    CountryId = 1,
                    Rating = 4.5


                },

                new Hotel
                {
                    Id=2,
                    Name = "Chanclas Resort and Spa",
                    Address = "123 Camino Avenida",
                    CountryId = 2,
                    Rating = 3.8

                },

                new Hotel
                {
                    Id=3,
                    Name = "Huaraches Resort and Spa",
                    Address = "123 Avenida Calles",
                    CountryId = 3,
                    Rating = 4.0

                }
                );

        }


    }
}
