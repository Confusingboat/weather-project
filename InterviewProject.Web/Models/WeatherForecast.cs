using System;
using InterviewProject.Services.Weather;

namespace InterviewProject.Models
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; }
        public int MaxTemperatureC { get; }
        public int MaxTemperatureF => WeatherConversions.CtoF(MaxTemperatureC);

        public int MinTemperatureC { get; }
        public int MinTemperatureF => WeatherConversions.CtoF(MinTemperatureC);

        public string Summary { get; }

        public WeatherForecast(DateTimeOffset date, int maxTemperatureC, int minTemperatureC, string summary)
        {
            Date = date;
            MaxTemperatureC = maxTemperatureC;
            MinTemperatureC = minTemperatureC;
            Summary = summary;
        }
    }
}