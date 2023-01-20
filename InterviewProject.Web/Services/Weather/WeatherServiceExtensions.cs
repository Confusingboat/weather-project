using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Models;

namespace InterviewProject.Services.Weather
{
    public static class WeatherServiceExtensions
    {
        // Make this an extension because it's a composition over the existing interface
        // and we don't need to force implementers duplicate the logic
        public static async Task<IEnumerable<WeatherForecast>> GetForecastByKeyOrPostalCode(
            this IWeatherService weatherService,
            string locationKey,
            string postalCode,
            int delayMilliseconds = 300)
        {
            // If we didn't get a location key let's try to find one from the postal code
            if (string.IsNullOrEmpty(locationKey) &&
                !string.IsNullOrWhiteSpace(postalCode))
            {
                var locations = await weatherService.GetLocationsByPostalCode(postalCode);
                locationKey = locations.FirstOrDefault()?.LocationKey;

                // If we get a location, delay a bit to not get rate limited
                if (locationKey != null) await Task.Delay(delayMilliseconds);
            }

            // We don't have a location key for one reason or another so just short circuit
            if (string.IsNullOrEmpty(locationKey)) return Array.Empty<WeatherForecast>();

            return await weatherService.GetLocationForecast(locationKey);
        }
    }
}
