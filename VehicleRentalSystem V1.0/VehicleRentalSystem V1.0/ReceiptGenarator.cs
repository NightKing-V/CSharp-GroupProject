using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace VehicleRentalSystem_V1._0
{
    internal class ReceiptGenarator
    {
        private string html, startdate, enddate, returndate, duration, ReceiptNO,C_NIC, C_NAME, C_Address, Date, P_ID, V_CN, R_NIC;
        private double Rental, fee, penaltyfee, totalfee, oilfee, damagefee, PricePerLiter, advance;
        private int penaltyrate, DisPerLiter, ETAmilage, C_Tel;

        public void RentFee(string Rent_ID, string ReturnD, string damagefee)
        {
            try
            {
                ReceiptNO = Rent_ID;
                this.returndate = ReturnD;
                this.damagefee = double.Parse(damagefee);

                var startdate = Convert.ToDateTime(this.startdate);
                var enddate = Convert.ToDateTime(this.enddate);
                var returndate = Convert.ToDateTime(this.returndate);
                var validdays = (enddate - startdate).TotalDays;
                var invaliddays = (returndate - enddate).TotalDays;

                List<string> rentrecord = new List<string>();
                DataBaseFunctions DBF = new DataBaseFunctions();
                DBF.conopen();
                using (SqlCommand rentrecordcmd = new SqlCommand("select C_NIC from VehicleRent where Rent_ID = @Rent_ID", DBF.GetSqlCon()))
                {
                    rentrecordcmd.Parameters.AddWithValue("@Rent_ID", Rent_ID);
                    using (SqlDataReader reader = rentrecordcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentrecord.Add(reader[0].ToString());
                        }
                    }
                }
                C_NIC = rentrecord[0];

                //Making vehicle ava
                using (SqlCommand vhstate = new SqlCommand("UPDATE Vehicle SET V_State = @V_State WHERE V_CN = @V_CN", DBF.GetSqlCon()))
                {
                    vhstate.Parameters.AddWithValue("@V_State", false);
                    vhstate.Parameters.AddWithValue("@V_CN", V_CN);
                    vhstate.ExecuteNonQuery();
                }


                List<string> Cresults1 = new List<string>();

                using (SqlCommand CNcmd = new SqlCommand("select C_NAME from Customer where C_NIC = @C_NIC", DBF.GetSqlCon()))
                {
                    CNcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                    using (SqlDataReader reader = CNcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults1.Add(reader[0].ToString());
                        }
                    }
                }
                C_NAME = Cresults1[0];

                List<string> Cresults2 = new List<string>();

                using (SqlCommand CTcmd = new SqlCommand("select C_Tel from Customer where C_NIC = @C_NIC", DBF.GetSqlCon()))
                {
                    CTcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                    using (SqlDataReader reader = CTcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults2.Add(reader[0].ToString());

                        }
                    }
                }
                C_Tel = int.Parse(Cresults2[0]);

                List<string> Cresults3 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select C_Address from Customer where C_NIC = @C_NIC", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults3.Add(reader[0].ToString());
                        }
                    }
                }
                C_Address = Cresults3[0];


                List<string> Cresults4 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select P_ID from VehicleRent where Rent_ID = @Rent_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@Rent_ID", Rent_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults4.Add(reader[0].ToString());

                        }
                    }
                }

                P_ID = Cresults4[0];

                List<string> Cresults5 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select Rental from RentPackages where P_ID = @P_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@P_ID", P_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults5.Add(reader[0].ToString());

                        }
                    }
                }
                Rental = double.Parse(Cresults5[0]);


                List<string> Cresults6 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select Duration from RentPackages where P_ID = @P_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@P_ID", P_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults6.Add(reader[0].ToString());

                        }
                    }
                }

                duration = Cresults6[0];


                if (duration == "1Dy")
                {
                    fee = validdays * Rental;
                    penaltyfee = invaliddays * Rental * penaltyrate / 100;
                    totalfee = fee + penaltyfee + this.damagefee;
                }
                else if (duration == "7Dys")
                {
                    fee = validdays / 7 * Rental;
                    penaltyfee = invaliddays / 7 * Rental * penaltyrate / 100;
                    totalfee = fee + penaltyfee + this.damagefee;
                }
                else if (duration == "30Dys")
                {
                    fee = validdays / 30 * Rental;
                    penaltyfee = invaliddays / 30 * Rental * penaltyrate / 100;
                    totalfee = fee + penaltyfee + this.damagefee;
                }
                else if (duration == "12Mnths")
                {
                    fee = validdays / 365 * Rental;
                    penaltyfee = invaliddays / 365 * Rental * penaltyrate / 100;
                    totalfee = fee + penaltyfee + this.damagefee;
                }

                using (SqlCommand newcuscmd = new SqlCommand("UPDATE VehicleRent SET ReturnDate = @RD, Active = 0, Rentalfee = @RF, Penaltyfee = @PF, Damagefee = @DF, Totalfee = @TF WHERE Rent_ID = @Rent_ID", DBF.GetSqlCon()))
                {
                    newcuscmd.Parameters.AddWithValue("@RD", this.returndate);
                    newcuscmd.Parameters.AddWithValue("@RF", fee);
                    newcuscmd.Parameters.AddWithValue("@PF", penaltyfee);
                    newcuscmd.Parameters.AddWithValue("@DF", this.damagefee);
                    newcuscmd.Parameters.AddWithValue("@TF", totalfee);
                    newcuscmd.Parameters.AddWithValue("@Rent_ID", Rent_ID);
                    newcuscmd.ExecuteNonQuery();
                }

                RentReceipt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void HireFee(string Hire_ID, string ReturnD, string damagefee, string EM)
        {

            try
            {
                ReceiptNO = Hire_ID;
                this.returndate = ReturnD;
                this.damagefee = double.Parse(damagefee);

                //oilfee = etamilage*oilprice
                //oilfee+
                var startdate = Convert.ToDateTime(this.startdate);
                var enddate = Convert.ToDateTime(this.enddate);
                var returndate = Convert.ToDateTime(this.returndate);

                var validdays = (enddate - startdate).TotalDays;
                var invaliddays = (returndate - enddate).TotalDays;

                List<string> hirerecord = new List<string>();
                DataBaseFunctions DBF = new DataBaseFunctions();
                DBF.conopen();

                using (SqlCommand hirerecordcmd = new SqlCommand("select C_NIC from VehicleHire where Hire_ID = @Hire_ID", DBF.GetSqlCon()))
                {
                    hirerecordcmd.Parameters.AddWithValue("@Hire_ID", Hire_ID);
                    using (SqlDataReader reader = hirerecordcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hirerecord.Add(reader[0].ToString());
                        }
                    }
                }
                C_NIC = hirerecord[0];

                List<string> hirerecordr = new List<string>();
                using (SqlCommand hirerecordcmd = new SqlCommand("select C_NIC from VehicleHire where Hire_ID = @Hire_ID", DBF.GetSqlCon()))
                {
                    hirerecordcmd.Parameters.AddWithValue("@Hire_ID", Hire_ID);
                    using (SqlDataReader reader = hirerecordcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hirerecordr.Add(reader[0].ToString());
                        }
                    }
                }
                R_NIC = hirerecordr[0];

                //making rider available
                using (SqlCommand Rstate = new SqlCommand("UPDATE Rider SET R_State = @R_State WHERE R_NIC = @R_NIC", DBF.GetSqlCon()))
                {
                    Rstate.Parameters.AddWithValue("@R_State", false);
                    Rstate.Parameters.AddWithValue("@R_NIC", R_NIC);
                    Rstate.ExecuteNonQuery();
                }
                //Making vehicle ava
                using (SqlCommand vhstate = new SqlCommand("UPDATE Vehicle SET V_State = @V_State WHERE V_CN = @V_CN", DBF.GetSqlCon()))
                {
                    vhstate.Parameters.AddWithValue("@V_State", false);
                    vhstate.Parameters.AddWithValue("@V_CN", V_CN);
                    vhstate.ExecuteNonQuery();
                }

                List<string> Cresults1 = new List<string>();

                using (SqlCommand CNcmd = new SqlCommand("select C_Name from Customer where C_NIC = @C_NIC", DBF.GetSqlCon()))
                {
                    CNcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                    using (SqlDataReader reader = CNcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults1.Add(reader[0].ToString());
                        }
                    }
                }
                C_NAME = Cresults1[0];

                List<string> Cresults2 = new List<string>();

                using (SqlCommand CTcmd = new SqlCommand("select C_Tel from Customer where C_NIC = @C_NIC", DBF.GetSqlCon()))
                {
                    CTcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                    using (SqlDataReader reader = CTcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults2.Add(reader[0].ToString());
                        }
                    }
                }
                C_Tel = int.Parse(Cresults2[0]);


                List<string> Cresults3 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select C_Address from Customer where C_NIC = @C_NIC", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@C_NIC", C_NIC);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults3.Add(reader[0].ToString());
                        }
                    }
                }
                C_Address = Cresults3[0];


                List<string> Cresults4 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select P_ID from VehicleHire where Hire_ID = @Hire_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@Hire_ID", Hire_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults4.Add(reader[0].ToString());
                        }
                    }
                }
                P_ID = Cresults4[0];


                List<string> Cresults5 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select Rental from RentPackages where P_ID = @P_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@P_ID", P_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults5.Add(reader[0].ToString());
                        }
                    }
                }
                Rental = double.Parse(Cresults5[0]);

                List<string> Cresults6 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select EtaMileage from VehicleHire where Hire_ID = @Hire_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@Hire_ID", Hire_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults6.Add(reader[0].ToString());
                        }
                    }
                }
                ETAmilage = int.Parse(Cresults6[0]);



                List<string> Cresults7 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select PricePerLiter from VehicleHire where Hire_ID = @Hire_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@Hire_ID", Hire_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults7.Add(reader[0].ToString());
                        }
                    }
                }
                PricePerLiter = int.Parse(Cresults7[0]);


                List<string> Cresults8 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select V_CN from VehicleHire where Hire_ID = @Hire_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@Hire_ID", Hire_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults8.Add(reader[0].ToString());
                        }
                    }
                }
                V_CN = Cresults8[0];

                List<string> Cresults9 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select DisPerLiter from Vehicle where V_CN = @V_CN", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@V_CN", V_CN);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults9.Add(reader[0].ToString());
                        }
                    }
                }
                DisPerLiter = int.Parse(Cresults9[0]);


                List<string> Cresults10 = new List<string>();

                using (SqlCommand CAcmd = new SqlCommand("select P_ID from VehicleHire where Hire_ID = @Hire_ID", DBF.GetSqlCon()))
                {
                    CAcmd.Parameters.AddWithValue("@Hire_ID", Hire_ID);
                    using (SqlDataReader reader = CAcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cresults10.Add(reader[0].ToString());
                        }
                    }
                }
                advance = double.Parse(Cresults10[0]);
                oilfee = PricePerLiter * (ETAmilage / DisPerLiter);
                fee = validdays * Rental;
                penaltyfee = invaliddays * Rental * penaltyrate / 100;
                totalfee = fee + penaltyfee + oilfee + this.damagefee - advance;

                HireReceipt();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void HireReceipt()
        {
            html = "<html>\r\n\r\n<head>\r\n    <style>\r\n        body {\r\n            margin-top: 20px;\r\n            color: #484b51;\r\n        }\r\n\r\n        .text-secondary-d1 {\r\n            color: #728299 !important;\r\n        }\r\n\r\n        .page-header {\r\n            margin: 0 0 1rem;\r\n            padding-bottom: 1rem;\r\n            padding-top: .5rem;\r\n            border-bottom: 1px dotted #e2e2e2;\r\n            display: -ms-flexbox;\r\n            display: flex;\r\n            -ms-flex-pack: justify;\r\n            justify-content: space-between;\r\n            -ms-flex-align: center;\r\n            align-items: center;\r\n        }\r\n\r\n        .page-title {\r\n            padding: 0;\r\n            margin: 0;\r\n            font-size: 1.75rem;\r\n            font-weight: 300;\r\n        }\r\n\r\n        .brc-default-l1 {\r\n            border-color: #dce9f0 !important;\r\n        }\r\n\r\n        .ml-n1,\r\n        .mx-n1 {\r\n            margin-left: -.25rem !important;\r\n        }\r\n\r\n        .mr-n1,\r\n        .mx-n1 {\r\n            margin-right: -.25rem !important;\r\n        }\r\n\r\n        .mb-4,\r\n        .my-4 {\r\n            margin-bottom: 1.5rem !important;\r\n        }\r\n\r\n        hr {\r\n            margin-top: 1rem;\r\n            margin-bottom: 1rem;\r\n            border: 0;\r\n            border-top: 1px solid rgba(0, 0, 0, .1);\r\n        }\r\n\r\n        .text-grey-m2 {\r\n            color: #888a8d !important;\r\n        }\r\n\r\n        .text-success-m2 {\r\n            color: #86bd68 !important;\r\n        }\r\n\r\n        .font-bolder,\r\n        .text-600 {\r\n            font-weight: 600 !important;\r\n        }\r\n\r\n        .text-110 {\r\n            font-size: 110% !important;\r\n        }\r\n\r\n        .text-blue {\r\n            color: #478fcc !important;\r\n        }\r\n\r\n        .pb-25,\r\n        .py-25 {\r\n            padding-bottom: .75rem !important;\r\n        }\r\n\r\n        .pt-25,\r\n        .py-25 {\r\n            padding-top: .75rem !important;\r\n        }\r\n\r\n        .bgc-default-tp1 {\r\n            background-color: rgba(121, 169, 197, .92) !important;\r\n        }\r\n\r\n        .bgc-default-l4,\r\n        .bgc-h-default-l4:hover {\r\n            background-color: #f3f8fa !important;\r\n        }\r\n\r\n        .page-header .page-tools {\r\n            -ms-flex-item-align: end;\r\n            align-self: flex-end;\r\n        }\r\n\r\n        .btn-light {\r\n            color: #757984;\r\n            background-color: #f5f6f9;\r\n            border-color: #dddfe4;\r\n        }\r\n\r\n        .w-2 {\r\n            width: 1rem;\r\n        }\r\n\r\n        .text-120 {\r\n            font-size: 120% !important;\r\n        }\r\n\r\n        .text-primary-m1 {\r\n            color: #4087d4 !important;\r\n        }\r\n\r\n        .text-danger-m1 {\r\n            color: #dd4949 !important;\r\n        }\r\n\r\n        .text-blue-m2 {\r\n            color: #68a3d5 !important;\r\n        }\r\n\r\n        .text-150 {\r\n            font-size: 150% !important;\r\n        }\r\n\r\n        .text-60 {\r\n            font-size: 60% !important;\r\n        }\r\n\r\n        .text-grey-m1 {\r\n            color: #7b7d81 !important;\r\n        }\r\n\r\n        .align-bottom {\r\n            vertical-align: bottom !important;\r\n        }\r\n    </style>\r\n        <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css'>\r\n    <title>";
            html += ""+ReceiptNO+"";
            html += "</title>\r\n</head>\r\n\r\n<body>\r\n    <link href='https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet' />\r\n\r\n<div class='page-content container'>\r\n    <div class='page-header text-blue-d2'>\r\n        <h1 class='page-title text-secondary-d1'>\r\n            Invoice\r\n            <small class='page-info'>\r\n                <i class='fa fa-angle-double-right text-80'></i>\r\n                ID: #";
            html += ""+ReceiptNO+"";
            html += "</small>\r\n        </h1>\r\n\r\n        <div class='page-tools'>\r\n            <div class='action-buttons'>\r\n                <a class='btn bg-white btn-light mx-1px text-95' href='#' data-title='Print' onClick=\"window.print()\">\r\n                    <i class='mr-1 fa fa-print text-primary-m1 text-120 w-2'></i>\r\n                    Print\r\n                </a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class='container px-0'>\r\n        <div class='row mt-4'>\r\n            <div class='col-12 col-lg-12'>\r\n                <div class='row'>\r\n                    <div class='col-12'>\r\n                        <div class='text-center text-150'>\r\n                            <span class='text-default-d3'>Vehicle Rental System</span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <!-- .row -->\r\n\r\n                <hr class='row brc-default-l1 mx-n1 mb-4' />\r\n\r\n                <div class='row'>\r\n                    <div class='col-sm-6'>\r\n                        <div>\r\n                            <span class='text-sm text-grey-m2 align-middle'>To:</span>\r\n                            <span class='text-600 text-110 text-blue align-middle'>";
            html += ""+C_NAME+"";
            html += "</span>\r\n                        </div>\r\n                        <div class='text-grey-m2'>\r\n                            <div class='my-1'>";
            html += ""+C_Address+"";
            html += "</div>\r\n                            <div class='my-1'><i class='fa fa-phone fa-flip-horizontal text-secondary'></i> <b class='text-600'>";
            html += "" + C_Tel + "";
            html += "</b></div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /.col -->\r\n\r\n                    <div class='text-95 col-sm-6 align-self-start d-sm-flex justify-content-end'>\r\n                        <hr class='d-sm-none' />\r\n                        <div class='text-grey-m2'>\r\n                            <div class='mt-1 mb-2 text-secondary-m1 text-600 text-125'>\r\n                                Invoice\r\n                            </div>\r\n\r\n                            <div class='my-2'><i class='fa fa-circle text-blue-m2 text-xs mr-1'></i> <span class='text-600 text-90'>ID:</span> #";
            html += "" + ReceiptNO + "";
            html += "</div>\r\n\r\n                            <div class='my-2'><i class='fa fa-circle text-blue-m2 text-xs mr-1'></i> <span class='text-600 text-90'>Issue Date:</span>";
            html += "" + Date + "";
            html += "</div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /.col -->\r\n                </div>\r\n\r\n                <div class='mt-4'>\r\n                    <div class='row text-600 text-white bgc-default-tp1 py-25'>\r\n                        <div class='d-none d-sm-block col-1'>#</div>\r\n                        <div class='col-9 col-sm-5'>Description</div>\r\n                        <div class='d-none d-sm-block col-4 col-sm-2'></div>\r\n                        <div class='d-none d-sm-block col-sm-2'></div>\r\n                        <div class='col-2'>Amount</div>\r\n                    </div>\r\n\r\n                    <div class='text-95 text-secondary-d3'>\r\n                        <div class='row mb-2 mb-sm-0 py-25'>\r\n                            <div class='d-none d-sm-block col-1'>1</div>\r\n                            <div class='col-9 col-sm-5'>Rental Fee</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>";
            html += "" + fee + "";
            html += "</div>\r\n                        </div>\r\n\r\n                        <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                            <div class='d-none d-sm-block col-1'>2</div>\r\n                            <div class='col-9 col-sm-5'>Penalty Fee</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>";
            html += "" + penaltyfee + "";
            html += "</div>\r\n                        </div>\r\n                        <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                            <div class='d-none d-sm-block col-1'>2</div>\r\n                            <div class='col-9 col-sm-5'>Oil Fee</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>";
            html += "" + oilfee + "";
            html += "</div>\r\n                        </div>\r\n                        <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                            <div class='d-none d-sm-block col-1'>3</div>\r\n                            <div class='col-9 col-sm-5'>Damage Fee</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>";
            html += "" + damagefee + "";
            html += "</div>\r\n                        </div>\r\n\r\n                        <!-- <div class='row mb-2 mb-sm-0 py-25'>\r\n                            <div class='d-none d-sm-block col-1'>4</div>\r\n                            <div class='col-9 col-sm-5'>Software development</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>$1,000</div>\r\n                        </div>\r\n\r\n                        <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                            <div class='d-none d-sm-block col-1'>4</div>\r\n                            <div class='col-9 col-sm-5'>Consulting</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>$500</div>\r\n                        </div>\r\n                    </div> -->\r\n\r\n                    <div class='row border-b-2 brc-default-l2'></div>\r\n\r\n                    <!-- or use a table instead -->\r\n                    <!--\r\n            <div class='table-responsive'>\r\n                <table class='table table-striped table-borderless border-0 border-b-2 brc-default-l1'>\r\n                    <thead class='bg-none bgc-default-tp1'>\r\n                        <tr class='text-white'>\r\n                            <th class='opacity-2'>#</th>\r\n                            <th>Description</th>\r\n                            <th>Qty</th>\r\n                            <th>Unit Price</th>\r\n                            <th width='140'>Amount</th>\r\n                        </tr>\r\n                    </thead>\r\n\r\n                    <tbody class='text-95 text-secondary-d3'>\r\n                        <tr></tr>\r\n                        <tr>\r\n                            <td>1</td>\r\n                            <td>Domain registration</td>\r\n                            <td>2</td>\r\n                            <td class='text-95'>$10</td>\r\n                            <td class='text-secondary-d2'>$20</td>\r\n                        </tr> \r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n            -->\r\n\r\n                    <div class='row mt-3'>\r\n                        <div class='col-12 col-sm-7 text-grey-d2 text-95 mt-2 mt-lg-0'>\r\n                            \r\n                        </div>\r\n\r\n                        <!-- <div class='col-12 col-sm-5 text-grey text-90 order-first order-sm-last'>\r\n                            <div class='row my-2'>\r\n                                <div class='col-7 text-right'>\r\n                                    SubTotal\r\n                                </div>\r\n                                <div class='col-5'>\r\n                                    <span class='text-120 text-secondary-d1'>$2,250</span>\r\n                                </div>\r\n                            </div>\r\n\r\n                            <div class='row my-2'>\r\n                                <div class='col-7 text-right'>\r\n                                    Tax (10%)\r\n                                </div>\r\n                                <div class='col-5'>\r\n                                    <span class='text-110 text-secondary-d1'>$225</span>\r\n                                </div>\r\n                            </div>\r\n -->\r\n                            <div class='row my-2 align-items-center bgc-primary-l3 p-2'>\r\n                                <div class='col-7 text-right'>\r\n                                    Total Amount : \r\n                                </div>\r\n                                <div class='col-5'>\r\n                                    <span class='text-150 text-success-d3 opacity-2'>";
            html += "" + totalfee + "";
            html += "</span>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                    <hr />\r\n\r\n                    <div>\r\n                        <span class='text-secondary-d1 text-105'>Thank you for your business</span>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</body>\r\n\r\n</html>";

            HireFileCreator();
        }
         public void RentReceipt()
        { 
            html = "<html>\r\n\r\n<head>\r\n    <style>\r\n        body {\r\n            margin-top: 20px;\r\n            color: #484b51;\r\n        }\r\n\r\n        .text-secondary-d1 {\r\n            color: #728299 !important;\r\n        }\r\n\r\n        .page-header {\r\n            margin: 0 0 1rem;\r\n            padding-bottom: 1rem;\r\n            padding-top: .5rem;\r\n            border-bottom: 1px dotted #e2e2e2;\r\n            display: -ms-flexbox;\r\n            display: flex;\r\n            -ms-flex-pack: justify;\r\n            justify-content: space-between;\r\n            -ms-flex-align: center;\r\n            align-items: center;\r\n        }\r\n\r\n        .page-title {\r\n            padding: 0;\r\n            margin: 0;\r\n            font-size: 1.75rem;\r\n            font-weight: 300;\r\n        }\r\n\r\n        .brc-default-l1 {\r\n            border-color: #dce9f0 !important;\r\n        }\r\n\r\n        .ml-n1,\r\n        .mx-n1 {\r\n            margin-left: -.25rem !important;\r\n        }\r\n\r\n        .mr-n1,\r\n        .mx-n1 {\r\n            margin-right: -.25rem !important;\r\n        }\r\n\r\n        .mb-4,\r\n        .my-4 {\r\n            margin-bottom: 1.5rem !important;\r\n        }\r\n\r\n        hr {\r\n            margin-top: 1rem;\r\n            margin-bottom: 1rem;\r\n            border: 0;\r\n            border-top: 1px solid rgba(0, 0, 0, .1);\r\n        }\r\n\r\n        .text-grey-m2 {\r\n            color: #888a8d !important;\r\n        }\r\n\r\n        .text-success-m2 {\r\n            color: #86bd68 !important;\r\n        }\r\n\r\n        .font-bolder,\r\n        .text-600 {\r\n            font-weight: 600 !important;\r\n        }\r\n\r\n        .text-110 {\r\n            font-size: 110% !important;\r\n        }\r\n\r\n        .text-blue {\r\n            color: #478fcc !important;\r\n        }\r\n\r\n        .pb-25,\r\n        .py-25 {\r\n            padding-bottom: .75rem !important;\r\n        }\r\n\r\n        .pt-25,\r\n        .py-25 {\r\n            padding-top: .75rem !important;\r\n        }\r\n\r\n        .bgc-default-tp1 {\r\n            background-color: rgba(121, 169, 197, .92) !important;\r\n        }\r\n\r\n        .bgc-default-l4,\r\n        .bgc-h-default-l4:hover {\r\n            background-color: #f3f8fa !important;\r\n        }\r\n\r\n        .page-header .page-tools {\r\n            -ms-flex-item-align: end;\r\n            align-self: flex-end;\r\n        }\r\n\r\n        .btn-light {\r\n            color: #757984;\r\n            background-color: #f5f6f9;\r\n            border-color: #dddfe4;\r\n        }\r\n\r\n        .w-2 {\r\n            width: 1rem;\r\n        }\r\n\r\n        .text-120 {\r\n            font-size: 120% !important;\r\n        }\r\n\r\n        .text-primary-m1 {\r\n            color: #4087d4 !important;\r\n        }\r\n\r\n        .text-danger-m1 {\r\n            color: #dd4949 !important;\r\n        }\r\n\r\n        .text-blue-m2 {\r\n            color: #68a3d5 !important;\r\n        }\r\n\r\n        .text-150 {\r\n            font-size: 150% !important;\r\n        }\r\n\r\n        .text-60 {\r\n            font-size: 60% !important;\r\n        }\r\n\r\n        .text-grey-m1 {\r\n            color: #7b7d81 !important;\r\n        }\r\n\r\n        .align-bottom {\r\n            vertical-align: bottom !important;\r\n        }\r\n    </style>\r\n        <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css'>\r\n    <title>";
            html += "" + ReceiptNO + "";
            html += "</title>\r\n</head>\r\n\r\n<body>\r\n    <link href='https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet' />\r\n\r\n<div class='page-content container'>\r\n    <div class='page-header text-blue-d2'>\r\n        <h1 class='page-title text-secondary-d1'>\r\n            Invoice\r\n            <small class='page-info'>\r\n                <i class='fa fa-angle-double-right text-80'></i>\r\n                ID: #";
            html += "" + ReceiptNO + "";
            html += "</small>\r\n        </h1>\r\n\r\n        <div class='page-tools'>\r\n            <div class='action-buttons'>\r\n                <a class='btn bg-white btn-light mx-1px text-95' href='#' data-title='Print' onClick=\"window.print()\">\r\n                    <i class='mr-1 fa fa-print text-primary-m1 text-120 w-2'></i>\r\n                    Print\r\n                </a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class='container px-0'>\r\n        <div class='row mt-4'>\r\n            <div class='col-12 col-lg-12'>\r\n                <div class='row'>\r\n                    <div class='col-12'>\r\n                        <div class='text-center text-150'>\r\n                           <span class='text-default-d3'>Vehicle Rental System</span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <!-- .row -->\r\n\r\n                <hr class='row brc-default-l1 mx-n1 mb-4' />\r\n\r\n                <div class='row'>\r\n                    <div class='col-sm-6'>\r\n                        <div>\r\n                            <span class='text-sm text-grey-m2 align-middle'>To:</span>\r\n                            <span class='text-600 text-110 text-blue align-middle'>";
            html += "" + C_NAME + "";
            html += "</span>\r\n                        </div>\r\n                        <div class='text-grey-m2'>\r\n                            <div class='my-1'>";
            html += "" + C_Address + "";
            html += "</div>\r\n                            <div class='my-1'><i class='fa fa-phone fa-flip-horizontal text-secondary'></i> <b class='text-600'>";
            html += "" + C_Tel + "";
            html += "</b></div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /.col -->\r\n\r\n                    <div class='text-95 col-sm-6 align-self-start d-sm-flex justify-content-end'>\r\n                        <hr class='d-sm-none' />\r\n                        <div class='text-grey-m2'>\r\n                            <div class='mt-1 mb-2 text-secondary-m1 text-600 text-125'>\r\n                                Invoice\r\n                            </div>\r\n\r\n                            <div class='my-2'><i class='fa fa-circle text-blue-m2 text-xs mr-1'></i> <span class='text-600 text-90'>ID:</span> #";
            html += "" + ReceiptNO + "";
            html += "</div>\r\n\r\n                            <div class='my-2'><i class='fa fa-circle text-blue-m2 text-xs mr-1'></i> <span class='text-600 text-90'>Issue Date:</span>";
            html += "" + Date + "";
            html += "</div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /.col -->\r\n                </div>\r\n\r\n                <div class='mt-4'>\r\n                    <div class='row text-600 text-white bgc-default-tp1 py-25'>\r\n                        <div class='d-none d-sm-block col-1'>#</div>\r\n                        <div class='col-9 col-sm-5'>Description</div>\r\n                        <div class='d-none d-sm-block col-4 col-sm-2'></div>\r\n                        <div class='d-none d-sm-block col-sm-2'></div>\r\n                        <div class='col-2'>Amount</div>\r\n                    </div>\r\n\r\n                    <div class='text-95 text-secondary-d3'>\r\n                        <div class='row mb-2 mb-sm-0 py-25'>\r\n                            <div class='d-none d-sm-block col-1'>1</div>\r\n                            <div class='col-9 col-sm-5'>Rental Fee</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>";
            html += "" + fee + "";
            html += "</div>\r\n                        </div>\r\n\r\n                        <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                            <div class='d-none d-sm-block col-1'>2</div>\r\n                            <div class='col-9 col-sm-5'>Penalty Fee</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>";
            html += "" + penaltyfee + "";
            html += "</div>\r\n                        </div>\r\n                        \r\n                        <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                            <div class='d-none d-sm-block col-1'>3</div>\r\n                            <div class='col-9 col-sm-5'>Damage Fee</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>";
            html += "" + damagefee + "";
            html += "</div>\r\n                        </div>\r\n\r\n                        <!-- <div class='row mb-2 mb-sm-0 py-25'>\r\n                            <div class='d-none d-sm-block col-1'>3</div>\r\n                            <div class='col-9 col-sm-5'>Software development</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>$1,000</div>\r\n                        </div>\r\n\r\n                        <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                            <div class='d-none d-sm-block col-1'>4</div>\r\n                            <div class='col-9 col-sm-5'>Consulting</div>\r\n                            <div class='d-none d-sm-block col-2'></div>\r\n                            <div class='d-none d-sm-block col-2 text-95'></div>\r\n                            <div class='col-2 text-secondary-d2'>$500</div>\r\n                        </div>\r\n                    </div> -->\r\n\r\n                    <div class='row border-b-2 brc-default-l2'></div>\r\n\r\n                    <!-- or use a table instead -->\r\n                    <!--\r\n            <div class='table-responsive'>\r\n                <table class='table table-striped table-borderless border-0 border-b-2 brc-default-l1'>\r\n                    <thead class='bg-none bgc-default-tp1'>\r\n                        <tr class='text-white'>\r\n                            <th class='opacity-2'>#</th>\r\n                            <th>Description</th>\r\n                            <th>Qty</th>\r\n                            <th>Unit Price</th>\r\n                            <th width='140'>Amount</th>\r\n                        </tr>\r\n                    </thead>\r\n\r\n                    <tbody class='text-95 text-secondary-d3'>\r\n                        <tr></tr>\r\n                        <tr>\r\n                            <td>1</td>\r\n                            <td>Domain registration</td>\r\n                            <td>2</td>\r\n                            <td class='text-95'>$10</td>\r\n                            <td class='text-secondary-d2'>$20</td>\r\n                        </tr> \r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n            -->\r\n\r\n                    <div class='row mt-3'>\r\n                        <div class='col-12 col-sm-7 text-grey-d2 text-95 mt-2 mt-lg-0'>\r\n                            \r\n                        </div>\r\n\r\n                        <!-- <div class='col-12 col-sm-5 text-grey text-90 order-first order-sm-last'>\r\n                            <div class='row my-2'>\r\n                                <div class='col-7 text-right'>\r\n                                    SubTotal\r\n                                </div>\r\n                                <div class='col-5'>\r\n                                    <span class='text-120 text-secondary-d1'>$2,250</span>\r\n                                </div>\r\n                            </div>\r\n\r\n                            <div class='row my-2'>\r\n                                <div class='col-7 text-right'>\r\n                                    Tax (10%)\r\n                                </div>\r\n                                <div class='col-5'>\r\n                                    <span class='text-110 text-secondary-d1'>$225</span>\r\n                                </div>\r\n                            </div>\r\n -->\r\n                            <div class='row my-2 align-items-center bgc-primary-l3 p-2'>\r\n                                <div class='col-7 text-right'>\r\n                                    Total Amount : \r\n                                </div>\r\n                                <div class='col-5'>\r\n                                    <span class='text-150 text-success-d3 opacity-2'>";
            html += "" + totalfee + "";
            html += "</span>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                    <hr />\r\n\r\n                    <div>\r\n                        <span class='text-secondary-d1 text-105'>Thank you for your business</span>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</body>\r\n\r\n</html>";


            RentFileCreator();
         }

        public void RentFileCreator()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    String FileName = System.IO.Path.Combine(dialog.SelectedPath, ReceiptNO + "RPAY.htm");
                    File.WriteAllText(FileName, html);


                    Process fileopener = new Process();
                    fileopener.StartInfo.FileName = "msedge";
                    fileopener.StartInfo.Arguments = "\""+FileName+"\"";
                    fileopener.Start();
                }
            }

        }
        public void HireFileCreator()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    String FileName = System.IO.Path.Combine(dialog.SelectedPath, ReceiptNO + "HPAY.htm");
                    File.WriteAllText(FileName, html);


                    Process fileopener = new Process();
                    fileopener.StartInfo.FileName = "msedge";
                    fileopener.StartInfo.Arguments = "\"" + FileName + "\"";
                    fileopener.Start();
                }
            }

        }
    }
}
