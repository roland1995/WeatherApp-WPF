using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class WeeklyWeatherModel
    {
        [JsonPropertyName("weather")]
        public IList<IDictionary<string, string>> Weather { get; set; }
        public DateTime Date { get; set; }

        [JsonPropertyName("temp")]
        public IDictionary<string, double> Temp { get; set; }

        private int _dt;

        [JsonPropertyName("dt")]
        public int Dt
        {
            get => _dt;

            set
            {
                Date = ToDateTime(value);
                _dt = value;
            }
        }
        public static DateTime ToDateTime(int date)
        {
            long unixTime = Convert.ToInt64(date);
            return new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTime));
        }
        
    }
}
