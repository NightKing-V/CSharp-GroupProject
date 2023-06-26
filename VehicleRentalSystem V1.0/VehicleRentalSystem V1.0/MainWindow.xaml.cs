using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
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
        public MainWindow(string E_NIC)
        {
            InitializeComponent();

            DirectorySecurity sec = Directory.GetAccessControl(System.IO.Directory.GetCurrentDirectory());
            // Using this instead of the "Everyone" string means we work on non-English systems.
            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            Directory.SetAccessControl(System.IO.Directory.GetCurrentDirectory(), sec);

            string E_Name, Department;
            DataBaseFunctions DBF = new DataBaseFunctions();
            DBF.conopen();

            try
            {
                List<string> emp1 = new List<string>();
                using (SqlCommand cmd = new SqlCommand("SELECT E_Name From Employee WHERE E_NIC = @E_NIC", DBF.GetSqlCon()))
                {
                    cmd.Parameters.AddWithValue("@E_NIC", E_NIC);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emp1.Add(reader[0].ToString());
                        }
                    }

                }
                E_Name = emp1[0];

                List<string> emp2 = new List<string>();
                using (SqlCommand cmd = new SqlCommand("SELECT Department From Employee WHERE E_NIC = @E_NIC", DBF.GetSqlCon()))
                {
                    cmd.Parameters.AddWithValue("@E_NIC", E_NIC);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emp2.Add(reader[0].ToString());
                        }
                    }
                }
                Department = emp2[0];

                EMPName.Content = E_Name;
                EMPID.Content = E_NIC;

                if (Department != "IT")
                {
                    AdminBtn.Visibility = Visibility.Hidden;
                }
                else
                {
                    AdminBtn.Visibility = Visibility.Visible;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void ABT(object sender, MouseButtonEventArgs e)
        {
            About AB = new About();
            AB.Show();
        }
    }
}
