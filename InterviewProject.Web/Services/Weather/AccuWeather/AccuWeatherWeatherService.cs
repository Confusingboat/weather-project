using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using InterviewProject.Models;
using Newtonsoft.Json;

namespace InterviewProject.Services.Weather.AccuWeather
{
    // TODO: Maybe wrap exceptions from remote calls
    public class AccuWeatherWeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public const string BaseUrl = "http://dataservice.accuweather.com";

        private AccuWeatherConfiguration Configuration { get; }

        public AccuWeatherWeatherService(HttpClient httpClient, AccuWeatherConfiguration configuration)
        {
            Configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Location>> GetLocationsByPostalCode(string postalCode)
        {
            const string path = "/locations/v1/postalcodes/search";
            var url = $"{BaseUrl}{path}?apikey={Configuration.ApiKey}&q={HttpUtility.UrlEncode(postalCode)}";
            var response = await _httpClient.GetStringAsync(url);
            return ParseCities(response);
        }

        public async Task<IEnumerable<WeatherForecast>> GetLocationForecast(string locationKey)
        {
            const string path = "/forecasts/v1/daily/5day/";
            var url = $"{BaseUrl}{path}{HttpUtility.UrlEncode(locationKey)}?apikey={Configuration.ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return ParseForecasts(response);
        }

        // TODO: Make this more robust
        internal static IEnumerable<Location> ParseCities(string citiesJson)
        {
            if (string.IsNullOrEmpty(citiesJson)) return Array.Empty<Location>();

            var cities = JsonConvert.DeserializeObject<List<CityResponseDto>>(citiesJson);
            return cities?.Select(city => new Location(city.Key, city.EnglishName)) ?? Array.Empty<Location>();
        }

        // TODO: Make this more robust
        // TODO: Make this more closely mirror the actual result from AccuWeather
        internal static IEnumerable<WeatherForecast> ParseForecasts(string forecastsJson)
        {
            if (string.IsNullOrEmpty(forecastsJson)) return Array.Empty<WeatherForecast>();

            var forecasts = JsonConvert.DeserializeObject<ForecastResponseDto>(forecastsJson);
            return forecasts?.DailyForecasts?.Select(forecast => new WeatherForecast(
                forecast.Date,
                GetDegreesC(forecast.Temperature.Maximum),
                GetDegreesC(forecast.Temperature.Minimum),
                forecast.Day.IconPhrase)) ?? Array.Empty<WeatherForecast>();
        }

        internal static int GetDegreesC(Temperature temperature) =>
            temperature.Unit.Equals("C", StringComparison.OrdinalIgnoreCase)
                ? temperature.Value
                : WeatherConversions.FtoC(temperature.Value);
    }
}