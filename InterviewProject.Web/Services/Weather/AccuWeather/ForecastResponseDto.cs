using InterviewProject.Models;

namespace InterviewProject.Services.Weather.AccuWeather
{
    public class ForecastResponseDto
    {
        public DailyForecast[] DailyForecasts { get; }
        public ForecastResponseDto(DailyForecast[] dailyForecasts)
        {
            DailyForecasts = dailyForecasts;
        }
    }
}