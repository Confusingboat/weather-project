using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterviewProject.Services.Weather.AccuWeather;
using NUnit.Framework;

namespace InterviewProject.Tests.AccuWeather
{
    public class AccuWeatherUnitTests
    {
        private static class TestData
        {
            // https://elmah.io/tools/multiline-string-converter/

            public const string CitiesJson = @"
[
  {
    ""Version"": 1,
    ""Key"": ""24145_PC"",
    ""Type"": ""PostalCode"",
    ""Rank"": 35,
    ""LocalizedName"": ""Minneapolis"",
    ""EnglishName"": ""Minneapolis"",
    ""PrimaryPostalCode"": ""55443"",
    ""Region"": {
      ""ID"": ""NAM"",
      ""LocalizedName"": ""North America"",
      ""EnglishName"": ""North America""
    },
    ""Country"": {
      ""ID"": ""US"",
      ""LocalizedName"": ""United States"",
      ""EnglishName"": ""United States""
    },
    ""AdministrativeArea"": {
      ""ID"": ""MN"",
      ""LocalizedName"": ""Minnesota"",
      ""EnglishName"": ""Minnesota"",
      ""Level"": 1,
      ""LocalizedType"": ""State"",
      ""EnglishType"": ""State"",
      ""CountryID"": ""US""
    },
    ""TimeZone"": {
      ""Code"": ""CST"",
      ""Name"": ""America/Chicago"",
      ""GmtOffset"": -6,
      ""IsDaylightSaving"": false,
      ""NextOffsetChange"": ""2023-03-12T08:00:00Z""
    },
    ""GeoPosition"": {
      ""Latitude"": 45.11,
      ""Longitude"": -93.345,
      ""Elevation"": {
        ""Metric"": {
          ""Value"": 266,
          ""Unit"": ""m"",
          ""UnitType"": 5
        },
        ""Imperial"": {
          ""Value"": 872,
          ""Unit"": ""ft"",
          ""UnitType"": 0
        }
      }
    },
    ""IsAlias"": false,
    ""ParentCity"": {
      ""Key"": ""348794"",
      ""LocalizedName"": ""Minneapolis"",
      ""EnglishName"": ""Minneapolis""
    },
    ""SupplementalAdminAreas"": [
      {
        ""Level"": 2,
        ""LocalizedName"": ""Hennepin"",
        ""EnglishName"": ""Hennepin""
      }
    ],
    ""DataSets"": [
      ""AirQualityCurrentConditions"",
      ""AirQualityForecasts"",
      ""Alerts"",
      ""DailyAirQualityForecast"",
      ""DailyPollenForecast"",
      ""ForecastConfidence"",
      ""FutureRadar"",
      ""MinuteCast"",
      ""Radar""
    ]
  }
]
";

            public const string ForecastsJson = @"
{
  ""Headline"": {
    ""EffectiveDate"": ""2023-01-19T01:00:00-06:00"",
    ""EffectiveEpochDate"": 1674111600,
    ""Severity"": 2,
    ""Text"": ""Snow continuing through this afternoon with a storm total of 3-6 inches"",
    ""Category"": ""snow"",
    ""EndDate"": ""2023-01-19T19:00:00-06:00"",
    ""EndEpochDate"": 1674176400,
    ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?lang=en-us"",
    ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?lang=en-us""
  },
  ""DailyForecasts"": [
    {
      ""Date"": ""2023-01-19T07:00:00-06:00"",
      ""EpochDate"": 1674133200,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 21,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 34,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 22,
        ""IconPhrase"": ""Snow"",
        ""HasPrecipitation"": true,
        ""PrecipitationType"": ""Snow"",
        ""PrecipitationIntensity"": ""Light""
      },
      ""Night"": {
        ""Icon"": 7,
        ""IconPhrase"": ""Cloudy"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=1&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=1&lang=en-us""
    },
    {
      ""Date"": ""2023-01-20T07:00:00-06:00"",
      ""EpochDate"": 1674219600,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 16,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 26,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Night"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=2&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=2&lang=en-us""
    },
    {
      ""Date"": ""2023-01-21T07:00:00-06:00"",
      ""EpochDate"": 1674306000,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 18,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 28,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 6,
        ""IconPhrase"": ""Mostly cloudy"",
        ""HasPrecipitation"": false
      },
      ""Night"": {
        ""Icon"": 36,
        ""IconPhrase"": ""Intermittent clouds"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=3&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=3&lang=en-us""
    },
    {
      ""Date"": ""2023-01-22T07:00:00-06:00"",
      ""EpochDate"": 1674392400,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 12,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 25,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 6,
        ""IconPhrase"": ""Mostly cloudy"",
        ""HasPrecipitation"": false
      },
      ""Night"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=4&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=4&lang=en-us""
    },
    {
      ""Date"": ""2023-01-23T07:00:00-06:00"",
      ""EpochDate"": 1674478800,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 23,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 30,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Night"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=5&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=5&lang=en-us""
    }
  ]
}
";

