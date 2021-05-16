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
        public IList<string> MaxTemps { get; set; }
        public IList<string> MinTemps { get; set; }
        private WeeklyViewModel _weeklyViewModel;
        public WeeklyView()
        {
            _weeklyViewModel = new WeeklyViewModel();
            InitializeComponent();
            SetUpCanvas();
            DataContext = _weeklyViewModel;
        }

        private async void SetUpCanvas()
        {
            Days = await _weeklyViewModel.Setup();
            MinTemps = _weeklyViewModel.MinTemps;
            MaxTemps = _weeklyViewModel.MaxTemps;
            AddDaysToCanvas();
            AddMaxTempsToCanvas();
            AddMinTempsToCanvas();

        }
        private void AddMaxTempsToCanvas()
        {
            int counter = 0;
            foreach (var temp in MaxTemps)
            {
                TextBlock TB = new TextBlock();
                TB.Text = temp + "°C";
                TB.FontSize = 20;
                TB.Background = Brushes.Red;
                TB.Name = "TextB";
                WeeklyCanvas.Children.Add(TB);
                Canvas.SetLeft(TB, counter);
                Canvas.SetTop(TB, 40);
                counter += 100;
            }
        }
        private void AddMinTempsToCanvas()
        {
            int counter = 0;
            foreach (var temp in MinTemps)
            {
                TextBlock TB = new TextBlock();
                TB.Text = temp + "°C";
                TB.FontSize = 20;
                TB.Background = Brushes.LightBlue;
                TB.Name = "TextB";
                WeeklyCanvas.Children.Add(TB);
                Canvas.SetLeft(TB, counter);
                Canvas.SetTop(TB, 80);
                counter += 100;
            }
        }
        private void AddDaysToCanvas()
        {
            int counter = 0;
            foreach (var day in Days)
            {
                TextBlock TB = new TextBlock();
                TB.Text = day;
                TB.FontSize = 20;
                TB.Background = Brushes.Orange;
                TB.Name = "TextB";
                WeeklyCanvas.Children.Add(TB);
                Canvas.SetLeft(TB, counter);
                counter += 100;
            }
        }
    }
}
