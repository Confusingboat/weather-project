using NUnit.Framework;

namespace InterviewProject.Tests.WeatherConversions
{
    public class WeatherConversionsUnitTests
    {
        [TestCase(0, ExpectedResult = 32)]
        [TestCase(25, ExpectedResult = 76)]
        [TestCase(100, ExpectedResult = 211)]
        public int Convert_Celsius_To_Fahrenheit(int degreesC) =>
            Services.Weather.WeatherConversions.CtoF(degreesC);

        [TestCase(32, ExpectedResult = 0)]
        [TestCase(77, ExpectedResult = 25)]
        [TestCase(212, ExpectedResult = 100)]
        public int Convert_Fahrenheit_To_Celsius(int degreesF) =>
            Services.Weather.WeatherConversions.FtoC(degreesF);
    }
}