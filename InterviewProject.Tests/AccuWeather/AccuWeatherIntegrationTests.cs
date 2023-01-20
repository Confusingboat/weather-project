using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InterviewProject.Services.Weather.AccuWeather;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace InterviewProject.Tests.AccuWeather
{
    public class AccuWeatherIntegrationTests : TestsWithExternalConfiguration
    {
        protected AccuWeatherConfiguration AccuWeatherConfig { get; private set; }

        [SetUp]
        public new void Setup() => AccuWeatherConfig = Configuration.GetAccuWeatherConfiguration();

        [Test]
        public void Should_Pass_If_Configured_ApiKey_Is_Not_Null()
        {
            Assert.That(AccuWeatherConfig, Is.Not.Null);
            Assert.That(AccuWeatherConfig.ApiKey, Is.Not.Empty);
        }

        [Test]
        public async Task Should_Pass_When_City_Is_Found()
        {
            using var httpClient = new HttpClient();
            var sut = new AccuWeatherWeatherService(httpClient, AccuWeatherConfig);

            var cities = (await sut.GetLocationsByPostalCode("55433"))?.ToList();

            Assert.That(cities, Has.One.Items);
            Assert.That(cities?.FirstOrDefault()?.Name, Is.EqualTo("Minneapolis"));
        }

        [Test]
        public async Task Should_Pass_When_Forecast_Is_Retrieved()
        {
            using var httpClient = new HttpClient();
            var sut = new AccuWeatherWeatherService(httpClient, AccuWeatherConfig);

            var forecasts = (await sut.GetLocationForecast("24145_PC"))?.ToList();

            Assert.That(forecasts, Has.Exactly(5).Items);
        }
    }
}