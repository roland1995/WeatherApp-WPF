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
            var Days = await _weeklyViewModel.Setup();
            int counter = 0;
            foreach(var day in Days)
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
            //for (var i = 0; i < 700; i += 150)
            //{
            //    string text = Days[counter];
            //    TextBlock TB = new TextBlock();
            //    TB.Text = text;
            //    TB.FontSize = 20;
            //    TB.Background = Brushes.Orange;
            //    TB.Name = "TextB";
            //    WeeklyCanvas.Children.Add(TB);

            //    Canvas.SetLeft(TB, i);


            //    counter++;
            //}
        }
    }
}
