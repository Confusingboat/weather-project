namespace InterviewProject.Services.Weather.AccuWeather
{
    public class Temperatures
    {
        public Temperature Minimum { get; }
        public Temperature Maximum { get; }

        public Temperatures(Temperature minimum, Temperature maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}