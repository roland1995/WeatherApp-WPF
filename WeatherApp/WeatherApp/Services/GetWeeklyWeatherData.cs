using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class GetWeeklyWeatherData
    {
        private readonly string baseURL;
        public WeeklyWeatherModel weatherModel { get; set; }
        public IList<WeeklyWeatherModel> WeatherModelList { get; set; }


        public GetWeeklyWeatherData(string path)
        {
            baseURL = path;

        }
            public async Task<IList<WeeklyWeatherModel>> GetFiveDaysWeather()
            {
            WeatherModelList = new List<WeeklyWeatherModel>();
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
                                foreach (JProperty property in parent.Properties())
                                {
                                    if (property.Name == "daily")
                                    {
                                        
                                        var myList = property.Value;
                                        foreach(var item in myList)
                                        {
                                           
                                            WeatherModelList.Add(item.ToObject<WeeklyWeatherModel>());
                                   
                                        }
                                        break;
                                    }
                                }

                                //WeatherModelList = myList.ToObject<List<WeeklyWeatherModel>>();
                                Console.WriteLine(WeatherModelList);
                                    return WeatherModelList;
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
    
                return WeatherModelList;
            }
    }
}
