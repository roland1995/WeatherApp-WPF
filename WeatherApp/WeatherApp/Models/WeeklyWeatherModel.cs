using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    class WeeklyWeatherModel
    {
        [JsonPropertyName("weather")]
        public IList<IDictionary<string, string>> Weather { get; set; }

        [JsonPropertyName("dt_txt")]
        public DateTime Date { get; set; }

        [JsonPropertyName("main")]
        public IDictionary<string, string> Main { get; set; }
    }
}
