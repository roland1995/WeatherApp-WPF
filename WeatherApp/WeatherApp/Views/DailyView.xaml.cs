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
    /// Interaction logic for DailyView.xaml
    /// </summary>
    public partial class DailyView : UserControl
    {
        private DailyViewModel DailyViewmodel { get; set; }
        public DailyView()
        {
            InitializeComponent();
            DailyViewmodel = new DailyViewModel();
            DataContext = DailyViewmodel;
        }
    }
}
