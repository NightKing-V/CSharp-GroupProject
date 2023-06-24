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
            //try 
            //{
                if(C_Name == "" || C_NIC == "" || C_Emails == "" || C_Add == "" || C_Tel == "" || V_C == "" || StartD == "" || EndD == "" || E_Mileage.Text == "" || A_Payment.Text == "" || S_Mileage.Text == "" || !Regex.IsMatch(C_Emails,@"^[^@\s]+@[^@\s]+\.[^@\s]+$",RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
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


                    //Adding new hire

                    int newvhresult;
                    using (SqlCommand newrentcmd = new SqlCommand("INSERT INTO VehicleHire(C_NIC, V_CN, StartDate, StartMileage, EtaMileage, EndDate, R_NIC, Active, P_ID, PricePerLiter, Advancefee) VALUES(@C_NIC, @V_C, @StartD, @ETAM, @SMil, @EndD, @R_NIC, 1, @P_ID, @PPLiter, @ADPay)", DBF.GetSqlCon()))
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
                    if(next == MessageBoxResult.OK)
                    {
                        FormResultGenerator FRG = new FormResultGenerator();
                        FRG.generateHireformresult(Hire_ID);
                    }
                    DBF.conclose();
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
