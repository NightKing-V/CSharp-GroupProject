using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
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
            CarCheckBox.IsChecked= false;
            BikeCheckBox.IsChecked= false;
            VanCheckBox.IsChecked= false;
            _3wheelCheckBox.IsChecked = false;
            BusCheckBox.IsChecked= false;
            LorryCheckBox.IsChecked= false;
            No_of_Passengers.Text = "";
            Vehicle_Condition.Text = "";
            SelectedImage.Source = null;


        }

        private void btnInsert__Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtV_No.Text==""||
                    txtV_Model.Text == ""||
                    txtV_ChassisNo.Text == ""||
                    txtV_Brand.Text == ""||
                    txtV_No.Text == ""||
                    CarCheckBox.IsChecked == false||
                    BikeCheckBox.IsChecked == false||
                    VanCheckBox.IsChecked == false||
                    _3wheelCheckBox.IsChecked == false||
                    BusCheckBox.IsChecked == false||
                    LorryCheckBox.IsChecked == false||
                    No_of_Passengers.Text == ""||
                    Vehicle_Condition.Text == ""||
                    SelectedImage.Source == null)
                {
                    MessageBox.Show("Data Missing");
                }

                else
                {
                    string V_PN = txtV_No.Text; 
                    string V_CN = txtV_ChassisNo.Text;
                    //vehicle plate number not included include it
                    string V_Brand = txtV_Brand.Text;
                    string V_Model = txtV_Model.Text;
                    string V_type = "";

                    if (CarCheckBox.IsChecked == true)
                    {
                        V_type += "Car, ";
                    }
                    if (BikeCheckBox.IsChecked == true)
                    {
                        V_type += "Bike, ";
                    }
                    if (VanCheckBox.IsChecked == true)
                    {
                        V_type += "Van, ";
                    }
                    if (_3wheelCheckBox.IsChecked == true)
                    {
                        V_type += "3 Wheel, ";
                    }
                    if (BusCheckBox.IsChecked == true)
                    {
                        V_type += "Bus, ";
                    }
                    if (LorryCheckBox.IsChecked == true)
                    {
                        V_type += "Lorry, ";
                    }

                    // Remove the last comma and space from the string
                    V_type = V_type.TrimEnd(',', ' ');

                    // Use the V_type variable as needed
                    string V_Passenger= No_of_Passengers.Text;
                    string V_Condition = Vehicle_Condition.Text;


                    if (SelectedImage.Source != null)
                    {
                        string imageName = SelectedImage.Source.ToString();
                        // Use the imageName variable as needed
                    }
                    else
                    {
                        MessageBox.Show("Please select an image");
                    }

                    string V_State = V_Condition;

                    string Query1 = "INSERT INTO Vehicle (V_PN,V_CN,V_Brand,V_Model,V_type,V_Passenger,V_Condition,V_ImageFolderPath) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}','{5}','{6}','{7}')";
                    Query1 = string.Format(Query1,V_PN,V_CN,V_Brand,V_Model,V_type,V_Passenger,V_Condition,SelectedImage );
                    con.setdata(Query1);





                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
