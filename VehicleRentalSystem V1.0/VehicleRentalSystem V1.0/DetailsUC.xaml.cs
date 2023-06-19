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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void SearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtnClick(object sender, RoutedEventArgs e)
        {
            searchtxt = SearchBar.Text;
            if(searchtxt == "") 
            {
                MessageBox.Show("Enter Search Text");
            }
            else
            {
                DataBaseFunctions SB = new DataBaseFunctions();
                DetailsDataCus DG = new DetailsDataCus();
                if (SearchType.Text == "Customer NIC")
                {
                    if (RecordType.Text == "Hire")
                    {

                        Query = "SELECT * from VehicleHire WHERE C_NIC LIKE '" + searchtxt + "';";
                        dt = SB.getdata(Query);

                    }
                    else if (RecordType.Text == "Rent")
                    {
                        Query = "SELECT * from VehicleRent WHERE C_NIC LIKE '" + searchtxt + "';";
                        dt = SB.getdata(Query);
                    }
                    DG.datafiller(dt);
                }
                else if (SearchType.Text == "Rider NIC")
                {
                    if (RecordType.Text == "Hire")
                    {

                        Query = "SELECT * from VehicleHire WHERE R_NIC LIKE '" + searchtxt + "';";
                        dt = SB.getdata(Query);

                    }
                    else if (RecordType.Text == "Rent")
                    {
                        Query = "SELECT * from VehicleRent WHERE R_NIC LIKE '" + searchtxt + "';";
                        dt = SB.getdata(Query);
                    }
                    DG.datafiller(dt);
                }
                else if (SearchType.Text == "Vehicle NO")
                {
                    if (RecordType.Text == "Hire")
                    {

                        Query = "SELECT * from VehicleHire WHERE V_NO LIKE '" + searchtxt + "';";
                        dt = SB.getdata(Query);

                    }
                    else if (RecordType.Text == "Rent")
                    {
                        Query = "SELECT * from VehicleRent WHERE V_NO LIKE '" + searchtxt + "';";
                        dt = SB.getdata(Query);
                    }
                    DG.datafiller(dt);
                }
            }
           
        }
    }
}
