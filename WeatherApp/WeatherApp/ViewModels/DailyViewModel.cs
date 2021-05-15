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
        private DailyWeatherModel _weatherModel;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
      
        GetDailyWeatherData GetActualWeatherData;
        public DailyViewModel()
        {
            GetActualWeatherData = new GetDailyWeatherData();
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
