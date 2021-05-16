using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using WeatherApp.Models;
using WeatherApp.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq;


namespace WeatherApp.ViewModels
{
    public class WeeklyViewModel : INotifyPropertyChanged
    {
        private readonly double CanvasHeight;
        private readonly double CanvasWidth;
        private static readonly string Path = "https://api.openweathermap.org/data/2.5/onecall?lat=33.44&lon=-94.04&units=metric&exclude=minutely,current,hourly&appid=386e45cb67b5d72af5917dc5b17536cb";
        public IList<string> Days { get; set; }
        public IList<double> MaxTemps { get; set; }
        public IList<double> MinTemps { get; set; }
        private GetWeeklyWeatherData GetWeeklyWeatherData;
        private IList<WeeklyWeatherModel> _weeklyWeatherList;
        public event PropertyChangedEventHandler PropertyChanged;
        private PointCollection _pointsMax = new PointCollection();
        private PointCollection _pointsMin = new PointCollection();
        private short[] dataXCoordinate = new short[] { 20, 120, 220, 320,420,520, 620,720 };
        private IList<short> DataMax { get; set; } 
        private IList<short> DataMin { get; set; } 
        public IList<WeeklyWeatherModel> WeeklyWeatherList
        {
            get { return _weeklyWeatherList; }
            set { _weeklyWeatherList = value; }
        }
        public WeeklyViewModel(double height, double width)
        {
            DataMax = new List<short>();
            DataMin = new List<short>();
            CanvasHeight = height;
            CanvasWidth = width;
            Days = new List<string>();
            MaxTemps = new List<double>();
            MinTemps = new List<double>();
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
            WeeklyWeatherList = await GetWeeklyWeatherData.GetFiveDaysWeather();
            FillUpDays();
            FillMinTemps();
            FillUpMaxTemps();
            FillUpDataMax();
            FillUpDataMin();
            FillUpPolyLines();
            return Days;       
        }

        private void FillUpDataMax()
        {
            foreach (var temp in MaxTemps)
            {
                DataMax.Add(Convert.ToInt16(CanvasHeight-(6*temp)));
            }                   
        }

        private void FillUpDataMin()
        {
            foreach (var temp in MinTemps)
            {
                DataMin.Add(Convert.ToInt16(CanvasHeight - (6 * temp)));
            }
        }

        private void FillUpDays()
        {
            foreach (var weather in WeeklyWeatherList)
            {
                var day = weather.Date.ToString("dddd");

                switch (day)
                {
                    case "hétfő":
                        Days.Add("Monday");
                        break;
                    case "kedd":
                        Days.Add("Tuesday");
                        break;
                    case "szerda":
                        Days.Add("Wednesday");
                        break;
                    case "csütörtök":
                        Days.Add("Thursday");
                        break;
                    case "péntek":
                        Days.Add("Friday");
                        break;
                    case "szombat":
                        Days.Add("Saturday");
                        break;
                    case "vasárnap":
                        Days.Add("Sunday");
                        break;
                    default:
                        Days.Add(weather.Date.ToString("dddd"));
                        break;
                }
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
                PointsMax.Add(new Point(dataXCoordinate[i], DataMax[i]));
                PointsMin.Add(new Point(dataXCoordinate[i], DataMin[i]));
            }
        }

    }
}
