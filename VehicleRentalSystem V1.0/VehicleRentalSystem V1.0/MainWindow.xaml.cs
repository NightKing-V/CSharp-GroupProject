using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
           
        }


        private void BookingsBtn_Checked(object sender, RoutedEventArgs e)
        {
            BookingUC.Visibility = Visibility.Visible;
            DetailsUC.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
            VehicleUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
        }

        private void DetailsBtn_Checked(object sender, RoutedEventArgs e)
        {
            DetailsUC.Visibility = Visibility.Visible;
            BookingUC.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
            VehicleUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
          }

        private void VehiclesBtn_Checked(object sender, RoutedEventArgs e)
        {
            VehicleUC.Visibility = Visibility.Visible;
            DetailsUC.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
            BookingUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
        }

        private void DriversBtn_Checked(object sender, RoutedEventArgs e)
        {
            DriversUC.Visibility = Visibility.Visible;
            DetailsUC.Visibility = Visibility.Hidden;
            BookingUC.Visibility = Visibility.Hidden;
            VehicleUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
        }

        private void AdminBtn_Checked(object sender, RoutedEventArgs e)
        {
            AdminUC.Visibility = Visibility.Visible;
            DetailsUC.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
            VehicleUC.Visibility = Visibility.Hidden;
            BookingUC.Visibility = Visibility.Hidden;
        }

        private void DetailsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
