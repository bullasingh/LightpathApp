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
using System.Windows.Threading;

using LightPath.Process; //High-level state-related methods and events as described in ISpecimenAnalyser.cs
using LightPath.InstrumentModel; //Instrument and component models for direct access (Engineering Interface functionality)
using LightPath.Drivers;
using LightPath.MessagingFramework;

using LightpathApp.Helper;

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainScanWindow : Window
    {
        private delegate void eventData(EventArgs argsIn);
        private delegate void eventUpdateData(StateChangeEventArgs argsIn);

        private int bytesPerUInt16;     // Speak to Patrick about this
        private BitmapSource emccdLastBitmapSource;
        private System.Drawing.Bitmap refLastBitmapSource;

        PatientDetails patientDetails;

        //object to manipulate for state changes etc
        private SpecimenAnalyser theAnalyser;

        //object to manipulate for direct control
        private ILightPathInstrument theInstrument;

        private Boolean     firstScanFlag;
        private Boolean     doorClosedFlag;
        private Boolean     doorOpenRequestFlag;
        private Boolean     sampleDetectedFlag;
        private DateTime    startTime;

        private DispatcherTimer dispatcherTimer;

        private string[] surgicalConfigs = { "", "Prostate-1", "Prostate-2", "Breast-1" };
        private string[] surgicalProcedures = { "", "Radical Prostatectomy", "", "" };

        public MainScanWindow()
        {
            InitializeComponent();
            InitialiseSpecimenAnalyser();
            bytesPerUInt16 = 2;
            firstScanFlag = true;
 
            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            startTime = DateTime.Now;
            doorClosedFlag = false;
            sampleDetectedFlag = false;
            doorOpenRequestFlag = false;

            Reset();
        }

        public void Reset()
        {
            foreach (string configs in surgicalConfigs)
            {
                Configuration.Items.Add(configs);
            }
            Configuration.Text = Configuration.Items[1] as string;

            foreach (string procdure in surgicalProcedures)
            {
                ProcedureName.Items.Add(procdure);
            }
            ProcedureName.Text = ProcedureName.Items[1] as string;
        }

        //  System.Windows.Threading.DispatcherTimer.Tick handler 
        // 
        //  Updates the current minutes and seconds display. 
        //
        private async void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int         minutes;
            int         seconds;
            const int   secondsInMinute = 60;
            int         elapsedTimeSeconds;
 
            elapsedTimeSeconds = ((DateTime.Now.Minute * 60) + DateTime.Now.Second) - ((startTime.Minute * 60) + startTime.Second);

            // Updating the Label which displays the current second
            minutes = elapsedTimeSeconds / secondsInMinute;
            seconds = elapsedTimeSeconds % secondsInMinute;

            // Updating the Label which displays the current second
            TimeElapsedMessage.Content = minutes.ToString() + " minutes " + seconds.ToString() + " seconds";

            // Update door state
            sampleDetectedFlag = await theInstrument.SpecimenHolderDrawer.HasSpecimen();
            doorClosedFlag = await theInstrument.SpecimenHolderDrawer.IsDrawerClosed();
            if ((sampleDetectedFlag == true) && (doorClosedFlag == true))
            {
                DoorMessage.Content = "Shut";
                DoorMessage.Foreground = Brushes.Green;
            }
            else
            {
                DoorMessage.Content = "Open";
                DoorMessage.Foreground = Brushes.Red;
            }
        }

        private void SetupMainWindow()
        {
            //NamePatient.Content = patientDetails.firstName + " " + patientDetails.lastName;
            //NhsNumber.Content = patientDetails.nhsNumber;
            //StreetName.Content = patientDetails.nameOfStreet;
            //NameOfCity.Content = patientDetails.nameOfCity;
            //PostCode.Content = patientDetails.postCode;
            //NameOfCounty.Content = patientDetails.nameOfCounty;
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

            //subscribe to frame available state change events
            theInstrument.Emccd.OnFrameAvailable += theAnalyser_EmccdScanOnStateChange;
            theInstrument.ReferenceCamera.OnFrameAvailable += theAnalyser_RefScanOnStateChange;

            //subscribe to state change events
            theAnalyser.OnStateChange += theAnalyser_OnStateChange;

#if LIGHTPATH_SIMULATOR
            // Next 2 lines for simulator only.
            (theInstrument.SpecimenHolderDrawer as LightPath.InstrumentModel.Mock.MockSpecimenHolder).DrawerClosed = true;
            (theInstrument.SpecimenHolderDrawer as LightPath.InstrumentModel.Mock.MockSpecimenHolder).SpecimenPresent = true;
#endif
        }

        // TODO: Check with Patrick
        private async void ConfigureProcedureSettings()
        {
            ConfigurationWindow cameraSettings;
            ConfirmationWindow userError;

            // TODO: Will be replaced with a call to load settings for procedure
            cameraSettings = new ConfigurationWindow();
            cameraSettings.DefaultCameraSettings(); 

            // Set filter wheel
            if (await theInstrument.FilterWheel.MoveTo(FilterWheelPosition.Position1) == false)
            { 
                userError = new ConfirmationWindow();
                userError.confirmMessage.Content = "Filter Wheel: Failed to configure.";
                Environment.Exit(-1);
            }
            startTime = DateTime.Now;
        }

        private void StartScan_Click(object sender, RoutedEventArgs e)
        {
            ScanningWindow newScan;
            ConfirmationWindow userError;

            if ((sampleDetectedFlag == true) && (doorClosedFlag == true))
            {
                if (firstScanFlag == true)
                {
                    ConfigureProcedureSettings();
                    startTime = DateTime.Now;
                }

                newScan = new ScanningWindow(firstScanFlag);
                SystemMessage.Content = "Acquiring";
                newScan.ShowDialog();
                if (newScan.cancelPressed == false)
                {
                    SystemMessage.Content = "Complete";
                }
                else
                {
                    SystemMessage.Content = "Ready";
                }
                firstScanFlag = false;
                TempMessage.Content = theInstrument.Emccd.DetectorTemperatureDegC.ToString();
            }
            else
            {
                userError = new ConfirmationWindow();
                if (sampleDetectedFlag == true)
                {
                    userError.confirmMessage.Content = "Door not closed.";
                }
                else
                {
                    userError.confirmMessage.Content = "Sample not detected.";
                }
                userError.ShowDialog();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpdateEmccdImage(EmccdRawData data)
        {
            var array = data.RawData.ToArray<UInt16>();
            UInt16 arrayMax = array.Max();
            UInt16 arrayMin = array.Min();
            arrayMax = arrayMax == arrayMin ? UInt16.MaxValue : arrayMax;
            Single scaleFactor = UInt16.MaxValue / (arrayMax - arrayMin);

            for (Int32 i = 0; i < array.Count(); i++)
            {
                array[i] = (UInt16)(scaleFactor * (array[i] - arrayMin));
            }

            BitmapSource bmpSrc = BitmapSource.Create(
                data.WidthPixels,
                data.HeightPixels,
                96,
                96,
                System.Windows.Media.PixelFormats.Gray16,
                BitmapPalettes.Gray256,
                array,
                bytesPerUInt16 * data.HeightPixels);

            emccdLastBitmapSource = bmpSrc.Clone();
            emccdLastBitmapSource.Freeze();

            // Schedule the update function in the UI thread.
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new eventData(UpdateImage), new EventArgs());
        }

        private void UpdateImage(EventArgs argsIn)
        {
            ScannedImage.Source = emccdLastBitmapSource;
        }

        // Scan Emccd Camera completed so process and update the Image on UI.
        private void theAnalyser_EmccdScanOnStateChange(object sender, CameraFrameMessage cfm)
        {
            var data = theInstrument.Emccd.GetFrame(cfm.NewFrameLocation);

            UpdateEmccdImage(data);
        }

        // Scan Reference Camera completed so process and update the Image on UI.
        private void theAnalyser_RefScanOnStateChange(object sender, CameraFrameMessage cfm)
        {
            refLastBitmapSource = theInstrument.ReferenceCamera.GetFrame(cfm.AcquisitionTime);
        }

        private void OpenDoorButton_Click(object sender, RoutedEventArgs e)
        {
            theAnalyser.AccessSpecimen();
            doorOpenRequestFlag = true;
        }

        private void UpdateFinishedFlag(StateChangeEventArgs argsIn)
        {
            if (doorOpenRequestFlag == true)
            {
                firstScanFlag = true;
                doorOpenRequestFlag = false;
            }
        }

        private void theAnalyser_OnStateChange(object sender, StateChangeEventArgs e)
        {

            switch (e.NewState)
            {
                case State.AccessSpecimenReady:
                    // Schedule the update function in the UI thread.
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new eventUpdateData(UpdateFinishedFlag), e);
                    break;

                default: // Should we do anything?
                    break;
            }
        }
    }
}