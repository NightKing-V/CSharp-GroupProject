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
    /// Interaction logic for DriversAvailableTable.xaml
    /// </summary>
    public partial class DriversAvailableTable : Window
    {
        public DriversAvailableTable()
        {
            InitializeComponent();
        }

        private void DriversAvailableTable1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                DataBaseFunctions db = new DataBaseFunctions();
                //DataGridView


                using (db.GetSqlCon())
                {
                    db.conopen();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee WHERE V_STATE= true", db.GetSqlCon());
                    DataTable dbv = new DataTable();
                    da.Fill(dbv);
                    DriversAvailableTable1.ItemsSource = dbv.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
