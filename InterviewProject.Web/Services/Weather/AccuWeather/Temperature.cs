namespace InterviewProject.Services.Weather.AccuWeather
{
    public class Temperature
    {
        public int Value { get; }
        public string Unit { get; }

        public Temperature(float value, string unit)
        {
            Value = (int)value;
            Unit = unit;
        }
    }
}