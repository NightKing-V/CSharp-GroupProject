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
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void VDC(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/valentenolenora/");
        }

        private void DDC(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/dasith-de-zoysa-661a63241/");
        }

        private void LDC(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/laknidu-thilakawardhana-411783247/");
        }

        private void CDC(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/chamara-sandanayake-3a8227241/");
        }

        private void NDC(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/nishedha-liyanage-5bbb3b25b");
        }

        private void NSBMDC(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.nsbm.ac.lk/");
        }
    }
}
