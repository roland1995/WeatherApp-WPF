using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class DailyViewModel : INotifyPropertyChanged
    {
        private GetDailyWeatherData GetActualWeatherData;
        private static string Path = "http://api.openweathermap.org/data/2.5/weather?q=Budapest&units=metric&appid=386e45cb67b5d72af5917dc5b17536cb";
        private DailyWeatherModel _weatherModel;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public IDictionary<string, string> _weather;

        public DailyViewModel()
        {
            WeatherDict = new Dictionary<string, string>();
            GetActualWeatherData = new GetDailyWeatherData(Path);
            Setup();
        }

        public IDictionary<string, string> WeatherDict
        {
            get => _weather;

            set
            {
                _weather = value;
                RaisePropertyChanged(nameof(WeatherDict));
            }
        }

        public DailyWeatherModel WeatherModel
        {
            get => _weatherModel;

            set
            {
                _weatherModel = value;
                RaisePropertyChanged(nameof(WeatherModel));
            }
        }

        private async void Setup()
        {
            WeatherModel = await GetActualWeatherData.GetActualWeather();
            WeatherDict.Add("temperature", WeatherModel.Main["temp"] + "°C");
            WeatherDict.Add("max_temperature", WeatherModel.Main["temp_max"] + "°C");
            WeatherDict.Add("min_temperature", WeatherModel.Main["temp_min"] + "°C");
            WeatherDict.Add("feeling_temp", WeatherModel.Main["feels_like"] + "°C");
            WeatherDict.Add("humidity", WeatherModel.Main["humidity"] + " %");
            WeatherDict.Add("pressure", WeatherModel.Main["pressure"] + " hPa");
        }

        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
