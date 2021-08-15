using HotelListing.Configurations.Entities;
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
            // apply the admin configuration


            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());



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

        }


    }
}
