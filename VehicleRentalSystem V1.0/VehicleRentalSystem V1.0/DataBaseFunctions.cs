using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Windows.Forms;

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
            //ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\lenovo\Documents\GitHub\CSharp-GroupProject\VehicleRentalSystem V1.0\VehicleRentalSystem V1.0\VehicleRentalDB.mdf"";Integrated Security=True";

            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""G:\DEVELOPMENT\GIT\CSharp-GroupProject\VehicleRentalSystem V1.0\VehicleRentalSystem V1.0\VehicleRentalDB.mdf"";Integrated Security=True;Connect Timeout=30";

       

            sqlcon = new SqlConnection(ConStr);

        }

        public void conopen()
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
        }

        public void conclose()
        {
                sqlcon.Close();
        }

        public int setdata(string Query)
        {
            int count = 0;
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            try
            { 
                sqlcmd = new SqlCommand(Query, sqlcon);
                count = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return count;
        }
        public DataTable getdata(string Query)
        {
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            try
            {
                dt = new DataTable();
                sqlcmd = new SqlCommand(Query, sqlcon);
                dataadapter = new SqlDataAdapter(sqlcmd);
                dataadapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public SqlConnection GetSqlCon()
        { 
                return sqlcon; 
         
        }
    }
}
