using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace Geodata.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class LocationController : Controller
    {
        private OpenStreetMapService _openStreetMapService;
        private DadataService _dadataService;

        public LocationController(OpenStreetMapService openStreetMapService, DadataService dadataService)
        {
            _openStreetMapService = openStreetMapService;
            _dadataService = dadataService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetGeoDataByAddress([FromQuery] AddressModel address)  
        {
            try
            {
                return Ok(await _openStreetMapService.GetPositionByAddress(address));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAddressesByGeoPosition([FromQuery] PositionModel position)
        {
            try
            {
                 return Ok(await _dadataService.GetAddressByPosition(position));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
