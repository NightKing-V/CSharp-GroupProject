using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VehicleRentalSystem_V1._0
{
    internal class DataBaseFunctions
    {
        private SqlConnection sqlcon;
        private SqlCommand sqlcmd;
        private DataTable dt;
        private String ConStr;
        private SqlDataAdapter dataadapter;

        public DataBaseFunctions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lenovo\Documents\GitHub\CSharp-GroupProject\VehicleRentalSystem V1.0\VehicleRentalSystem V1.0\VehicleRentalDB.mdf"";Integrated Security=True";
            sqlcon = new SqlConnection(ConStr);

        }

        public int setdata(string Query)
        {
            int count = 0;
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            sqlcmd = new SqlCommand(Query, sqlcon);
            count = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            return count;
        }
        public DataTable getdata(string Query)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            dt = new DataTable();
            sqlcmd = new SqlCommand(Query, sqlcon);
            dataadapter = new SqlDataAdapter(sqlcmd);
            dataadapter.Fill(dt);
            return dt;
        }
    }
}
