using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using static System.Windows.Forms.AxHost;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for Manage_Employee.xaml
    /// </summary>
    public partial class Manage_Employee : Window
    {
        public Manage_Employee()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              DataBaseFunctions db = new DataBaseFunctions();
              db.setdata("INSERT INTO Employee (E_NIC,E_Name,E_Tel,E_Email,E_Address,Department) VALUES ('" + txtE_NIC.Text + "','" + txtE_Name.Text + "','" + txtE_Telephone.Text + "','" + txtE_Email.Text + "','" + E_address.Text + "','" + department.Text + "')");

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

                MessageBox.Show("Enter the Employee NIC to delete the record");

                string E_NIC = txtE_NIC.Text;

                using (SqlCommand deletecmd = new SqlCommand("DELETE FROM Employee WHERE E_NIC = @E_NIC"))
                {
                    deletecmd.Connection = db.GetSqlCon(); // Assign the connection

                    deletecmd.Parameters.AddWithValue("@E_NIC", E_NIC);

                    deletecmd.ExecuteNonQuery();

                    MessageBox.Show("Record deleted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                db.conopen();

                using (SqlCommand updatecmd = new SqlCommand("UPDATE Employee SET E_Name = @E_Name, E_Tel = @E_Tel, E_Email = @E_Email, Department = @Department,E_Address=@E_Add WHERE E_NIC = @E_NIC"))
                {
                    updatecmd.Connection = db.GetSqlCon(); // Assign the connection

                    updatecmd.Parameters.AddWithValue("@E_NIC", txtE_NIC.Text);
                    updatecmd.Parameters.AddWithValue("@E_Name", txtE_Name.Text);
                    updatecmd.Parameters.AddWithValue("@E_Tel", txtE_Telephone.Text);
                    updatecmd.Parameters.AddWithValue("@Department", department.Text);
                    updatecmd.Parameters.AddWithValue("@E_Address", E_address.Text);
                    updatecmd.Parameters.AddWithValue("@E_Email", txtE_Email.Text);
                    

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
            

}
    }

