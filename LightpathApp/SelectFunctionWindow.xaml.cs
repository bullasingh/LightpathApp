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
    /// Interaction logic for SelectFunctionWindow.xaml
    /// </summary>
    public partial class SelectFunctionWindow : Window
    {
        public SelectFunctionWindow()
        {
            InitializeComponent();
        }

        private void TechincalService_Click(object sender, RoutedEventArgs e)
        {
            EngScrollWindow advancedEng;

            advancedEng = new EngScrollWindow();
            advancedEng.Show();
        }

        private void Configuration_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clinical_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
