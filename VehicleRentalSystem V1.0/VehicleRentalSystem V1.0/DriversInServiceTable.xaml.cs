using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for DriversInServiceTable.xaml
    /// </summary>
    public partial class DriversInServiceTable : Window
    {
        public DriversInServiceTable()
        {
            InitializeComponent();
            try
            {
                DataBaseFunctions db = new DataBaseFunctions();
                db.conopen();
                string query = "SELECT * FROM Rider WHERE R_State = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, db.GetSqlCon());
                DataTable dt = new DataTable();
                da.Fill(dt);
                DriversInServiceTable1.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DriversInServiceTable1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
