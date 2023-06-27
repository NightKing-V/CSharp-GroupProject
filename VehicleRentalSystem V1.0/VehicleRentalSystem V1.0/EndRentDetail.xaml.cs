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
    /// Interaction logic for EndRentDetail.xaml
    /// </summary>
    public partial class EndRentDetail : Window
    {
        public EndRentDetail()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string H = RentIDtxt.Text;
            string RD = ReturnDate.Text;
            string Df = DFeeTxt.Text;

            if (H == "" || RD == "" || Df == "")
            {
                MessageBox.Show("Enter All Details");
            }
            else
            {
                ReceiptGenarator RG = new ReceiptGenarator();
                RG.RentFee(RentIDtxt.Text, ReturnDate.Text, DFeeTxt.Text);
                this.Hide();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            RentIDtxt.Clear(); 
            DFeeTxt.Clear();
        }
    }
}
