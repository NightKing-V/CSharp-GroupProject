using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Rent_packages.xaml
    /// </summary>
    public partial class Rent_packages : Window
    {
        public Rent_packages()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                db.setdata("INSERT INTO RentPackages (P_ID,P_Name,Duration,Rental,PenaltyRate) VALUES ('" + txtD_PackageID1.Text + "','" + txtD_PackageName1.Text + "','" + txtD_Duration1.Text + "','" + txtD_Rental1.Text + "','" + txtD_PenaltyRate1.Text + "')");

                MessageBox.Show("Inserted Successfully");
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                db.conopen();

              

                string P_ID = txtD_PackageID1.Text;

                using (SqlCommand deletecmd = new SqlCommand("DELETE FROM RentPackages WHERE P_ID = @P_ID"))
                {
                    deletecmd.Connection = db.GetSqlCon(); // Assign the connection

                    deletecmd.Parameters.AddWithValue("@P_ID", P_ID);

                    deletecmd.ExecuteNonQuery();

                    MessageBox.Show("Record deleted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                db.conopen();

                using (SqlCommand updatecmd = new SqlCommand("UPDATE Employee SET P_Name=@P_Name,Duration=@DURA,Rental=@RENT,PenaltyRate=@PR WHERE P_ID = @P_ID"))
                {
                    updatecmd.Connection = db.GetSqlCon(); // Assign the connection

                    updatecmd.Parameters.AddWithValue("@P_ID", txtD_PackageID1.Text);
                    updatecmd.Parameters.AddWithValue("@P_Name", txtD_PackageName1.Text);
                    updatecmd.Parameters.AddWithValue("@DURA", txtD_Duration1.Text);
                    updatecmd.Parameters.AddWithValue("@RENT",txtD_Rental1.Text);
                    updatecmd.Parameters.AddWithValue("@PR", txtD_PenaltyRate1.Text);
                    


                    // Add rest of the variables
                    updatecmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");


                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //DataGridView
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lenovo\Documents\GitHub\CSharp-GroupProject\VehicleRentalSystem V1.0\VehicleRentalSystem V1.0\VehicleRentalDB.mdf"";Integrated Security=True";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM RentPackages", con);
                    DataTable dbv = new DataTable();
                    da.Fill(dbv);
                    RentPackagesTable1.ItemsSource = dbv.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
