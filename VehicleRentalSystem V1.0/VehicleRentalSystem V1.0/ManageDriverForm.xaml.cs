using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                db.conopen();

                using (SqlCommand updatecmd = new SqlCommand("UPDATE Rider SET R_Name = @R_Name, R_LN = @R_LN, R_Email = @R_Email,R_Address=@R_Add,Car=@Car,Bike=@Bike,Van=@Van,ThreeWheel=@ThreeWheel,Bus=@Bus,Lorry=@Lorry WHERE R_NIC = @R_NIC"))
                {
                    updatecmd.Connection = db.GetSqlCon(); // Assign the connection

                    updatecmd.Parameters.AddWithValue("@R_NIC", txtD_NIC.Text);
                    updatecmd.Parameters.AddWithValue("@R_Name", txtD_Name.Text);
                    updatecmd.Parameters.AddWithValue("@R_LN", txtD_lisence.Text);
                    updatecmd.Parameters.AddWithValue("@R_Address", txtD_Name1.Text);
                    updatecmd.Parameters.AddWithValue("@R_Email", txtD_Email.Text);
                    updatecmd.Parameters.AddWithValue("@Car", CarCheckBox.IsChecked);
                    updatecmd.Parameters.AddWithValue("@Van", VanCheckBox.IsChecked);
                    updatecmd.Parameters.AddWithValue("@Bus", BusCheckBox.IsChecked);
                    updatecmd.Parameters.AddWithValue("@Lorry", LorryCheckBox.IsChecked);
                    updatecmd.Parameters.AddWithValue("@Bike", BikeCheckBox.IsChecked);



                    // Add rest of the variables
                    updatecmd.ExecuteNonQuery();


                }

                MessageBox.Show("Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                bool DState = false;
                bool Car = CarCheckBox.IsChecked??false;
                bool bike = BikeCheckBox.IsChecked ?? false;
                bool van = VanCheckBox.IsChecked ?? false;
                bool threewheel = _3wheelCheckBox.IsChecked ?? false;
                bool bus = BusCheckBox.IsChecked ?? false;
                bool lorry = LorryCheckBox.IsChecked ?? false;

                DataBaseFunctions dbFunctions = new DataBaseFunctions();

                dbFunctions.setdata("INSERT INTO Rider (R_NIC, R_LN, R_Name, R_Email, R_Tel, R_Address, Car, Bike, Van, ThreeWheel, Bus, Lorry, R_State) VALUES ('" + DriverNIC + "','" + DriverLicense + "','" + DriverName + "','" + DriverEmail + "','" + DriverPhone + "','" + DriverAdd + "','" + Car + "','" + bike + "','" + van + "','" + threewheel + "','" + bus + "','" + lorry + "','" + DState + "')");

                dbFunctions.conclose();
                MessageBox.Show("Inserted Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnD_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                db.conopen();

                string  R_NIC= txtD_NIC.Text;

                using (SqlCommand deletecmd = new SqlCommand("DELETE FROM Rider WHERE R_NIC = @R_NIC"))
                {
                    deletecmd.Connection = db.GetSqlCon(); // Assign the connection
                    deletecmd.Parameters.AddWithValue("@R_NIC", R_NIC);
                    deletecmd.ExecuteNonQuery();

                    MessageBox.Show("Record deleted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarCheckBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void VanCheckBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void _3wheelCheckBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BusCheckBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void LorryCheckBox1_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
