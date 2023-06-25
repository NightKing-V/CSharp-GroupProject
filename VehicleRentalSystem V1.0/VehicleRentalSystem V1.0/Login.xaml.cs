using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection( @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lenovo\Documents\GitHub\CSharp-GroupProject\VehicleRentalSystem V1.0\VehicleRentalSystem V1.0\VehicleRentalDB.mdf"";Integrated Security=True");

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUser.Text;
            string password = txtPass.Password;

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lenovo\Documents\GitHub\CSharp-GroupProject\VehicleRentalSystem V1.0\VehicleRentalSystem V1.0\VehicleRentalDB.mdf"";Integrated Security=True"))
                {
                    connection.Open();

                    string query = "SELECT * FROM Employee WHERE E_UName=@E_UName AND E_Password=@E_Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@E_Uname", username);
                    command.Parameters.AddWithValue("@E_Password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

          
           
        }
    }
}
