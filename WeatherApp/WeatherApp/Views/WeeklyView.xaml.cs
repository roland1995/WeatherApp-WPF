using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.ViewModels;

namespace WeatherApp.Views
{
    /// <summary>
    /// Interaction logic for WeeklyView.xaml
    /// </summary>
    public partial class WeeklyView : UserControl
    {
        public IList<string> Days { get; set; }
        public IList<double> MaxTemps { get; set; }
        public IList<double> MinTemps { get; set; }
        private WeeklyViewModel _weeklyViewModel;
        public WeeklyView()
        {
            
            InitializeComponent();
            _weeklyViewModel = new WeeklyViewModel(WeeklyCanvas.Height, WeeklyCanvas.Width);
            SetUpCanvas();
           
        }

        private async void SetUpCanvas()
        {
            Days = await _weeklyViewModel.Setup();
            MinTemps = _weeklyViewModel.MinTemps;
            MaxTemps = _weeklyViewModel.MaxTemps;
            AddDaysToCanvas();
            AddMaxTempsToCanvas();
            AddMinTempsToCanvas();
            DataContext = _weeklyViewModel;
        }
        private void AddMaxTempsToCanvas()
        {
            int counter = 0;
            foreach (var temp in MaxTemps)
            {
                CreateTextBlock(temp + "°C",20, Brushes.Red,counter,40);
                counter += 100;
            }
        }
        private void AddMinTempsToCanvas()
        {
            int counter = 0;
            foreach (var temp in MinTemps)
            {
                CreateTextBlock(temp + "°C", 20, Brushes.LightBlue, counter, 80);
                counter += 100;
            }
        }
        private void AddDaysToCanvas()
        {
            int counter = 0;
            foreach (var day in Days)
            {
                CreateTextBlock(day, 18, Brushes.Orange, counter, 0);
                counter += 100;
            }
        }
        private void CreateTextBlock(string text, int fontSize,Brush color,int xCoordinate,int yCoordinate)
        {
            TextBlock TB = new TextBlock();
            TB.Text = text;
            TB.FontSize = fontSize;
            TB.Background = color;
            TB.Name = "TextB";
            WeeklyCanvas.Children.Add(TB);
            Canvas.SetLeft(TB, xCoordinate);
            Canvas.SetTop(TB, yCoordinate);
        }


    }
}
