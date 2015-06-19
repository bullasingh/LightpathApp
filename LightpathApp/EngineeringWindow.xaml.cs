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

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for EngineeringWindow.xaml
    /// </summary>
    public partial class EngineeringWindow : Window
    {
        public EngineeringWindow()
        {
            InitializeComponent();
        }

        private void TurnFanOn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TurnFanOff_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelAll_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
