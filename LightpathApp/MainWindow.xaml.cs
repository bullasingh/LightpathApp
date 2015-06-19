//************************************************************************* 
// (c) LightPoint Medical, 2015.  All rights reserved.   
//  
// This software is the property of LightPoint Medical and may 
// not be copied or reproduced otherwise than on to a single hard disk for 
// backup or archival purposes.  The source code is confidential  
// information and must not be disclosed to third parties or used without  
// the express written permission of LightPoint Medical. 
//
// Author: B Singh
// Date: 30 May 2015
//
//
//*************************************************************************

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

using LightPath.Process; //High-level state-related methods and events as described in ISpecimenAnalyser.cs
using LightPath.InstrumentModel; //Instrument and component models for direct access (Engineering Interface functionality)

using LightpathApp.Helper;

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PatientDetails patientDetails;

        //object to manipulate for state changes etc
        private SpecimenAnalyser theAnalyser;

        //object to manipulate for direct control
        private ILightPathInstrument theInstrument;

        public MainWindow()
        {
            SplashScreen splashScreen = new SplashScreen("Proposed GUI_Background.jpg");
            splashScreen.Show(true);

            InitializeComponent();
            InitialiseSpecimenAnalyser();
            patientDetails = new PatientDetails();
            StartUpWindow();
            UserLoginWindow();
        }

        private void StartUpWindow()
        {
            StartUpWindow start = new StartUpWindow();

            start.ShowDialog();
        }

        private void UserLoginWindow()
        {
            LoginWindow start = new LoginWindow();

            start.ShowDialog();
        }

        //don't need a separate thread: the driver spins out new ones as needed using async/await
        private void InitialiseSpecimenAnalyser()
        {
            // Get the single static instance of the specimen analyser
            // If there is an exception - can't proceed.
            try
            {
                theAnalyser = SpecimenAnalyser.Instance;
            }
            catch
            {
                DebugWindow debugWindow;

                debugWindow = new DebugWindow("Error in getting theAnalyser - MainWindow.xaml.cs");
                debugWindow.ShowDialog();

                Environment.Exit(-1);
            }

            try
            {
                theInstrument = theAnalyser.Instrument;
            }
            catch
            {
                DebugWindow debugWindow;

                debugWindow = new DebugWindow("Error in getting theInstrument - MainWindow.xaml.cs");
                debugWindow.ShowDialog();

                Environment.Exit(-1);
            }

            //subscribe to state change events
            //theAnalyser.OnStateChange += theAnalyser_OnStateChange;

            // TODO: Bulla causes problems at moment
            //theAnalyser.ResetHardware();
        }

        private void theAnalyser_OnStateChange(object sender, StateChangeEventArgs e)
        {
            //Process new state information.
            //if (e.NewState ==)
        }

        private void Clinical_Click(object sender, RoutedEventArgs e)
        {
            MainScanWindow SampleScanWindow;

            SampleScanWindow = new MainScanWindow();
            SampleScanWindow.Show();
        }

        private void TechincalService_Click(object sender, RoutedEventArgs e)
        {
            EngScrollWindow advancedEng;

            advancedEng = new EngScrollWindow();
            advancedEng.Show();
        }

        private void Configuration_Click(object sender, RoutedEventArgs e)
        {
           ConfigurationWindow configuration;

            configuration = new ConfigurationWindow();
            configuration.Show();
        }
    }
}