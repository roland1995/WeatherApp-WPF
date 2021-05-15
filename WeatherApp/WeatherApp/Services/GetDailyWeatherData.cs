using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using Newtonsoft.Json.Linq;


namespace WeatherApp.Services
{
    public class GetDailyWeatherData
    {
        public DailyWeatherModel weatherModel { get; set; }

        public async Task<DailyWeatherModel> GetActualWeather()
        {
            string baseURL = $"http://api.openweathermap.org/data/2.5/weather?q=Budapest&units=metric&appid=386e45cb67b5d72af5917dc5b17536cb";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                JObject parent = JObject.Parse(data);
                                weatherModel = parent.ToObject<DailyWeatherModel>();
                                return weatherModel;
                            }
                            else
                            {
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return weatherModel = null;
        }

    }
}