using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Windows.Media;

namespace WeatherApp.ViewModels
{
    public class WeeklyViewModel
    {
        private static string Path = "http://api.openweathermap.org/data/2.5/forecast?q=Budapest&units=metric&appid=386e45cb67b5d72af5917dc5b17536cb";
        private short[] dataXCoordinate = new short[] { 10, 150, 300, 450, 600 };
        private short[] dataMax1 = new short[] { 400, 330, 301, 315, 312 }; 
        private short[] dataMin = new short[] { 10, 150, 300, 450, 600 };
        private short[] dataMin1 = new short[] { 400, 350, 340, 345, 350 };


    public WeeklyViewModel()
        {
            Setup();
      
        }

        private void Setup()
        {
            FillUpPolyLines();
        }

        private void FillUpPolyLines()
        {
            for (int i = 0; i < dataXCoordinate.Length; i++)
            {
                PointsMax.Add(new Point(dataXCoordinate[i], dataMax1[i]));
                PointsMin.Add(new Point(dataXCoordinate[i], dataMin1[i]));
            }
        }

        private PointCollection _pointsMax = new PointCollection();
        public PointCollection PointsMax
        {
            get { return _pointsMax; }
        }
        private PointCollection _pointsMin = new PointCollection();
        public PointCollection PointsMin
        {
            get { return _pointsMin; }
        }
    }
}
