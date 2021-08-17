using System;
using HotelListing.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class HotelConfiguration: IEntityTypeConfiguration<Hotel>
    {
        public HotelConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Hotel> builder)
        {

            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandals Resort and Spa",
                    Address = "123 Street Avenue",
                    CountryId = 1,
                    Rating = 4.5


                },

                new Hotel
                {
                    Id = 2,
                    Name = "Chanclas Resort and Spa",
                    Address = "123 Camino Avenida",
                    CountryId = 2,
                    Rating = 3.8

                },

                new Hotel
                {
                    Id = 3,
                    Name = "Huaraches Resort and Spa",
                    Address = "123 Avenida Calles",
                    CountryId = 3,
                    Rating = 4.0

                }
                );


        }
    }
}
