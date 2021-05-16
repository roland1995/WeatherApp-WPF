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
        private WeeklyViewModel WeeklyViewModel;
        public WeeklyView()
        {
            WeeklyViewModel = new WeeklyViewModel();
            InitializeComponent();
            DataContext = WeeklyViewModel;
        }
    }
}
