using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Windows.Media;
using WeatherApp.Models;
using WeatherApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class WeeklyViewModel : INotifyPropertyChanged
    {
        private static readonly string Path = "https://api.openweathermap.org/data/2.5/onecall?lat=33.44&lon=-94.04&units=metric&exclude=minutely,current,hourly&appid=386e45cb67b5d72af5917dc5b17536cb";
        public IList<string> Days { get; set; }
        public IList<string> MaxTemps { get; set; }
        public IList<string> MinTemps { get; set; }
        private GetWeeklyWeatherData GetWeeklyWeatherData;
        private IList<WeeklyWeatherModel> _weeklyWeatherList;
        public event PropertyChangedEventHandler PropertyChanged;
        private PointCollection _pointsMax = new PointCollection();
        private PointCollection _pointsMin = new PointCollection();
        private short[] dataXCoordinate = new short[] { 0, 100, 200, 300,400,500, 600,700,800 };
        private short[] dataMax1 = new short[] { 400, 330, 301, 315, 312 }; 
        private short[] dataMin1 = new short[] { 400, 350, 340, 345, 350 };
        public IList<WeeklyWeatherModel> WeeklyWeatherList
        {
            get { return _weeklyWeatherList; }
            set { _weeklyWeatherList = value; }
        }
        public WeeklyViewModel()
        {
            Days = new List<string>();
            MaxTemps = new List<string>();
            MinTemps = new List<string>();
            GetWeeklyWeatherData = new GetWeeklyWeatherData(Path);
        }


        public PointCollection PointsMax
        {
            get { return _pointsMax; }
        }

        public PointCollection PointsMin
        {
            get { return _pointsMin; }
        }



        public async Task<IList<string>> Setup()
        {
            FillUpPolyLines();
            WeeklyWeatherList = await GetWeeklyWeatherData.GetFiveDaysWeather();
            FillUpDays();
            FillMinTemps();
            FillUpMaxTemps();
            return Days;       
        }

        private void FillUpDays()
        {
            foreach (var weather in WeeklyWeatherList)
            {
                Days.Add(weather.Date.ToString("dddd"));
            }
           
        }

        private void FillMinTemps()
        {
            foreach (var weather in WeeklyWeatherList)
            {
                MinTemps.Add(weather.Temp["min"]);
            }

        }

        private void FillUpMaxTemps()
        {
            foreach (var weather in WeeklyWeatherList)
            {
                MaxTemps.Add(weather.Temp["max"]);
            }
        }


        private void FillUpPolyLines()
        {
            for (int i = 0; i < dataXCoordinate.Length; i++)
            {
                PointsMax.Add(new Point(dataXCoordinate[i], dataMax1[i]));
                PointsMin.Add(new Point(dataXCoordinate[i], dataMin1[i]));
            }
        }

        

    }
}
