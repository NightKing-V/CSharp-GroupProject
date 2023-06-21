using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem_V1._0
{
    internal class ReceiptGenarator
    {
        private string startdate, enddate, returndate, duration, ReceiptNO, C_NAME, C_Address, Date;
        private double Rental, fee, penaltyfee, totalfee;
        private int penaltyrate, DisperLiter, ETAmilage;
        public void RentFee()
        {
            var startdate = Convert.ToDateTime(this.startdate);
            var enddate = Convert.ToDateTime(this.enddate);
            var returndate = Convert.ToDateTime(this.returndate);

            var validdays = (enddate - startdate).TotalDays;
            var invaliddays = (returndate - enddate).TotalDays;

            if (duration == "1Dy") 
            {
                fee = validdays * Rental;
                penaltyfee = invaliddays * Rental * penaltyrate / 100;
                totalfee = fee + penaltyfee;
            }
            else if (duration == "7Dys") 
            {
                fee = validdays / 7 * Rental;
                penaltyfee = invaliddays / 7 * Rental * penaltyrate / 100;
                totalfee = fee + penaltyfee;
            }
            else if (duration == "30Dys")
            {
                fee = validdays / 30 * Rental;
                penaltyfee = invaliddays / 30 * Rental * penaltyrate / 100;
                totalfee = fee + penaltyfee;
            }
            else if (duration == "12Mnths")
            {
                fee = validdays / 365 * Rental;
                penaltyfee = invaliddays / 365 * Rental * penaltyrate / 100;
                totalfee = fee + penaltyfee;
            }
        }
        public void HireFee()
        {
            //oilfee = etamilage*oilprice
            //oilfee+
            var startdate = Convert.ToDateTime(this.startdate);
            var enddate = Convert.ToDateTime(this.enddate);
            var returndate = Convert.ToDateTime(this.returndate);

            var validdays = (enddate - startdate).TotalDays;
            var invaliddays = (returndate - enddate).TotalDays;

            double oilfee = DisperLiter * ETAmilage;
            double fee = validdays * Rental;
            double penaltyfee = invaliddays * Rental * penaltyrate / 100;
            double totalfee = fee + penaltyfee + oilfee;

        }
        public void HireReceipt()
        {
            string html = "<html>\r\n\r\n<head>\r\n    <style>\r\n        body {\r\n            margin-top: 20px;\r\n            color: #484b51;\r\n        }\r\n\r\n        .text-secondary-d1 {\r\n            color: #728299 !important;\r\n        }\r\n\r\n        .page-header {\r\n            margin: 0 0 1rem;\r\n            padding-bottom: 1rem;\r\n            padding-top: .5rem;\r\n            border-bottom: 1px dotted #e2e2e2;\r\n            display: -ms-flexbox;\r\n            display: flex;\r\n            -ms-flex-pack: justify;\r\n            justify-content: space-between;\r\n            -ms-flex-align: center;\r\n            align-items: center;\r\n        }\r\n\r\n        .page-title {\r\n            padding: 0;\r\n            margin: 0;\r\n            font-size: 1.75rem;\r\n            font-weight: 300;\r\n        }\r\n\r\n        .brc-default-l1 {\r\n            border-color: #dce9f0 !important;\r\n        }\r\n\r\n        .ml-n1,\r\n        .mx-n1 {\r\n            margin-left: -.25rem !important;\r\n        }\r\n\r\n        .mr-n1,\r\n        .mx-n1 {\r\n            margin-right: -.25rem !important;\r\n        }\r\n\r\n        .mb-4,\r\n        .my-4 {\r\n            margin-bottom: 1.5rem !important;\r\n        }\r\n\r\n        hr {\r\n            margin-top: 1rem;\r\n            margin-bottom: 1rem;\r\n            border: 0;\r\n            border-top: 1px solid rgba(0, 0, 0, .1);\r\n        }\r\n\r\n        .text-grey-m2 {\r\n            color: #888a8d !important;\r\n        }\r\n\r\n        .text-success-m2 {\r\n            color: #86bd68 !important;\r\n        }\r\n\r\n        .font-bolder,\r\n        .text-600 {\r\n            font-weight: 600 !important;\r\n        }\r\n\r\n        .text-110 {\r\n            font-size: 110% !important;\r\n        }\r\n\r\n        .text-blue {\r\n            color: #478fcc !important;\r\n        }\r\n\r\n        .pb-25,\r\n        .py-25 {\r\n            padding-bottom: .75rem !important;\r\n        }\r\n\r\n        .pt-25,\r\n        .py-25 {\r\n            padding-top: .75rem !important;\r\n        }\r\n\r\n        .bgc-default-tp1 {\r\n            background-color: rgba(121, 169, 197, .92) !important;\r\n        }\r\n\r\n        .bgc-default-l4,\r\n        .bgc-h-default-l4:hover {\r\n            background-color: #f3f8fa !important;\r\n        }\r\n\r\n        .page-header .page-tools {\r\n            -ms-flex-item-align: end;\r\n            align-self: flex-end;\r\n        }\r\n\r\n        .btn-light {\r\n            color: #757984;\r\n            background-color: #f5f6f9;\r\n            border-color: #dddfe4;\r\n        }\r\n\r\n        .w-2 {\r\n            width: 1rem;\r\n        }\r\n\r\n        .text-120 {\r\n            font-size: 120% !important;\r\n        }\r\n\r\n        .text-primary-m1 {\r\n            color: #4087d4 !important;\r\n        }\r\n\r\n        .text-danger-m1 {\r\n            color: #dd4949 !important;\r\n        }\r\n\r\n        .text-blue-m2 {\r\n            color: #68a3d5 !important;\r\n        }\r\n\r\n        .text-150 {\r\n            font-size: 150% !important;\r\n        }\r\n\r\n        .text-60 {\r\n            font-size: 60% !important;\r\n        }\r\n\r\n        .text-grey-m1 {\r\n            color: #7b7d81 !important;\r\n        }\r\n\r\n        .align-bottom {\r\n            vertical-align: bottom !important;\r\n        }\r\n    </style>\r\n        <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css'>\r\n    <title>";
            html += ""+ReceiptNO+"";
            html += "</title>\r\n</head>\r\n\r\n<body>\r\n    <link href='https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet' />\r\n\r\n<div class='page-content container'>\r\n    <div class='page-header text-blue-d2'>\r\n        <h1 class='page-title text-secondary-d1'>\r\n            Invoice\r\n            <small class='page-info'>\r\n                <i class='fa fa-angle-double-right text-80'></i>\r\n                ID: #";
            html += ""+ReceiptNO+"";
            html += "</small>\r\n        </h1>\r\n\r\n        <div class='page-tools'>\r\n            <div class='action-buttons'>\r\n                <a class='btn bg-white btn-light mx-1px text-95' href='#' data-title='Print' onClick=\"window.print()\">\r\n                    <i class='mr-1 fa fa-print text-primary-m1 text-120 w-2'></i>\r\n                    Print\r\n                </a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class='container px-0'>\r\n        <div class='row mt-4'>\r\n            <div class='col-12 col-lg-12'>\r\n                <div class='row'>\r\n                    <div class='col-12'>\r\n                        <div class='text-center text-150'>\r\n                            <i class='fa fa-book fa-2x text-success-m2 mr-1'></i>\r\n                            <span class='text-default-d3'>Vehicle Rental System</span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <!-- .row -->\r\n\r\n                <hr class='row brc-default-l1 mx-n1 mb-4' />\r\n\r\n                <div class='row'>\r\n                    <div class='col-sm-6'>\r\n                        <div>\r\n                            <span class='text-sm text-grey-m2 align-middle'>To:</span>\r\n                            <span class='text-600 text-110 text-blue align-middle'>";
            html += ""+C_NAME+"";
            html += "</span>\r\n                        </div>\r\n                        <div class='text-grey-m2'>\r\n                            <div class='my-1'>";
            html += ""+C_Address+"";
        
        
        }
    }
}
