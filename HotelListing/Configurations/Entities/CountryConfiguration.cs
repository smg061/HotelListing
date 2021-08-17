using System;
using HotelListing.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class CountryConfiguration: IEntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(

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
