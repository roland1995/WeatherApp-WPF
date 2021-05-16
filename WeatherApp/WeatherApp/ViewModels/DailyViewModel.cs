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
        private static string Path = "http://api.openweathermap.org/data/2.5/weather?q=Budapest&units=metric&appid=386e45cb67b5d72af5917dc5b17536cb";
        private DailyWeatherModel _weatherModel;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
      
        GetDailyWeatherData GetActualWeatherData;
        public DailyViewModel()
        {
            GetActualWeatherData = new GetDailyWeatherData(Path);
            Setup();
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

        public async void Setup()
        {
            WeatherModel = await GetActualWeatherData.GetActualWeather();
            WeatherModel.Main["temp"] += " Celsius";
            WeatherModel.Main["temp_min"] += " Celsius";
            WeatherModel.Main["temp_max"] += " Celsius";
            WeatherModel.Main["feels_like"] += " Celsius";
            WeatherModel.Main["humidity"] += " %";
            WeatherModel.Main["pressure"] += " hPa";
        }


        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
