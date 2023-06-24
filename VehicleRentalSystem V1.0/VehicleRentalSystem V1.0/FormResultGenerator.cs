using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace VehicleRentalSystem_V1._0
{
    internal class FormResultGenerator
    {
        private string html, ID;

        public void generateRentformresult(List<string> Data)
        {

            this.ID = Data[0];
            string C_NIC = Data[1];
            string C_Name = Data[2];
            string C_Add = Data[3];
            string C_Tel = Data[4];
            string V_CN = Data[5];
            string StartD = Data[6];
            string EndD = Data[7];
            string P_Name = Data[8];


            html = "<html>\r\n\r\n<head>\r\n    <style>\r\n        body {\r\n            margin-top: 20px;\r\n            color: #484b51;\r\n        }\r\n\r\n        .text-secondary-d1 {\r\n            color: #728299 !important;\r\n        }\r\n\r\n        .page-header {\r\n            margin: 0 0 1rem;\r\n            padding-bottom: 1rem;\r\n            padding-top: .5rem;\r\n            border-bottom: 1px dotted #e2e2e2;\r\n            display: -ms-flexbox;\r\n            display: flex;\r\n            -ms-flex-pack: justify;\r\n            justify-content: space-between;\r\n            -ms-flex-align: center;\r\n            align-items: center;\r\n        }\r\n\r\n        .page-title {\r\n            padding: 0;\r\n            margin: 0;\r\n            font-size: 1.75rem;\r\n            font-weight: 300;\r\n        }\r\n\r\n        .brc-default-l1 {\r\n            border-color: #dce9f0 !important;\r\n        }\r\n\r\n        .ml-n1,\r\n        .mx-n1 {\r\n            margin-left: -.25rem !important;\r\n        }\r\n\r\n        .mr-n1,\r\n        .mx-n1 {\r\n            margin-right: -.25rem !important;\r\n        }\r\n\r\n        .mb-4,\r\n        .my-4 {\r\n            margin-bottom: 1.5rem !important;\r\n        }\r\n\r\n        hr {\r\n            margin-top: 1rem;\r\n            margin-bottom: 1rem;\r\n            border: 0;\r\n            border-top: 1px solid rgba(0, 0, 0, .1);\r\n        }\r\n\r\n        .text-grey-m2 {\r\n            color: #888a8d !important;\r\n        }\r\n\r\n        .text-success-m2 {\r\n            color: #86bd68 !important;\r\n        }\r\n\r\n        .font-bolder,\r\n        .text-600 {\r\n            font-weight: 600 !important;\r\n        }\r\n\r\n        .text-110 {\r\n            font-size: 110% !important;\r\n        }\r\n\r\n        .text-blue {\r\n            color: #478fcc !important;\r\n        }\r\n\r\n        .pb-25,\r\n        .py-25 {\r\n            padding-bottom: .75rem !important;\r\n        }\r\n\r\n        .pt-25,\r\n        .py-25 {\r\n            padding-top: .75rem !important;\r\n        }\r\n\r\n        .bgc-default-tp1 {\r\n            background-color: rgba(121, 169, 197, .92) !important;\r\n        }\r\n\r\n        .bgc-default-l4,\r\n        .bgc-h-default-l4:hover {\r\n            background-color: #f3f8fa !important;\r\n        }\r\n\r\n        .page-header .page-tools {\r\n            -ms-flex-item-align: end;\r\n            align-self: flex-end;\r\n        }\r\n\r\n        .btn-light {\r\n            color: #757984;\r\n            background-color: #f5f6f9;\r\n            border-color: #dddfe4;\r\n        }\r\n\r\n        .w-2 {\r\n            width: 1rem;\r\n        }\r\n\r\n        .text-120 {\r\n            font-size: 120% !important;\r\n        }\r\n\r\n        .text-primary-m1 {\r\n            color: #4087d4 !important;\r\n        }\r\n\r\n        .text-danger-m1 {\r\n            color: #dd4949 !important;\r\n        }\r\n\r\n        .text-blue-m2 {\r\n            color: #68a3d5 !important;\r\n        }\r\n\r\n        .text-150 {\r\n            font-size: 150% !important;\r\n        }\r\n\r\n        .text-60 {\r\n            font-size: 60% !important;\r\n        }\r\n\r\n        .text-grey-m1 {\r\n            color: #7b7d81 !important;\r\n        }\r\n\r\n        .align-bottom {\r\n            vertical-align: bottom !important;\r\n        }\r\n    </style>\r\n    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css'>\r\n    <title>";
            html += "" + ID + "";
            html += "</title>\r\n</head>\r\n\r\n<body>\r\n    <link href='https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet' />\r\n\r\n    <div class='page-content container'>\r\n        <div class='page-header text-blue-d2'>\r\n            <h1 class='page-title text-secondary-d1'>\r\n                Invoice\r\n                <small class='page-info'>\r\n                    <i class='fa fa-angle-double-right text-80'></i>\r\n                    ID: #";
            html += "" + ID + "";
            html += "</small>\r\n            </h1>\r\n\r\n            <div class='page-tools'>\r\n                <div class='action-buttons'>\r\n                    <a class='btn bg-white btn-light mx-1px text-95' href='#' data-title='Print'\r\n                        onClick=\"window.print()\">\r\n                        <i class='mr-1 fa fa-print text-primary-m1 text-120 w-2'></i>\r\n                        Print\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class='container px-0'>\r\n            <div class='row mt-4'>\r\n                <div class='col-12 col-lg-12'>\r\n                    <div class='row'>\r\n                        <div class='col-12'>\r\n                            <div class='text-center text-150'>\r\n                                <span class='text-default-d3'>Vehicle Rental System</span>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- .row -->\r\n\r\n                    <hr class='row brc-default-l1 mx-n1 mb-4' />\r\n\r\n                    <div class='row'>\r\n                        <div class='col-sm-6'>\r\n                            <div>\r\n                                <span class='text-sm text-grey-m2 align-middle'>To:</span>\r\n                                <span class='text-600 text-110 text-blue align-middle'>";
            html += "" + C_Name + "";
            html += "</span>\r\n                            </div>\r\n                            <div class='text-grey-m2'>\r\n                                <div class='my-1'>\r\n                                    ";
            html += "" + C_Add + "";
            html += "</div>\r\n                                <div class='my-1'><i class='fa fa-phone fa-flip-horizontal text-secondary'></i> <b\r\n                                        class='text-600'>";
            html += "" + C_Tel + "";
            html += "</b></div>\r\n                            </div>\r\n                        </div>\r\n                        <!-- /.col -->\r\n\r\n                        <div class='text-95 col-sm-6 align-self-start d-sm-flex justify-content-end'>\r\n                            <hr class='d-sm-none' />\r\n                            <div class='text-grey-m2'>\r\n                                <div class='mt-1 mb-2 text-secondary-m1 text-600 text-125'>\r\n                                    Invoice\r\n                                </div>\r\n\r\n                                <div class='my-2'><i class='fa fa-circle text-blue-m2 text-xs mr-1'></i> <span\r\n                                        class='text-600 text-90'>ID:</span> #";
            html += "" + ID + "";
            html += "</div>\r\n\r\n                                <div class='my-2'><i class='fa fa-circle text-blue-m2 text-xs mr-1'></i> <span\r\n                                        class='text-600 text-90'>Issue Date:</span>";
            html += "" + StartD + "";
            html += "</div>\r\n                            </div>\r\n                        </div>\r\n                        <!-- /.col -->\r\n                    </div>\r\n\r\n                    <div class='mt-4'>\r\n                        <div class='row text-600 text-white bgc-default-tp1 py-25'>\r\n                            <div class='d-none d-sm-block col-1'>#</div>\r\n                            <div class='col-9 col-sm-5'>Description</div>\r\n                            <div class='d-none d-sm-block col-4 col-sm-2'></div>\r\n                            <div class='d-none d-sm-block col-sm-2'></div>\r\n                            <div class='col-2'>Value</div>\r\n                        </div>\r\n\r\n                        <div class='text-95 text-secondary-d3'>\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>1</div>\r\n                                <div class='col-9 col-sm-5'>Start Date</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += "" + StartD + "";
            html += "</div>\r\n                            </div>\r\n\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>2</div>\r\n                                <div class='col-9 col-sm-5'>End Date</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += "" + EndD + "";
            html += "</div>\r\n                            </div>\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>3</div>\r\n                                <div class='col-9 col-sm-5'>Package Name</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += ""+P_Name+"";
            html += "</div>\r\n                            </div>\r\n                        \r\n\r\n\r\n\r\n                                <div class='row border-b-2 brc-default-l2'></div>\r\n                                <br>\r\n                                <div class='row mt-3'>\r\n                                    <div class='col-12 col-m-7 text-grey-d2 text-95 mt-2 mt-lg-0'>\r\n                                        <br>Delayed Returns Will Cause Extra Charges...\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n\r\n</html>";

            FileCreator();
        }


        public void generateHireformresult(List<string> Data)
        {
            DataBaseFunctions DBF = new DataBaseFunctions();
            DBF.conopen();

            this.ID = Data[0];
            string C_NIC = Data[1];
            string C_Name = Data[2];
            string C_Add = Data[3];
            string C_Tel = Data[4];
            string V_CN = Data[5];
            string StartD = Data[6];
            string SMil = Data[7];
            string ETAM = Data[8];
            string EndD = Data[9];
            string R_NIC = Data[10];
            double PPLiter = double.Parse(Data[11]);
            double ADPay = double.Parse(Data[12]);


            html = "<html>\r\n\r\n<head>\r\n    <style>\r\n        body {\r\n            margin-top: 20px;\r\n            color: #484b51;\r\n        }\r\n\r\n        .text-secondary-d1 {\r\n            color: #728299 !important;\r\n        }\r\n\r\n        .page-header {\r\n            margin: 0 0 1rem;\r\n            padding-bottom: 1rem;\r\n            padding-top: .5rem;\r\n            border-bottom: 1px dotted #e2e2e2;\r\n            display: -ms-flexbox;\r\n            display: flex;\r\n            -ms-flex-pack: justify;\r\n            justify-content: space-between;\r\n            -ms-flex-align: center;\r\n            align-items: center;\r\n        }\r\n\r\n        .page-title {\r\n            padding: 0;\r\n            margin: 0;\r\n            font-size: 1.75rem;\r\n            font-weight: 300;\r\n        }\r\n\r\n        .brc-default-l1 {\r\n            border-color: #dce9f0 !important;\r\n        }\r\n\r\n        .ml-n1,\r\n        .mx-n1 {\r\n            margin-left: -.25rem !important;\r\n        }\r\n\r\n        .mr-n1,\r\n        .mx-n1 {\r\n            margin-right: -.25rem !important;\r\n        }\r\n\r\n        .mb-4,\r\n        .my-4 {\r\n            margin-bottom: 1.5rem !important;\r\n        }\r\n\r\n        hr {\r\n            margin-top: 1rem;\r\n            margin-bottom: 1rem;\r\n            border: 0;\r\n            border-top: 1px solid rgba(0, 0, 0, .1);\r\n        }\r\n\r\n        .text-grey-m2 {\r\n            color: #888a8d !important;\r\n        }\r\n\r\n        .text-success-m2 {\r\n            color: #86bd68 !important;\r\n        }\r\n\r\n        .font-bolder,\r\n        .text-600 {\r\n            font-weight: 600 !important;\r\n        }\r\n\r\n        .text-110 {\r\n            font-size: 110% !important;\r\n        }\r\n\r\n        .text-blue {\r\n            color: #478fcc !important;\r\n        }\r\n\r\n        .pb-25,\r\n        .py-25 {\r\n            padding-bottom: .75rem !important;\r\n        }\r\n\r\n        .pt-25,\r\n        .py-25 {\r\n            padding-top: .75rem !important;\r\n        }\r\n\r\n        .bgc-default-tp1 {\r\n            background-color: rgba(121, 169, 197, .92) !important;\r\n        }\r\n\r\n        .bgc-default-l4,\r\n        .bgc-h-default-l4:hover {\r\n            background-color: #f3f8fa !important;\r\n        }\r\n\r\n        .page-header .page-tools {\r\n            -ms-flex-item-align: end;\r\n            align-self: flex-end;\r\n        }\r\n\r\n        .btn-light {\r\n            color: #757984;\r\n            background-color: #f5f6f9;\r\n            border-color: #dddfe4;\r\n        }\r\n\r\n        .w-2 {\r\n            width: 1rem;\r\n        }\r\n\r\n        .text-120 {\r\n            font-size: 120% !important;\r\n        }\r\n\r\n        .text-primary-m1 {\r\n            color: #4087d4 !important;\r\n        }\r\n\r\n        .text-danger-m1 {\r\n            color: #dd4949 !important;\r\n        }\r\n\r\n        .text-blue-m2 {\r\n            color: #68a3d5 !important;\r\n        }\r\n\r\n        .text-150 {\r\n            font-size: 150% !important;\r\n        }\r\n\r\n        .text-60 {\r\n            font-size: 60% !important;\r\n        }\r\n\r\n        .text-grey-m1 {\r\n            color: #7b7d81 !important;\r\n        }\r\n\r\n        .align-bottom {\r\n            vertical-align: bottom !important;\r\n        }\r\n    </style>\r\n    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css'>\r\n    <title>";
            html += ""+ID+"";
            html += "</title>\r\n</head>\r\n\r\n<body>\r\n    <link href='https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet' />\r\n\r\n    <div class='page-content container'>\r\n        <div class='page-header text-blue-d2'>\r\n            <h1 class='page-title text-secondary-d1'>\r\n                Invoice\r\n                <small class='page-info'>\r\n                    <i class='fa fa-angle-double-right text-80'></i>\r\n                    ID: #";
            html += ""+ID+"";
            html += "</small>\r\n            </h1>\r\n\r\n            <div class='page-tools'>\r\n                <div class='action-buttons'>\r\n                    <a class='btn bg-white btn-light mx-1px text-95' href='#' data-title='Print'\r\n                        onClick=\"window.print()\">\r\n                        <i class='mr-1 fa fa-print text-primary-m1 text-120 w-2'></i>\r\n                        Print\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class='container px-0'>\r\n            <div class='row mt-4'>\r\n                <div class='col-12 col-lg-12'>\r\n                    <div class='row'>\r\n                        <div class='col-12'>\r\n                            <div class='text-center text-150'>\r\n                                <span class='text-default-d3'>Vehicle Rental System</span>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- .row -->\r\n\r\n                    <hr class='row brc-default-l1 mx-n1 mb-4' />\r\n\r\n                    <div class='row'>\r\n                        <div class='col-sm-6'>\r\n                            <div>\r\n                                <span class='text-sm text-grey-m2 align-middle'>To:</span>\r\n                                <span class='text-600 text-110 text-blue align-middle'>";
            html += ""+C_Name+"";
            html += "</span>\r\n                            </div>\r\n                            <div class='text-grey-m2'>\r\n                                <div class='my-1'>\r\n                                    ";
            html += ""+C_Add+"";
            html += "</div>\r\n                                <div class='my-1'><i class='fa fa-phone fa-flip-horizontal text-secondary'></i> <b\r\n                                        class='text-600'>";
            html += ""+C_Tel+"";
            html += "</b></div>\r\n                            </div>\r\n                        </div>\r\n                        <!-- /.col -->\r\n\r\n                        <div class='text-95 col-sm-6 align-self-start d-sm-flex justify-content-end'>\r\n                            <hr class='d-sm-none' />\r\n                            <div class='text-grey-m2'>\r\n                                <div class='mt-1 mb-2 text-secondary-m1 text-600 text-125'>\r\n                                    Invoice\r\n                                </div>\r\n\r\n                                <div class='my-2'><i class='fa fa-circle text-blue-m2 text-xs mr-1'></i> <span\r\n                                        class='text-600 text-90'>ID:</span> #";
            html += ""+ID+"";
            html += "</div>\r\n\r\n                                <div class='my-2'><i class='fa fa-circle text-blue-m2 text-xs mr-1'></i> <span\r\n                                        class='text-600 text-90'>Issue Date:</span>";
            html += ""+StartD+"";
            html += "</div>\r\n                            </div>\r\n                        </div>\r\n                        <!-- /.col -->\r\n                    </div>\r\n\r\n                    <div class='mt-4'>\r\n                        <div class='row text-600 text-white bgc-default-tp1 py-25'>\r\n                            <div class='d-none d-sm-block col-1'>#</div>\r\n                            <div class='col-9 col-sm-5'>Description</div>\r\n                            <div class='d-none d-sm-block col-4 col-sm-2'></div>\r\n                            <div class='d-none d-sm-block col-sm-2'></div>\r\n                            <div class='col-2'>Value</div>\r\n                        </div>\r\n\r\n                        <div class='text-95 text-secondary-d3'>\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>1</div>\r\n                                <div class='col-9 col-sm-5'>Start Date</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += ""+StartD+"";
            html += "</div>\r\n                            </div>\r\n\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>2</div>\r\n                                <div class='col-9 col-sm-5'>End Date</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += ""+EndD+"";
            html += "</div>\r\n                            </div>\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>3</div>\r\n                                <div class='col-9 col-sm-5'>Start Mileage</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += ""+SMil+"";
            html += "</div>\r\n                            </div>\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>4</div>\r\n                                <div class='col-9 col-sm-5'>ETA Mileage</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += ""+ETAM+"";
            html += "</div>\r\n                            </div>\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>5</div>\r\n                                <div class='col-9 col-sm-5'>Rider NIC</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += ""+R_NIC+"";
            html += "</div>\r\n                            </div>\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>6</div>\r\n                                <div class='col-9 col-sm-5'>Vehicle Chassis NO</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += ""+V_CN+"";
            html += "</div>\r\n                            </div>\r\n                            <div class='row mb-2 mb-sm-0 py-25 bgc-default-l4'>\r\n                                <div class='d-none d-sm-block col-1'>7</div>\r\n                                <div class='col-9 col-sm-5'>Oil Price per Liter</div>\r\n                                <div class='d-none d-sm-block col-2'></div>\r\n                                <div class='d-none d-sm-block col-2 text-95'></div>\r\n                                <div class='col-2 text-secondary-d2'>";
            html += ""+PPLiter+"";
            html += "</div>\r\n                                <div />\r\n\r\n\r\n\r\n                                <div class='row border-b-2 brc-default-l2'></div>\r\n                                <br>\r\n                                <div class='row mt-3'>\r\n                                    <div class='col-5'>\r\n                                        <span class='text-120 text-success-d3 opacity-2'>Advance Amount : ";
            html += " "+ADPay+" RS";
            html += "</span>\r\n                                    </div>\r\n                                    <div class='col-12 col-m-7 text-grey-d2 text-95 mt-2 mt-lg-0'>\r\n                                        <br>Delayed Returns Will Cause Extra Charges...\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</body>\r\n\r\n</html>";

            FileCreator();

        }
        public void FileCreator()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    String FileName = System.IO.Path.Combine(dialog.SelectedPath, ID + "INFO.htm");
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
