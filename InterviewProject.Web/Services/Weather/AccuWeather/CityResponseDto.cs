using System.Text.Json.Serialization;

namespace InterviewProject.Services.Weather.AccuWeather
{
    public class CityResponseDto
    {
        public string Key { get; }
        public string EnglishName { get; }


        public CityResponseDto(string key, string englishName)
        {
            Key = key;
            EnglishName = englishName;
        }
    }
}