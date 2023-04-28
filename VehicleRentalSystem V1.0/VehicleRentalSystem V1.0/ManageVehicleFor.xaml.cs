using Microsoft.Win32;
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
    /// Interaction logic for ManageVehicleFor.xaml
    /// </summary>
    public partial class ManageVehicleFor : Window
    {
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

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
