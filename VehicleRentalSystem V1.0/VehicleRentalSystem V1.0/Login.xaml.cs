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
       
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUser.Text;
            string password = txtPass.Password;

            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                using (db.GetSqlCon())
                {
                    db.conopen();

                    string query = "SELECT * FROM Employee WHERE E_UName=@E_UName AND E_Password=@E_Password";
                    SqlCommand command = new SqlCommand(query, db.GetSqlCon());
                    command.Parameters.AddWithValue("@E_Uname", username);
                    command.Parameters.AddWithValue("@E_Password", password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        List<string> ID = new List<string>();
                        while (reader.Read())
                        {
                            ID.Add(reader[0].ToString());
                        }
                        reader.Close();
                        string E_NIC = ID[0];
                        MainWindow main = new MainWindow(E_NIC);

                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }   
    }
}
