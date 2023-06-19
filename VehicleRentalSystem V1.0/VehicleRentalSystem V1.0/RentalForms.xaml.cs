using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for RentalForms.xaml
    /// </summary>
    public partial class RentalForms : Window
    {
        DataBaseFunctions con;
        public RentalForms()
        {
            InitializeComponent();
            con = new DataBaseFunctions();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtUser.Text=="" || txtUser.Text == "" || txtC_Telephone.Text == ""||txtC_Email.Text== "" ||C_address.Text == ""||V_Chassis.Text == ""|| Startdate.Text == ""||Startdate == null||  Enddate.Text == ""|| Enddate == null||Returndate.Text == ""||Returndate ==null)
                {
                    MessageBox.Show("Data Missing");
                }
                else
                {
                    
                    string C_Name = txtUser.Text;
                    string C_NIC = txtC_NIC.Text;
                    string C_Tel = txtC_Telephone.Text;
                    string C_Address = C_address.Text;
                    string C_Email = txtC_Email.Text;
                    string V_chassis = V_Chassis.Text;
                    DateTime StartDate = Startdate.SelectedDate.Value;
                    DateTime EndDate = Enddate.SelectedDate.Value;
                    DateTime ReturnDate = Returndate.SelectedDate.Value;

                    //INSERTING TO CUSTOMER TABLE
                    string Query1 = "INSERT INTO Customer (C_NAME, C_NIC,C_Tel,C_Address,C_Email) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
                    Query1 = string.Format(Query1, C_Name, C_NIC, C_Tel, C_Address, C_Email);
                    con.setdata(Query1);

                    //INSERTING TO VEHICLE TABLE
                    //string Query2 = "INSERT INTO Vehicle (V_CN, V_PN) VALUES ('{0}', '{1}')";
                    //Query2 = string.Format(Query2, V_chassis,package );
                    //con.setdata(Query2);

                    //INSEERTING TO VEHICLE RENT TABLE
                    string Query3 = "INSERT INTO VehicleRent (C_NIC,V_CN, VehicleNumber,StartDate,EndDate,ReturnDate) VALUES ('{0}', '{1}','{2}','{3}', '{4}','{5}')";
                    Query3 = string.Format(Query3,C_NIC,V_chassis,StartDate,EndDate,ReturnDate);
                    con.setdata(Query3);


                    MessageBox.Show("Successfully Added");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUser.Text = "";
            txtC_NIC.Text = "";
            txtC_Telephone.Text = "";
            txtC_Email.Text = "";
            C_address.Text="";
            V_Chassis.Text = "";
            Startdate.Text = "";
            Startdate = null;
            Enddate.Text = "";
            Enddate =null;
            Returndate.Text = "";
            Returndate =null;
        }
    }
}
