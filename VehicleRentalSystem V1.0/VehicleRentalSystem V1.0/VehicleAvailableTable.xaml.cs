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
    /// Interaction logic for VehicleAvailableTable.xaml
    /// </summary>
    public partial class VehicleAvailableTable : Window
    {
        public VehicleAvailableTable()
        {
            InitializeComponent();
            try
            {
                //DataGridView
                DataBaseFunctions db = new DataBaseFunctions();
                db.conopen();
                string query = "SELECT * FROM Vehicle WHERE V_State = 0";
                SqlDataAdapter da = new SqlDataAdapter(query, db.GetSqlCon());
                DataTable dt = new DataTable();
                da.Fill(dt);
                VehicleAvailableTable1.ItemsSource = dt.DefaultView;

                //using (db.GetSqlCon())
                //{
                //    db.conopen();
                //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee", db.GetSqlCon());
                //    DataTable dbv = new DataTable();
                //    da.Fill(dbv);
                //    VehicleAvailableTable1.ItemsSource = dbv.DefaultView;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ManageVehicleFor mdv= new ManageVehicleFor();

        private void VehicleAvailableTable1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
 
        }
    }
}
