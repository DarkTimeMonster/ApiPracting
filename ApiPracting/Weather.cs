using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiPracting
{
    public class Weather
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("hourly")]
        public HourlyData Hourly { get; set; }
    }

    public class HourlyData
    {
        [JsonProperty("time")]
        public List<string> Time { get; set; }

        [JsonProperty("temperature_2m")]
        public List<double> Temperature { get; set; }

        [JsonProperty("precipitation_probability")]
        public List<int> PrecipitationProbability { get; set; }
    }

    public class HourlyWeatherRow
    {
        public string Time { get; set; }
        public double Temperature { get; set; }
        public int Precipitation { get; set; }
    }
}