using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class DailyWeatherModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weather")]
        public IList<IDictionary<string, string>> Weather { get; set; }

        [JsonPropertyName("main")]
        public IDictionary<string, string> Main { get; set; }
    }
}
}
