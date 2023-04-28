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
using System.Windows.Shapes;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for ManageDriverForm.xaml
    /// </summary>
    public partial class ManageDriverForm : Window
    {
        public ManageDriverForm()
        {
            InitializeComponent();
        }

        private void btnD_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnD_Insert__Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnD_Delete_Click(object sender, RoutedEventArgs e)
        {
            txtD_Name.Text = "";
            txtD_NIC.Text = "";
            txtD_lisence.Text = "";
            txtD_Email.Text = "";
            DriversPhone.Text = "";
            DriverState.Text = "";
            CarCheckBox.IsChecked = false;
            BikeCheckBox.IsChecked = false;
            VanCheckBox.IsChecked = false;
            _3wheelCheckBox.IsChecked = false;
            BusCheckBox.IsChecked = false;
            LorryCheckBox.IsChecked = false;
        }
    }
}
