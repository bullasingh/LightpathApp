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
    /// Interaction logic for EngWindow.xaml
    /// </summary>
    public partial class EngWindow : Window
    {
        public EngWindow()
        {
            InitializeComponent();
        }

        private void ExitEng_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DoorTests_Click(object sender, RoutedEventArgs e)
        {
            DoorTestsWindow doorTests;

            doorTests = new DoorTestsWindow();

            doorTests.ShowDialog();
        }

        private void FanTests_Click(object sender, RoutedEventArgs e)
        {
            FanTestsWindow fanTests;

            fanTests = new FanTestsWindow();

            fanTests.ShowDialog();
        }

        private void CasingTests_Click(object sender, RoutedEventArgs e)
        {
            CaseingTestsWindow caseingTests;

            caseingTests = new CaseingTestsWindow();
            caseingTests.ShowDialog();
        }

        private void FilterTests_Click(object sender, RoutedEventArgs e)
        {
            FilterWheelTestsWindow filterWheelTests;

            filterWheelTests = new FilterWheelTestsWindow();
            filterWheelTests.ShowDialog();
        }

        private void IndicatorLEDTests_Click(object sender, RoutedEventArgs e)
        {
            LEDTestsWindow indicatorLedsTests;

            indicatorLedsTests = new LEDTestsWindow();
            indicatorLedsTests.ShowDialog();
        }

        private void InternalLightsTests_Click(object sender, RoutedEventArgs e)
        {
            InternalLightsTestsWindow interiorLightsTests;

            interiorLightsTests = new InternalLightsTestsWindow();
            interiorLightsTests.ShowDialog();
        }

        private void MirrorTests_Click(object sender, RoutedEventArgs e)
        {
            MirrorTestsWindow mirrorTests;

            mirrorTests = new MirrorTestsWindow();
            mirrorTests.ShowDialog();
        }

        private void HolderTests_Click(object sender, RoutedEventArgs e)
        {
            DrawerTestsWindow drawerTests;

            drawerTests = new DrawerTestsWindow();
            drawerTests.ShowDialog();
        }

        private void HeartbeatTests_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AndorCameraTests_Click(object sender, RoutedEventArgs e)
        {
            AndorCameraWindow andorCameraTests;

            andorCameraTests = new AndorCameraWindow();
            andorCameraTests.ShowDialog();
        }

        private void ReferenceCameraTests_Click(object sender, RoutedEventArgs e)
        {
            RefCameraWindow refCameraTests;

            refCameraTests = new RefCameraWindow();
            refCameraTests.ShowDialog();
        }

        private void SerialNumber_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
