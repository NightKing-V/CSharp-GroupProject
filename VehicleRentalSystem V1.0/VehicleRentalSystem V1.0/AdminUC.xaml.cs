﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for AdminUC.xaml
    /// </summary>
    public partial class AdminUC : UserControl
    {
        public AdminUC()
        {
            InitializeComponent();
        }

        private void VehicleInUseBtn_Click(object sender, RoutedEventArgs e)
        {
            Manage_Employee manage_Employee =new Manage_Employee();
            manage_Employee.Show();
        }

        private void VehicleAvBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
