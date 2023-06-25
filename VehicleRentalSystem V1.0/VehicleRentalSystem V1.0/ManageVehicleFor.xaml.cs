using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections;
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
using System.Xml.Linq;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for ManageVehicleFor.xaml
    /// </summary>
    public partial class ManageVehicleFor : Window

    {
        DataBaseFunctions con;
        public ManageVehicleFor()
        {
            InitializeComponent();
        }
       

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                db.conopen();

                MessageBox.Show("Enter the Chassis Number to delete the record");

                string V_CN = txtV_ChassisNo.Text;

                using (SqlCommand deletecmd = new SqlCommand("DELETE FROM Vehicle WHERE V_CN = @V_CN"))
                {
                    deletecmd.Connection = db.GetSqlCon(); // Assign the connection

                    deletecmd.Parameters.AddWithValue("@V_CN", V_CN);

                    deletecmd.ExecuteNonQuery();

                    MessageBox.Show("Record deleted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnInsert__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string V_PN = txtV_No.Text;
                string V_CN = txtV_ChassisNo.Text;
                //vehicle plate number not included include it
                string V_Brand = txtV_Brand.Text;
                string V_Model = txtV_Model.Text;
                string V_State = Vehicle_Condition.Text;
                string V_Passengers = No_of_Passengers.Text;
                string V_Type = String.Empty;
                if (CarCheckBox.IsChecked ?? true)
                {
                    V_Type = "Car";
                }

                else if (BikeCheckBox.IsChecked ?? true)
                {
                    V_Type = "Bike";
                }

                else if (VanCheckBox.IsChecked ?? true)
                {
                    V_Type = "Van";
                }

                else if (BusCheckBox.IsChecked ?? true)
                {
                    V_Type = "Bus";
                }

                else if (LorryCheckBox.IsChecked ?? true)
                {
                    V_Type = "Lorry";
                }

                else if (_3wheelCheckBox.IsChecked ?? true)
                {
                    V_Type = "ThreeWheel";
                }

               
              

                DataBaseFunctions dbFunctions = new DataBaseFunctions();
                dbFunctions.setdata("INSERT INTO Vehicle (V_CN,V_Brand,V_Model,V_Passengers,V_Condition,V_Type) VALUES ('" + V_CN + "','" + V_Brand + "','" + V_Model + "','" + V_Passengers + "','" + V_State + "','" + V_Type + "')");


                MessageBox.Show("Inserted Successfully");         
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

                MessageBox.Show("Enter the Chassis Number and Update details");

                string V_PN = txtV_No.Text;
                string V_CN = txtV_ChassisNo.Text;
                //vehicle plate number not included include it
                string V_Brand = txtV_Brand.Text;
                string V_Model = txtV_Model.Text;
                string V_Condition = Vehicle_Condition.Text;
                string V_Passengers = No_of_Passengers.Text;
                string V_Type = String.Empty;
                if (CarCheckBox.IsChecked ?? true)
                {
                    V_Type = "Car";
                }

                else if (BikeCheckBox.IsChecked ?? true)
                {
                    V_Type = "Bike";
                }

                else if (VanCheckBox.IsChecked ?? true)
                {
                    V_Type = "Van";
                }

                else if (BusCheckBox.IsChecked ?? true)
                {
                    V_Type = "Bus";
                }

                else if (LorryCheckBox.IsChecked ?? true)
                {
                    V_Type = "Lorry";
                }

                else if (_3wheelCheckBox.IsChecked ?? true)
                {
                    V_Type = "ThreeWheel";
                }

                using (SqlCommand updatecmd = new SqlCommand("UPDATE Vehicle SET V_PN = @V_PN, V_Brand = @V_Brand, V_Model = @V_Model, V_Type = @V_Type, V_Passengers = @V_Pass, V_Condition = @V_Cond WHERE V_CN = @V_CN"))
                {
                    updatecmd.Connection = db.GetSqlCon(); // Assign the connection

                    updatecmd.Parameters.AddWithValue("@V_CN", V_CN);
                    updatecmd.Parameters.AddWithValue("@V_PN", V_PN);
                    updatecmd.Parameters.AddWithValue("@V_Brand", V_Brand);
                    updatecmd.Parameters.AddWithValue("@V_Model", V_Model);
                    updatecmd.Parameters.AddWithValue("@V_Pass", V_Passengers);
                    updatecmd.Parameters.AddWithValue("@V_Cond", V_Condition);
                    updatecmd.Parameters.AddWithValue("@V_Type", V_Type);

                    // Add rest of the variables
                    updatecmd.ExecuteNonQuery();

                    
                }




                MessageBox.Show("Updated Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtV_Brand_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}