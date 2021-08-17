using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{

    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password should be between {0} abd {1}", MinimumLength = 5)]

        public string Password { set; get; }


    }
    public class UserDTO: LoginUserDTO
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { set; get; }


        public IList<string> Roles { get; set; }



    }
}
