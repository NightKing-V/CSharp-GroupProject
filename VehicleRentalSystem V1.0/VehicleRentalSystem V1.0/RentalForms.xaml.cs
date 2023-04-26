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
using System.Windows.Shapes;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for RentalForms.xaml
    /// </summary>
    public partial class RentalForms : Window
    {
        public RentalForms()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUser.Text = "";
            txtC_NIC.Text = "";
            txtC_Telephone.Text = "";
            txtC_Email.Text = "";
            C_Address.Text="";
            V_Chassis.Text = "";
            VehicleNumber.Text = "";
            StartDate.Text = "";
            StartDate = null;
            EndDate.Text = "";
            EndDate =null;
            ReturnDate.Text = "";
            ReturnDate=null;



        }
    }
}
