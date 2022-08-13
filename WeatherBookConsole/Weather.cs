using System.Collections.Generic;

namespace WeatherBookConsole
{
    public class Weather
    {
        [ReportItem(1)]
        public string City { get; set; }

        [ReportItem(2)]
        public string Description { get; set; }

        [ReportItem(3, Heading = "Temperature", Units = "°C")]
        public double TemperatureCentrigrade { get; set; }

        [ReportItem(4, Heading = "Rainfall", Units = " Inches", Format = "N2")]
        public double RainfallInches { get; set; }
    }

    public static class WeatherData
    {
        public static IEnumerable<Weather> Weather = new Weather[]
        {
            new Weather() { City = "London", Description = "Sunny spells", TemperatureCentrigrade = 19, RainfallInches = 0 },
            new Weather() { City = "Paris", Description = "Very hot", TemperatureCentrigrade = 27, RainfallInches = 0 },
            new Weather() { City = "New York", Description = "Heavy rain", TemperatureCentrigrade = 8, RainfallInches = 6.598 },
            new Weather() { City = "Munich", Description = "Foggy", TemperatureCentrigrade = 12, RainfallInches = 2.134 },
            new Weather() { City = "Istanbul", Description = "Sunshine and showers", TemperatureCentrigrade = 22, RainfallInches = 8.5 },
            new Weather() { City = "Santiago", Description = "Strong winds", TemperatureCentrigrade = 15, RainfallInches = 0.125 },
        };
    }
}
