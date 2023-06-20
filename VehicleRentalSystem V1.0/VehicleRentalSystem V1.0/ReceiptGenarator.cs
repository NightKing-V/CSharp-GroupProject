using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem_V1._0
{
    internal class ReceiptGenarator
    {
        private string startdate, enddate, returndate, duration;
        private double Rental, fee, penaltyfee, totalfee;
        private int penaltyrate;
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
        public double HireFee()
        {
            //oilfee = etamilage*oilprice
            //oilfee+
            return 0;
        }
        public void HireReceipt()
        {
            string html = "";
        }
    }
}
