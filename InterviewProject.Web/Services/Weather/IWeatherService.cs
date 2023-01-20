using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewProject.Models;

namespace InterviewProject.Services.Weather
{
    public interface IWeatherService
    {
        // TODO: Maybe support async streams via IAsyncEnumerable
        // TODO: Support pagination

        Task<IEnumerable<Location>> GetLocationsByPostalCode(string postalCode);

        // TODO: Extend this to support varying forecast lengths (5-day, 10-day, etc)
        Task<IEnumerable<WeatherForecast>> GetLocationForecast(string locationKey);
    }
}