using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Configurations.Entities
{
    public class RoleConfiguration: IEntityTypeConfiguration<IdentityRole>
    {
        public RoleConfiguration()
        {
        }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(

                new IdentityRole
                {
                    Name="User",
                    NormalizedName="USER",
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                }


                );
        }

        
    }
}
