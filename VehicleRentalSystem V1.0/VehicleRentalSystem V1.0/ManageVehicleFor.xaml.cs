﻿using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
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
        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (.jpg)|.jpg|All files (.)|.";
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtV_Model.Text = "";
            txtV_ChassisNo.Text = "";
            txtV_Brand.Text = "";
            txtV_No.Text = "";
            CarCheckBox.IsChecked = false;
            BikeCheckBox.IsChecked = false;
            VanCheckBox.IsChecked = false;
            _3wheelCheckBox.IsChecked = false;
            BusCheckBox.IsChecked = false;
            LorryCheckBox.IsChecked = false;
            No_of_Passengers.Text = "";
            Vehicle_Condition.Text = "";
            SelectedImage.Source = null;


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
                bool Car = CarCheckBox.IsChecked ?? false;
                bool bike = BikeCheckBox.IsChecked ?? false;
                bool van = VanCheckBox.IsChecked ?? false;
                bool threewheel = _3wheelCheckBox.IsChecked ?? false;
                bool bus = BusCheckBox.IsChecked ?? false;
                bool lorry = LorryCheckBox.IsChecked ?? false;
                if (SelectedImage.Source != null)
                {
                    string imageName = SelectedImage.Source.ToString();
                    // Use the imageName variable as needed
                }
              

                DataBaseFunctions dbFunctions = new DataBaseFunctions();
                dbFunctions.setdata("INSERT INTO Vehicle (V_CN,V_Brand,V_Model,V_Passengers,V_Condition,V_ImageFolderPath,Car,Bike,Van,Bus,Lorry,_threewheel) VALUES ('" + V_CN + "','" + V_Brand + "','" + V_Model + "','" + V_Passengers + "','" + V_State + "','" + SelectedImage.Source + "','" + Car + "','" + bike + "','" + van + "','" + bus + "','" + lorry + "','" + threewheel + "')");


                MessageBox.Show("Inserted Successfully");         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string V_PN = txtV_No.Text;
            string V_CN = txtV_ChassisNo.Text;
            //vehicle plate number not included include it
            string V_Brand = txtV_Brand.Text;
            string V_Model = txtV_Model.Text;
            string V_State = Vehicle_Condition.Text;
            string V_Passengers = No_of_Passengers.Text;
            bool Car = CarCheckBox.IsChecked ?? false;
            bool bike = BikeCheckBox.IsChecked ?? false;
            bool van = VanCheckBox.IsChecked ?? false;
            bool threewheel = _3wheelCheckBox.IsChecked ?? false;
            bool bus = BusCheckBox.IsChecked ?? false;
            bool lorry = LorryCheckBox.IsChecked ?? false;

            using (SqlCommand updatecmd = new SqlCommand("UPDATE Vehicle SET V_CN = @V_CN, V_PN = @V_PN, V_Brand = @V_Brand, V_Model = @V_Model, V_Type = @V_Type, V_Passengers = @V_Pass, V_Condition = @V_Cond, V_State = @V_State, DisPerLiter = @DPL"))
            {
                updatecmd.Parameters.AddWithValue("@V_CN", V_CN);
                updatecmd.Parameters.AddWithValue("@V_PN", V_PN);
                updatecmd.Parameters.AddWithValue("@V_Brand", V_Brand);
                updatecmd.Parameters.AddWithValue("@V_Model", V_Model);
                //add rest of the variables
                updatecmd.ExecuteNonQuery();
            }
        }

        private void txtV_Brand_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}