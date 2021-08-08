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

    public class HotelController : BaseController
    {
        private readonly ILogger<HotelController> _logger;
        public HotelController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HotelController> logger) : base(unitOfWork, mapper)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();
                var result = _mapper.Map<List<HotelDTO>>(hotels);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong {nameof(GetHotels)}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(x => x.Id == id, new List<string> {"Country"});
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong {nameof(GetHotelById)}");
                return StatusCode(500, "Internal Server Error");
            }

        }
    }
}
