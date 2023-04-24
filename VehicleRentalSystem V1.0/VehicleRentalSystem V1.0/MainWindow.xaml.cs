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

<<<<<<< HEAD
        private void Bookings_Button_Click(object sender, RoutedEventArgs e)
        {
            BookingUC.Visibility = Visibility.Visible;
            DetailsUC___Search.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
            VehicleUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
        }

        private void Details_Button_Click(object sender, RoutedEventArgs e)
        {
            DetailsUC___Search.Visibility = Visibility.Visible;
            BookingUC.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
            VehicleUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
        }

        private void Vehicles_Button_Click(object sender, RoutedEventArgs e)
        {
            VehicleUC.Visibility = Visibility.Visible;
            DetailsUC___Search.Visibility = Visibility.Hidden;
            BookingUC.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
        }

        private void Vehucles_Button_Click(object sender, RoutedEventArgs e)
        {
            VehicleUC.Visibility = Visibility.Visible;
            DetailsUC___Search.Visibility = Visibility.Hidden;
            BookingUC.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
        }

        private void Drivers_Button_Click(object sender, RoutedEventArgs e)
        {
            DriversUC.Visibility = Visibility.Visible;
            DetailsUC___Search.Visibility = Visibility.Hidden;
            BookingUC.Visibility = Visibility.Hidden;
            VehicleUC.Visibility = Visibility.Hidden;
            AdminUC.Visibility = Visibility.Hidden;
        }

        private void Admin_Button_Click(object sender, RoutedEventArgs e)
        {           
            AdminUC.Visibility = Visibility.Visible;
            VehicleUC.Visibility = Visibility.Hidden;
            DetailsUC___Search.Visibility = Visibility.Hidden;
            BookingUC.Visibility = Visibility.Hidden;
            DriversUC.Visibility = Visibility.Hidden;
        }
        private void Button_Mouse_Right(object sender, MouseButtonEventArgs e)
        {


        }

        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BookingsUC_Loaded(object sender, RoutedEventArgs e)
        {

=======
        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {

>>>>>>> parent of c9cf69a (Linked BookingUC)
        }
    }
}
