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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for DetailsUC.xaml
    /// </summary>
    public partial class DetailsUC : UserControl
    {
        private string searchtxt;
        private string Query;
        DataTable dt;
        public DetailsUC()
        {
            InitializeComponent();
        }

        private void btnSubmitVH_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                searchtxt = searchTxt.Text;
                DG.ItemsSource = null;
                if (searchtxt == "")
                {
                    MessageBox.Show("Enter Search Text");
                }
                else
                {
                    DataBaseFunctions SB = new DataBaseFunctions();
                    if (CMBPIT.Text == "Customer NIC")
                    {
                        if (CMBPST.Text == "Hire")
                        {

                            Query = "SELECT * from VehicleHire WHERE C_NIC LIKE '" + searchtxt + "';";
                            dt = SB.getdata(Query);

                        }
                        else if (CMBPST.Text == "Rent")
                        {
                            Query = "SELECT * from VehicleRent WHERE C_NIC LIKE '" + searchtxt + "';";
                            dt = SB.getdata(Query);
                        }
                        DG.ItemsSource = dt.DefaultView;
                    }
                    else if (CMBPIT.Text == "Rider NIC")
                    {
                        if (CMBPST.Text == "Hire")
                        {

                            Query = "SELECT * from VehicleHire WHERE R_NIC LIKE '" + searchtxt + "';";
                            dt = SB.getdata(Query);
                            DG.ItemsSource = dt.DefaultView;

                        }
                        else if (CMBPST.Text == "Rent")
                        {
                            MessageBox.Show("There are no Riders in Rent");
                        }
                    }
                    else if (CMBPIT.Text == "Vehicle ChassisNO")
                    {
                        if (CMBPST.Text == "Hire")
                        {

                            Query = "SELECT * from VehicleHire WHERE V_CN LIKE '" + searchtxt + "';";
                            dt = SB.getdata(Query);

                        }
                        else if (CMBPST.Text == "Rent")
                        {
                            Query = "SELECT * from VehicleRent WHERE V_CN LIKE '" + searchtxt + "';";
                            dt = SB.getdata(Query);
                        }
                        DG.ItemsSource = dt.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}