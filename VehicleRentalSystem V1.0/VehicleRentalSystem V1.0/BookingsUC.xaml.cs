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

        private void NewRentBtn_Click(object sender, RoutedEventArgs e)
        {
            RentalForms RF = new RentalForms();
            RF.Show();
        }

        private void NewHireBtn_Click(object sender, RoutedEventArgs e)
        {
            VehicleHireForm HF = new VehicleHireForm();
            HF.Show();
        }

        private void CloseRentBtn_Click(object sender, RoutedEventArgs e)
        {
            EndRentDetail ERD= new EndRentDetail();
            ERD.Show();
        }

        private void CloseHireBtn_Click(object sender, RoutedEventArgs e)
        {
            EndHireDetail EHD= new EndHireDetail();
            EHD.Show();
        }
    }
}
