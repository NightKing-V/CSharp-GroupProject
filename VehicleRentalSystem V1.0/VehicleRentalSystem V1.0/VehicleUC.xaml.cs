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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VehicleRentalSystem_V1._0
{
    /// <summary>
    /// Interaction logic for VehicleUC.xaml
    /// </summary>
    public partial class VehicleUC : UserControl
    {
        public VehicleUC()
        {
            InitializeComponent();
        }

        private void VehicleMBtn_Click(object sender, RoutedEventArgs e)
        {
            ManageVehicleFor managevehicleform = new ManageVehicleFor();
            managevehicleform.Show();
        }
    }
}
