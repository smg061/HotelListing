using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using HotelListing.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{

    public class AccountController : BaseController
    {
        private readonly UserManager<ApiUser> _userManager; // each of these take the custom user class that is set in ApiUser // suite of functions to manage and retrieve users
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApiUser> userManager,
             ILogger<AccountController> logger) : base(unitOfWork, mapper)
        {
            _userManager = userManager;
            _logger = logger;

        }
        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt from {userDTO.Email}");

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if(!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);

                    }
                    return BadRequest(ModelState);
                    
                }

                return Accepted();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);

            }
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login ([FromBody] LoginUserDTO userDTO)
        //{

        //    _logger.LogInformation($"Login attemp from {userDTO.Email}");

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, isPersistent: false, lockoutOnFailure: false);

        //        if(!result.Succeeded)
        //        {
        //            return BadRequest("Login attempt failed");

        //        }

        //        return Accepted();

        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError(ex, $"Something went wrong in the {nameof(Login)}");
        //        return Problem($"Something went wrong in the {nameof(Login)}", statusCode: 500);
        //    }

        //}


    }
}
