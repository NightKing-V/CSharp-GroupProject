using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        private string Rent_ID, C_Name, C_NIC, C_Add, C_Tel, C_Emails, V_C, StartD, EndD, P_ID, P_Name;

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtC_Name.Text = "";
            txtC_NIC.Text = "";
            txtC_Telephone.Text = "";
            txtC_Email.Text = "";
            C_address.Text = "";
            V_Chassis.Text = "";
            Startdate.Text = "";
            Enddate.Text = "";
        }

        public RentalForms()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            C_Name = txtC_Name.Text;
            C_NIC = txtC_NIC.Text;
            C_Emails = txtC_Email.Text;
            C_Add = C_address.Text;
            C_Tel = txtC_Telephone.Text;
            V_C = V_Chassis.Text;
            StartD = Startdate.Text;
            EndD = Enddate.Text;
            P_Name = ((ComboBoxItem)CMBP.SelectedItem).Tag.ToString();

            string message = "";
            try
            {
                if (txtC_Name.Text == "" || txtC_Name.Text == "" || txtC_Telephone.Text == "" || txtC_Email.Text == "" || C_address.Text == "" || V_Chassis.Text == "" || Startdate.Text == "" || Startdate == null || Enddate.Text == "" || Enddate == null || !Regex.IsMatch(C_Emails, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    System.Windows.MessageBox.Show("Fill all the fields correctly", "Error");
                }
                else
                {

                    //Checing Customer
                    DataBaseFunctions DBF = new DataBaseFunctions();
                    int Cresult;
                    DBF.conopen();

                    List<string> vstate = new List<string>();

                    using (SqlCommand checkv = new SqlCommand("SELECT V_State FROM Vehicle WHERE V_CN=@V_C", DBF.GetSqlCon()))
                    {
                        checkv.Parameters.AddWithValue("@V_CN", V_C);
                        using (SqlDataReader reader = checkv.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vstate.Add(reader[0].ToString());
                            }
                        }
                    }

                    string stateV = vstate[0];

                    if (stateV == "False")
                    {

                        List<string> NICresults = new List<string>();

                        using (SqlCommand CheckCcmd = new SqlCommand("select * from Customer where C_NIC = @C_NIC", DBF.GetSqlCon()))
                        {
                            CheckCcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                            using (SqlDataReader reader = CheckCcmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    NICresults.Add(reader[0].ToString());
                                }
                            }
                        }
                        Cresult = NICresults.Count;

                        if (Cresult == 0)
                        {
                            //Adding new Customer
                            int newcresult;
                            using (SqlCommand newcuscmd = new SqlCommand("INSERT INTO Customer(C_NIC,C_NAME,C_Tel,C_Email,C_Address) VALUES(@C_NIC,@C_Name,@C_Tel,@C_Email,@C_Add)", DBF.GetSqlCon()))
                            {
                                newcuscmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                                newcuscmd.Parameters.AddWithValue("@C_Name", C_Name);
                                newcuscmd.Parameters.AddWithValue("@C_Tel", C_Tel);
                                newcuscmd.Parameters.AddWithValue("@C_Email", C_Emails);
                                newcuscmd.Parameters.AddWithValue("@C_Add", C_Add);
                                newcresult = newcuscmd.ExecuteNonQuery();
                            }

                            if (newcresult != 0)
                            {
                                message += "New Customer Added!\n";
                            }
                            else
                            {
                                message += "Couldn't Add New Customer!\n";
                            }
                        }

                        //getting package ID

                        List<string> PID = new List<string>();

                        using (SqlCommand getpidcmd = new SqlCommand("SELECT P_ID FROM RentPackages WHERE P_Name= @P_Name", DBF.GetSqlCon()))
                        {
                            getpidcmd.Parameters.AddWithValue("@P_Name", P_Name);

                            using (SqlDataReader reader = getpidcmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    PID.Add(reader[0].ToString());
                                }
                            }
                        }
                        P_ID = PID[0];

                        //Adding new Rent

                        int newvhresult;
                        using (SqlCommand newrentcmd = new SqlCommand("INSERT INTO VehicleRent(C_NIC, V_CN, StartDate, EndDate, P_ID, Active) VALUES(@C_NIC,@V_C,@StartD,@EndD,@P_ID,1)", DBF.GetSqlCon()))
                        {
                            var SD = Convert.ToDateTime(this.StartD);
                            var ED = Convert.ToDateTime(this.EndD);
                            newrentcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                            newrentcmd.Parameters.AddWithValue("@V_C", V_C);
                            newrentcmd.Parameters.AddWithValue("@StartD", SD);
                            newrentcmd.Parameters.AddWithValue("@EndD", ED);
                            newrentcmd.Parameters.AddWithValue("@P_ID", P_ID);
                            newvhresult = newrentcmd.ExecuteNonQuery();
                        }


                        if (newvhresult != 0)
                        {
                            message += "New Rent Added!\n";

                            //Retrieving ID
                            List<string> ID = new List<string>();

                            using (SqlCommand getidcmd = new SqlCommand("SELECT Rent_ID FROM VehicleRent WHERE C_NIC=@C_NIC AND V_CN=@V_C AND StartDate=@StartD", DBF.GetSqlCon()))
                            {
                                var SD = Convert.ToDateTime(this.StartD);
                                getidcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                                getidcmd.Parameters.AddWithValue("@V_C", V_C);
                                getidcmd.Parameters.AddWithValue("@StartD", SD);

                                using (SqlDataReader reader = getidcmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        ID.Add(reader[0].ToString());
                                    }
                                }
                            }
                            Rent_ID = ID[0];

                        }
                        else
                        {
                            message += "Couldn't Add New Rent!\n";
                        }
                        MessageBoxResult next = System.Windows.MessageBox.Show(message, "Result", MessageBoxButton.OK);
                        if (next == MessageBoxResult.OK)
                        {
                            List<string> Data = new List<string> { Rent_ID, C_NIC, C_Name, C_Add, C_Tel, V_C, StartD, EndD, P_Name };

                            FormResultGenerator FRG = new FormResultGenerator();
                            FRG.generateRentformresult(Data);
                        }
                        DBF.conclose();

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Vehicle is Unavilable");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

    }
}
