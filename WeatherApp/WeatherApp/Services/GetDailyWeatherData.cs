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
        private readonly string baseURL;
        public DailyWeatherModel weatherModel { get; set; }

        public GetDailyWeatherData(string path)
        {
            baseURL = path;
        }
        public async Task<DailyWeatherModel> GetActualWeather()
        {
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