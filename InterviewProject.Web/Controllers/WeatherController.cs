using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Models;
using InterviewProject.Services.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewProject.Controllers
{
    // TODO: Add input validation for postal codes
    // TODO: Add resilience with Polly, maybe cache previous responses to use during intermittent external service outages
    // TODO: Communicate useful errors to the frontend

    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("forecast")]
        public async Task<IEnumerable<WeatherForecast>> GetForecast(
            [FromQuery] string locationKey,
            [FromQuery] string postalCode)
        {
            try
            {
                return await _weatherService.GetForecastByKeyOrPostalCode(locationKey, postalCode);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error while trying to get location forecast.");
            }

            return Array.Empty<WeatherForecast>();
        }

        [HttpGet]
        [Route("locations")]
        public async Task<IEnumerable<Location>> GetLocationsByPostalCode([FromQuery] string postalCode)
        {
            try
            {
                return await _weatherService.GetLocationsByPostalCode(postalCode);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error while trying to search locations.");
            }

            return Array.Empty<Location>();
        }
    }
}
