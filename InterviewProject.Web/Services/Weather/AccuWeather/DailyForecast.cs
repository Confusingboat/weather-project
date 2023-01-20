using System;

namespace InterviewProject.Services.Weather.AccuWeather
{
    public class DailyForecast
    {
        public DateTimeOffset Date { get; }
        public Temperatures Temperature { get; }
        public DayPart Day { get; }
        public DayPart Night { get; }

        public DailyForecast(DateTimeOffset date, Temperatures temperature, DayPart day, DayPart night)
        {
            Date = date;
            Temperature = temperature;
            Day = day;
            Night = night;
        }
    }
}