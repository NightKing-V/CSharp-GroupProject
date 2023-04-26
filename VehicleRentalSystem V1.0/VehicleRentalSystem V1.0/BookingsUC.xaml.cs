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
    /// Interaction logic for BookingsUC.xaml
    /// </summary>
    public partial class BookingsUC : UserControl
    {
        public BookingsUC()
        {
            InitializeComponent();
        }

        private void RentBtn_Click(object sender, RoutedEventArgs e)
        {
            RentalForms rentalForms= new RentalForms();
            rentalForms.Show();
            
            
            
            
        }

        private void HireBtn_Click(object sender, RoutedEventArgs e)
        {
            VehicleHireForm vehicleHireForm= new VehicleHireForm();
            vehicleHireForm.Show();
        }
    }
}
