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
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private readonly double CanvasHeight;
        private readonly double CanvasWidth;
        private short[] dataXCoordinate = new short[] { 30, 130, 230, 330, 430, 530, 630, 730 };
       
        private static readonly string Path = "https://api.openweathermap.org/data/2.5/onecall?lat=33.44&lon=-94.04&units=metric&exclude=minutely,current,hourly&appid=386e45cb67b5d72af5917dc5b17536cb";
        private IList<short> _dataMin;
        public IList<string> _days;
        private IList<short> _dataMax;
        public IList<double> _maxTemps;
        public IList<double> _minTemps;
        private IList<WeeklyWeatherModel> _weeklyWeatherList;
        private GetWeeklyWeatherData GetWeeklyWeatherData;   
        private PointCollection _pointsMax = new PointCollection();
        private PointCollection _pointsMin = new PointCollection();
        
        public IList<double> MinTemps
        {
            get { return _minTemps; }
            set
            {
                _minTemps = value;
                RaisePropertyChanged(nameof(MinTemps));
            }
        }

        public IList<double> MaxTemps
        {
            get { return _maxTemps; }
            set
            {
                _maxTemps = value;
                RaisePropertyChanged(nameof(MaxTemps));
            }
        }
        public IList<string> Days
        {
            get { return _days; }
            set
            {
                _days = value;
                RaisePropertyChanged(nameof(Days));
            }
        }
        private IList<short> DataMax
        {
            get { return _dataMax; }
            set
            {
                _dataMax = value;
                RaisePropertyChanged(nameof(DataMax));
            }
        }
        private IList<short> DataMin
        {
            get { return _dataMin; }
            set
            {
                _dataMin = value;
                RaisePropertyChanged(nameof(DataMin));
            }
        } 
        public IList<WeeklyWeatherModel> WeeklyWeatherList
        {
            get { return _weeklyWeatherList; }
            set { _weeklyWeatherList = value;
                RaisePropertyChanged(nameof(WeeklyWeatherList));
            }
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
            set
            {
                _pointsMax = value;
                RaisePropertyChanged(nameof(PointsMax));
            }
        }

        public PointCollection PointsMin
        {
            get { return _pointsMin; }
            set
            {
                _pointsMin = value;
                RaisePropertyChanged(nameof(PointsMin));
            }
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
                var day = weather.Date.ToString("dddd"); // get the Day in hungarian should refact later!

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
        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
