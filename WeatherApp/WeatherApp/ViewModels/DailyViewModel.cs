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
            Console.WriteLine(WeatherModel);
            Console.WriteLine(WeatherModel);
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

        }


        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
