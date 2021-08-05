using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{

    public class CountryController : BaseController
    {
        private readonly ILogger<CountryController> _logger;
        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper) : base(unitOfWork, mapper)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetCountries()
        {
            try
            {

                var countries = await _unitOfWork.Countries.GetAll();
                // map the countries result to a list of Country DTO
                var results = _mapper.Map<List<CountryDTO>>(countries);
                return Ok(results);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetCountryById(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(x => x.Id == id, new List<string> { "Hotels" });
                var result = _mapper.Map<CountryDTO>(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong {nameof(GetCountryById)}");
                return StatusCode(500, "Internal Server Error");
            }


        }
        
    }
}
