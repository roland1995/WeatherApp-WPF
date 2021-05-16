using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    class FiveDaysWeatherModel
    {
        [JsonPropertyName("list")]
        public IList<WeeklyWeatherModel> WeeklyWeatherModelList { get; set; }
    }
}