            public const string ForecastsJsonFloatTemps = @"
{
  ""Headline"": {
    ""EffectiveDate"": ""2023-01-19T01:00:00-06:00"",
    ""EffectiveEpochDate"": 1674111600,
    ""Severity"": 2,
    ""Text"": ""Snow continuing through this afternoon with a storm total of 3-6 inches"",
    ""Category"": ""snow"",
    ""EndDate"": ""2023-01-19T19:00:00-06:00"",
    ""EndEpochDate"": 1674176400,
    ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?lang=en-us"",
    ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?lang=en-us""
  },
  ""DailyForecasts"": [
    {
      ""Date"": ""2023-01-19T07:00:00-06:00"",
      ""EpochDate"": 1674133200,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 21.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 34.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 22,
        ""IconPhrase"": ""Snow"",
        ""HasPrecipitation"": true,
        ""PrecipitationType"": ""Snow"",
        ""PrecipitationIntensity"": ""Light""
      },
      ""Night"": {
        ""Icon"": 7,
        ""IconPhrase"": ""Cloudy"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=1&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=1&lang=en-us""
    },
    {
      ""Date"": ""2023-01-20T07:00:00-06:00"",
      ""EpochDate"": 1674219600,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 16.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 26.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Night"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=2&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=2&lang=en-us""
    },
    {
      ""Date"": ""2023-01-21T07:00:00-06:00"",
      ""EpochDate"": 1674306000,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 18.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 28.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 6,
        ""IconPhrase"": ""Mostly cloudy"",
        ""HasPrecipitation"": false
      },
      ""Night"": {
        ""Icon"": 36,
        ""IconPhrase"": ""Intermittent clouds"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=3&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=3&lang=en-us""
    },
    {
      ""Date"": ""2023-01-22T07:00:00-06:00"",
      ""EpochDate"": 1674392400,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 12.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 25.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 6,
        ""IconPhrase"": ""Mostly cloudy"",
        ""HasPrecipitation"": false
      },
      ""Night"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=4&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=4&lang=en-us""
    },
    {
      ""Date"": ""2023-01-23T07:00:00-06:00"",
      ""EpochDate"": 1674478800,
      ""Temperature"": {
        ""Minimum"": {
          ""Value"": 23.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        },
        ""Maximum"": {
          ""Value"": 30.0,
          ""Unit"": ""F"",
          ""UnitType"": 18
        }
      },
      ""Day"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Night"": {
        ""Icon"": 8,
        ""IconPhrase"": ""Dreary"",
        ""HasPrecipitation"": false
      },
      ""Sources"": [
        ""AccuWeather""
      ],
      ""MobileLink"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=5&lang=en-us"",
      ""Link"": ""http://www.accuweather.com/en/us/minneapolis-mn/55415/daily-weather-forecast/24145_pc?day=5&lang=en-us""
    }
  ]
}
";
        }

        [TestCase("", ExpectedResult = 0)]
        [TestCase("[]", ExpectedResult = 0)]
        [TestCase(TestData.CitiesJson, ExpectedResult = 1)]
        public int Should_Pass_When_Parsed_Cities_Count_Matches_Expected(string json)
        {
            var cities = AccuWeatherWeatherService.ParseCities(json);
            return cities.Count();
        }

        [TestCase("", ExpectedResult = 0)]
        [TestCase(TestData.ForecastsJson, ExpectedResult = 5)]
        [TestCase(TestData.ForecastsJsonFloatTemps, ExpectedResult = 5)]
        public int Should_Pass_When_Parsed_Forecast_Count_Matches_Expected(string json)
        {
            var forecasts = AccuWeatherWeatherService.ParseForecasts(json);
            return forecasts.Count();
        }
    }
}
