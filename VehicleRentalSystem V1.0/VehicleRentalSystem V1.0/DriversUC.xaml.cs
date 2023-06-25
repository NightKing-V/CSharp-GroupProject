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
    /// Interaction logic for DriversUC.xaml
    /// </summary>
    public partial class DriversUC : UserControl
    {
        public DriversUC()
        {
            InitializeComponent();
        }

        private void DriverMBtn_Click(object sender, RoutedEventArgs e)
        {
            ManageDriverForm manageDriverForm = new ManageDriverForm();
            manageDriverForm.Show();
        }

        private void DriverInSrvcBtn_Click(object sender, RoutedEventArgs e)
        {
            DriversInServiceTable driversInServiceTable = new DriversInServiceTable();
            driversInServiceTable.Show();
        }

        private void DriverAvBtn_Click(object sender, RoutedEventArgs e)
        {
            DriversAvailableTable driversAvailable = new DriversAvailableTable();
            driversAvailable.Show();

        }
    }
}
