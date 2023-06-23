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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for VehicleHireForm.xaml
    /// </summary>
    public partial class VehicleHireForm : Window
    {
        private string Hire_ID, C_Name, C_NIC, C_Add, C_Tel, C_Emails, V_C, StartD, EndD, R_NIC;
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
            PPLiter = 0;

            string message = "";
            try 
            {
                if(C_Name == "" || C_NIC == "" || C_Emails == "" || C_Add == "" || C_Tel == "" || V_C == "" || StartD == "" || EndD == "" || E_Mileage.Text == "" || A_Payment.Text == "" || S_Mileage.Text == "" || !Regex.IsMatch(C_Emails,@"^[^@\s]+@[^@\s]+\.[^@\s]+$",RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    MessageBox.Show("Fill all the fields correctly", "Error");
                }
                else
                {
                    ETAM = double.Parse(E_Mileage.Text);
                    SMil = double.Parse(S_Mileage.Text);
                    ADPay = double.Parse(A_Payment.Text);

                    //Customer Checking 
                    DataBaseFunctions DBF = new DataBaseFunctions();
                    DBF.conopen();
                    string queryCheckC = "SELECT C_NIC FROM Customer WHERE C_NIC = " + C_NIC + ";";
                    SqlCommand CheckCcmd = new SqlCommand(queryCheckC, DBF.GetSqlCon());
                    int Cresult = CheckCcmd.ExecuteNonQuery();
                    if(Cresult == 0)
                    {
                        //adding new Customer
                        string newCus = "INSERT INTO Customer(C_NIC,C_NAME,C_Tel,C_Email,C_Address) VALUES("+C_NIC+","+C_Name+","+C_Emails+","+C_Add+");";
                        SqlCommand newcuscmd = new SqlCommand(newCus, DBF.GetSqlCon());
                        int newcresult = newcuscmd.ExecuteNonQuery();
                        if(newcresult != 0)
                        {
                            message += "New Customer Added!\n";
                        }
                        else
                        {
                            message += "Couldn't Add New Customer!\n";
                        }
                    }

                    //Adding new hire
                    String queryVH = "INSERT INTO VehicleHire(C_NIC, V_CN, StartDate, StartMileage, EtaMileage, EndDate, R_NIC, Active, PricePerLiter, Advancefee) VALUES("+C_Name+","+V_C+","+StartD+","+EndD+","+ETAM+","+SMil+","+R_NIC+",1,"+PPLiter+","+ADPay+");";
                    SqlCommand VHcmd = new SqlCommand(queryVH, DBF.GetSqlCon());
                    int newvhresult = VHcmd.ExecuteNonQuery();
                  
                    if(newvhresult != 0)
                    {
                        message += "New Hire Added!\n";

                        //retreiving ID
                        string querygetid = "SELECT Hire_ID FROM VehicleHire WHERE C_NIC="+C_NIC+" && V_CN="+V_C+"&& StartDate="+StartD+";";
                        SqlCommand getidcmd = new SqlCommand(querygetid, DBF.GetSqlCon());

                        List<string> ID = new List<string>();
                        using (SqlDataReader reader = getidcmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ID.Add(reader[0].ToString());
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
                        FRG.generateformresult(Hire_ID);
                    }
                    DBF.conclose();
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
