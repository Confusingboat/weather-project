using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewProject.Services.Weather.AccuWeather
{
    // Maybe move this to the well-known namespace
    public static class ConfigurationExtensions
    {
        public static IConfiguration GetAccuWeatherSection(this IConfiguration configuration) =>
            configuration.GetSection("AccuWeather");

        public static AccuWeatherConfiguration GetAccuWeatherConfiguration(
            this IConfiguration configuration) =>
            configuration.GetAccuWeatherSection().Get<AccuWeatherConfiguration>();

        public static IServiceCollection AddAccuWeatherConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            services
                .Configure<AccuWeatherConfiguration>(configuration.GetAccuWeatherSection())
                .AddSingleton(sp => sp.GetRequiredService<IConfiguration>().GetAccuWeatherConfiguration());
    }
}
