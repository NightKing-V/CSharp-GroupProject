using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;

        }

        public int setdata(string Query)
        {
            int cnt = 0;
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            sqlcmd.CommandText = Query;
            cnt = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            return cnt;
        }
        public DataTable getdata(string Query)
        {
            dt = new DataTable();
            dataadapter = new SqlDataAdapter(Query, ConStr);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataadapter);
            dataadapter.Fill(dt);
            return dt;
        }
    }
}
