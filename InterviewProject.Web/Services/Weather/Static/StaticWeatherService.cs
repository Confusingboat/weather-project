using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Models;

namespace InterviewProject.Services.Weather.Static
{
    public class StaticWeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static Dictionary<string, IEnumerable<WeatherForecast>> Forecasts =
            new Dictionary<string, IEnumerable<WeatherForecast>>
            {
                { "mn", new[]
                {
                    new WeatherForecast(DateTimeOffset.Now, 7, 4, "Cold"),
                    new WeatherForecast(DateTimeOffset.Now.AddDays(1), 7, 5, "Cold"),
                    new WeatherForecast(DateTimeOffset.Now.AddDays(2), 8, 4, "Cold"),
                    new WeatherForecast(DateTimeOffset.Now.AddDays(3), 6, 5, "Cold"),
                    new WeatherForecast(DateTimeOffset.Now.AddDays(4), 7, 4, "Cold"),
                } },
                { "ca", new[]
                {
                    new WeatherForecast(DateTimeOffset.Now, 26, 18, "Balmy"),
                    new WeatherForecast(DateTimeOffset.Now.AddDays(1), 28, 20, "Balmy"),
                    new WeatherForecast(DateTimeOffset.Now.AddDays(2), 30, 21, "Hot"),
                    new WeatherForecast(DateTimeOffset.Now.AddDays(3), 29, 22, "Hot"),
                    new WeatherForecast(DateTimeOffset.Now.AddDays(4), 27, 21, "Balmy"),
                }}
            };

        public Task<IEnumerable<Location>> GetLocationsByPostalCode(string postalCode) =>
            Task.FromResult<IEnumerable<Location>>(
                postalCode switch
                {
                    "55433" => new[] { new Location("mn", "Minnesota") },
                    "90210" => new[] { new Location("ca", "California") },
                    _ => Array.Empty<Location>()
                });

        public Task<IEnumerable<WeatherForecast>> GetLocationForecast(string locationKey) =>
            Task.FromResult(Forecasts.TryGetValue(locationKey, out var forecasts)
                ? forecasts
                : Array.Empty<WeatherForecast>());
    }
}
