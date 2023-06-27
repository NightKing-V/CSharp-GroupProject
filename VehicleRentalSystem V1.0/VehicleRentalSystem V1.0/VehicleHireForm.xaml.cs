using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for VehicleHireForm.xaml
    /// </summary>
    public partial class VehicleHireForm : Window
    {
        private string Hire_ID, C_Name, C_NIC, C_Add, C_Tel, C_Emails, V_C, StartD, EndD, R_NIC, P_Name, P_ID;
        private double ETAM, SMil, ADPay, PPLiter;
        public VehicleHireForm()
        {
            InitializeComponent();
        }

 
        private void btnClearVH_Click(object sender, RoutedEventArgs e)
        {
            txtUser.Text = "";
            txtC_NIC.Text = "";
            txtC_Telephone.Text = "";
            txtC_Email.Text = "";
            C_Address.Text = "";
            V_Chassis.Text = "";
            StartDate.Text = "";
            StartDate = null;
            EndDate.Text = "";
            EndDate = null;
            txtR_NIC.Text = "";
            E_Mileage.Clear();
            S_Mileage.Clear();
            A_Payment.Clear();
            txtO_Price.Clear();
        }

        private void btnSubmitVH_Click(object sender, RoutedEventArgs e)
        {
            C_Name = txtUser.Text;
            C_NIC = txtC_NIC.Text;
            C_Emails = txtC_Email.Text;
            C_Add = C_Address.Text;
            C_Tel = txtC_Telephone.Text;
            V_C = V_Chassis.Text;
            StartD = StartDate.Text;
            EndD = EndDate.Text;
            R_NIC = txtR_NIC.Text;
            P_Name = ((ComboBoxItem)CMBP.SelectedItem).Tag.ToString();

            string message = "";
            try
            {
                if (C_Name == "" || C_NIC == "" || C_Emails == "" || C_Add == "" || C_Tel == "" || V_C == "" || StartD == "" || EndD == "" || E_Mileage.Text == "" || A_Payment.Text == "" || S_Mileage.Text == "" || !Regex.IsMatch(C_Emails,@"^[^@\s]+@[^@\s]+\.[^@\s]+$",RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    MessageBox.Show("Fill all the fields correctly", "Error");
                }
                else
                {
                    PPLiter = double.Parse(txtO_Price.Text);
                    ETAM = double.Parse(E_Mileage.Text);
                    SMil = double.Parse(S_Mileage.Text);
                    ADPay = double.Parse(A_Payment.Text);

                    //Customer Checking 
                    DataBaseFunctions DBF = new DataBaseFunctions();
                    int Cresult;
                    DBF.conopen();


                    string query = "SELECT * FROM Vehicle WHERE V_CN=@V_CN";
                    SqlCommand command = new SqlCommand(query, DBF.GetSqlCon());
                    command.Parameters.AddWithValue("@V_CN", V_C);
                    List<string> VAresults = new List<string>();
                    using (SqlDataReader vreader = command.ExecuteReader())
                    {
                        while (vreader.Read())
                        {
                            VAresults.Add(vreader[0].ToString());
                        }
                    }
                    if (VAresults.Count > 0)
                    {
                        string rquery = "SELECT * FROM Rider WHERE R_NIC=@R_NIC";
                        SqlCommand rcommand = new SqlCommand(rquery, DBF.GetSqlCon());
                        rcommand.Parameters.AddWithValue("@R_NIC", R_NIC);
                        List<string> RIresults = new List<string>();

                        using(SqlDataReader vreader = rcommand.ExecuteReader())
                        {
                            while (vreader.Read())
                            {
                                RIresults.Add(vreader[0].ToString());
                            }
                        }
                        if (RIresults.Count > 0)
                        {

                            List<string> vstate = new List<string>();

                            using (SqlCommand checkv = new SqlCommand("SELECT V_State FROM Vehicle WHERE V_CN=@V_C", DBF.GetSqlCon()))
                            {
                                checkv.Parameters.AddWithValue("@V_C", V_C);
                                using (SqlDataReader reader = checkv.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        vstate.Add(reader[0].ToString());
                                    }
                                }
                            }

                            List<string> rstate = new List<string>();

                            using (SqlCommand checkr = new SqlCommand("SELECT R_State FROM Rider WHERE R_NIC=@R_NIC", DBF.GetSqlCon()))
                            {
                                checkr.Parameters.AddWithValue("@R_NIC", R_NIC);
                                using (SqlDataReader reader = checkr.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        rstate.Add(reader[0].ToString());
                                    }
                                }
                            }

                            string stateR = rstate[0];
                            string stateV = vstate[0];

                            if (stateR == "False")
                            {
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

                                    if (NICresults.Count == 0)
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


                                    //Adding new hire

                                    int newvhresult;
                                    using (SqlCommand newrentcmd = new SqlCommand("INSERT INTO VehicleHire(C_NIC, V_CN, StartDate, StartMileage, EtaMileage, EndDate, R_NIC, Active, P_ID, PricePerLiter, Advancefee) VALUES(@C_NIC, @V_C, @StartD, @SMil, @ETAM, @EndD, @R_NIC, 1, @P_ID, @PPLiter, @ADPay)", DBF.GetSqlCon()))
                                    {
                                        var SD = Convert.ToDateTime(this.StartD);
                                        var ED = Convert.ToDateTime(this.EndD);
                                        newrentcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                                        newrentcmd.Parameters.AddWithValue("@V_C", V_C);
                                        newrentcmd.Parameters.AddWithValue("@StartD", SD);
                                        newrentcmd.Parameters.AddWithValue("@EndD", ED);
                                        newrentcmd.Parameters.AddWithValue("@ETAM", ETAM);
                                        newrentcmd.Parameters.AddWithValue("@SMil", SMil);
                                        newrentcmd.Parameters.AddWithValue("@R_NIC", R_NIC);
                                        newrentcmd.Parameters.AddWithValue("@P_ID", P_ID);
                                        newrentcmd.Parameters.AddWithValue("@PPLiter", PPLiter);
                                        newrentcmd.Parameters.AddWithValue("@ADPay", ADPay);
                                        newvhresult = newrentcmd.ExecuteNonQuery();
                                    }
                                    //Making vehicle used

                                    using (SqlCommand vhstate = new SqlCommand("UPDATE Vehicle SET V_State = @V_State WHERE V_CN = @V_CN", DBF.GetSqlCon()))
                                    {
                                        vhstate.Parameters.AddWithValue("@V_State", true);
                                        vhstate.Parameters.AddWithValue("@V_CN", V_C);
                                        vhstate.ExecuteNonQuery();
                                    }

                                    message += "Vehicle Changed States!\n";

                                    //making rider used

                                    using (SqlCommand Rstate = new SqlCommand("UPDATE Rider SET R_State = @R_State WHERE R_NIC = @R_NIC", DBF.GetSqlCon()))
                                    {
                                        Rstate.Parameters.AddWithValue("@R_State", true);
                                        Rstate.Parameters.AddWithValue("@R_NIC", R_NIC);
                                        Rstate.ExecuteNonQuery();
                                    }
                                    message += "Rider Changed States!\n";


                                    if (newvhresult != 0)
                                    {
                                        message += "New Hire Added!\n";

                                        //Retrieving ID
                                        List<string> ID = new List<string>();

                                        using (SqlCommand getidcmd = new SqlCommand("SELECT Hire_ID FROM VehicleHire WHERE C_NIC=@C_NIC AND V_CN=@V_C AND StartDate=@StartD", DBF.GetSqlCon()))
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
                                        Hire_ID = ID[0];

                                    }
                                    else
                                    {
                                        message += "Couldn't Add New Hire!\n";
                                    }
                                    MessageBoxResult next = MessageBox.Show(message, "Result", MessageBoxButton.OK);
                                    if (next == MessageBoxResult.OK)
                                    {

                                        List<string> Data = new List<string> { Hire_ID, C_NIC, C_Name, C_Add, C_Tel, V_C, StartD, SMil.ToString(), ETAM.ToString(), EndD, R_NIC, PPLiter.ToString(), ADPay.ToString() };

                                        FormResultGenerator FRG = new FormResultGenerator();
                                        FRG.generateHireformresult(Data);
                                        this.Hide();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Vehicle is In Use");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Rider is In Use");
                            }
                            DBF.conclose();
                            
                        }
                        else
                        {
                        System.Windows.MessageBox.Show("This Rider is not in the DataBase :" + R_NIC);

                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("This Vehicle is not in the DataBase :" + V_C);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
