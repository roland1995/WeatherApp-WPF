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

        public ISet<string> Days { get; set; } = new HashSet<string>();

        private GetWeeklyWeatherData GetWeeklyWeatherData;
        private IList<WeeklyWeatherModel> _weeklyWeatherList;
        public event PropertyChangedEventHandler PropertyChanged;
        private PointCollection _pointsMax = new PointCollection();
        private PointCollection _pointsMin = new PointCollection();
        private short[] dataXCoordinate = new short[] { 10, 150, 300, 450, 600 };
        private short[] dataMax1 = new short[] { 400, 330, 301, 315, 312 }; 
        private short[] dataMin1 = new short[] { 400, 350, 340, 345, 350 };
        public IList<WeeklyWeatherModel> WeeklyWeatherList
        {
            get { return _weeklyWeatherList; }
            set { _weeklyWeatherList = value; }
        }


        public PointCollection PointsMax
        {
            get { return _pointsMax; }
        }

        public PointCollection PointsMin
        {
            get { return _pointsMin; }
        }

        public WeeklyViewModel()
        {
            GetWeeklyWeatherData = new GetWeeklyWeatherData(Path);
        }

        public async Task<ISet<string>> Setup()
        {
            FillUpPolyLines();
            var List = await GetWeeklyWeatherData.GetFiveDaysWeather();
            FillUpDays();
            return Days;       
        }

        private void FillUpDays()
        {
            //foreach (var weather in FiveDaysWeatherModel.DailyList)
            //{
            //    Days.Add(weather.Date.ToString("dddd"));
            //}
            //DateTime dateValue = new DateTime(2008, 6, 11);
            //Console.WriteLine(dateValue.ToString("dddd"));


            //Days.Add("hétfő");
            //Days.Add("kedd");
            //Days.Add("szerda");
            //Days.Add("csütörtök");
            //Days.Add("péntek");
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
