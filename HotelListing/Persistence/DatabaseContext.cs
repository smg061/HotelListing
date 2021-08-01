using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Persistence
{
    public class DatabaseContext : DbContext
    {
        protected DatabaseContext(DbContextOptions options): base(options){}

        public DbSet<Country> Countries { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

    }
}
