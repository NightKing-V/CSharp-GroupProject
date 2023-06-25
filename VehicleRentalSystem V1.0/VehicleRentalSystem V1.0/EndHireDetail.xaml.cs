using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for EndHireDetail.xaml
    /// </summary>
    public partial class EndHireDetail : Window
    {
        public EndHireDetail()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            HireIDtxt.Clear();
            EndMilatxt.Clear();
            DFeeTxt.Clear();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ReceiptGenarator RG = new ReceiptGenarator();
            RG.HireFee(HireIDtxt.Text, ReturnDate.Text,DFeeTxt.Text, EndMilatxt.Text);
            this.Hide();
        }
    }
}
