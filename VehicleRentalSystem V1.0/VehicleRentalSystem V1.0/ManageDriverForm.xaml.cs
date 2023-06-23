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
            try
            {
                string DriverName = txtD_Name.Text;
                string DriverNIC = txtD_NIC.Text;
                string DriverLicense = txtD_lisence.Text;
                string DriverEmail = txtD_Email.Text;
                string DriverAdd = txtD_Name1.Text;
                string DriverPhone = DriversPhone.Text;
                string DState = DriverState.Text;
                bool Car = CarCheckBox.IsChecked??false;
                bool bike = BikeCheckBox.IsChecked ?? false;
                bool van = VanCheckBox.IsChecked ?? false;
                bool threewheel = _3wheelCheckBox.IsChecked ?? false;
                bool bus = BusCheckBox.IsChecked ?? false;
                bool lorry = LorryCheckBox.IsChecked ?? false;

                DataBaseFunctions dbFunctions = new DataBaseFunctions();

                dbFunctions.setdata("INSERT INTO Rider (R_NIC, R_LN, R_Name, R_Email, R_Tel, R_Address, Car, Bike, Van, ThreeWheel, Bus, Lorry, R_State) VALUES ('" + DriverNIC + "','" + DriverLicense + "','" + DriverName + "','" + DriverEmail + "','" + DriverPhone + "','" + DriverAdd + "','" + Car + "','" + bike + "','" + van + "','" + threewheel + "','" + bus + "','" + lorry + "','" + DState + "')");


                MessageBox.Show("Inserted Successfully");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
