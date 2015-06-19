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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

using LightPath.Process; //High-level state-related methods and events as described in ISpecimenAnalyser.cs
using LightPath.InstrumentModel; //Instrument and component models for direct access (Engineering Interface functionality)

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for ScanningWindow.xaml
    /// </summary>
    public partial class ScanningWindow : Window
    {
        public  Boolean     cancelPressed;
        private Boolean     allowWindowClose;
        private ScanImageState scanState;

        // Delegates to be used in placing jobs onto the Dispatcher. 
        private delegate void NoArgDelegate();
        private delegate void OneArgDelegate(String argIn);
        private delegate void eventData(StateChangeEventArgs argsIn);
        private delegate void delayEventData(EventArgs argsIn);


        private Thread childThread;

        // These need to be initialised from main window.
        private SpecimenAnalyser theAnalyser;
        private ILightPathInstrument theInstrument;

        public ScanningWindow(Boolean argFirstScan)
        {
            InitializeComponent();
            cancelPressed = false;
            allowWindowClose = false;
            theAnalyser = SpecimenAnalyser.Instance;
            theInstrument = theAnalyser.Instrument;

            //subscribe to state change events
            theAnalyser.OnStateChange += theAnalyser_ScanOnStateChange;
            theAnalyser.OnExecutionError += theAnalyser_ErrorChange;

            if (argFirstScan == true)
            {
                scanState = ScanImageState.StartofScan;
                theAnalyser.SecureSpecimen();
            }
            else
            {
                // Need to turn on lights for refernce camera.
                LightsONRefCamera();

                scanState = ScanImageState.ReferenceCameraScan;

                // Kick start Reference image capture.
                try
                {
                    theAnalyser.CaptureStillImage(Camera.Reference);
                }
                catch
                {
                    DebugWindow debugWindow;

                    debugWindow = new DebugWindow("Error in starting Reference scan - ScanningWindow.xaml.cs");
                    debugWindow.ShowDialog();

                    Environment.Exit(-1);
                }
            }

            ThreadStart childref = new ThreadStart(ScanDelayThread);
            childThread = new Thread(childref);
            childThread.Start();

        }

        // TODO: Check with Patrick
        private async void LightsONRefCamera()
        {
            await theInstrument.InteriorLights.SetAll(true);
        }

        private async void LightsOFFRefCamera()
        {
            await theInstrument.InteriorLights.SetAll(false);
        }

        enum ScanImageState
        {
            StartofScan,
            ReferenceCameraScan,
            EmccdCameraScan,
            EndOfScan
        };

        // Don't allow window closing until either scan completed or scan cancel completed.
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (allowWindowClose == false)
            {
                // Cancel closure as we've not finished.
                e.Cancel = true;
            }
            else
            {
                //unsubscribe to state change events.
                theAnalyser.OnStateChange -= theAnalyser_ScanOnStateChange;
                theAnalyser.OnExecutionError -= theAnalyser_ErrorChange;

                childThread.Abort();

                // Wait until timer thread aborted
                while (childThread.IsAlive) ;
            }
        }

        
        void theAnalyser_ErrorChange(object sender, ExecutionErrorEventArgs e)
        {
            switch (e.State)
            {
                case State.ResetHardwareOk:
                    break;
            }

        }

        // Update has to be in UI thread.
        private void Update_UI_ScanOnStateChange(StateChangeEventArgs e)
        {
            switch (e.NewState)
            {
                case State.SecureSpecimenReady:
                    switch (scanState)
                    {
                        case ScanImageState.StartofScan:
                            scanState = ScanImageState.ReferenceCameraScan;

                            // Kick start Reference image capture.
                            try
                            {
                                // Need to turn on lights for refernce camera.
                                LightsONRefCamera();

                                theAnalyser.CaptureStillImage(Camera.Reference);
                            }
                            catch
                            {
                                DebugWindow debugWindow;

                                debugWindow = new DebugWindow("Error in starting Reference scan - ScanningWindow.xaml.cs");
                                debugWindow.ShowDialog();

                                Environment.Exit(-1);
                            }
                            break;

                        case ScanImageState.ReferenceCameraScan:
                            scanState = ScanImageState.EndOfScan;
                            LightsOFFRefCamera();

                            // Kick start Emccd image capture.
                            try
                            {
                                theAnalyser.CaptureStillImage(Camera.Emccd);
                            }
                            catch
                            {
                                DebugWindow debugWindow;

                                debugWindow = new DebugWindow("Error in starting Emccd scan - ScanningWindow.xaml.cs");
                                debugWindow.ShowDialog();

                                Environment.Exit(-1);
                            }
                            break;

                        case ScanImageState.EndOfScan:
                            allowWindowClose = true;
                            this.Close();
                            break;

                        default:
                            break;
                    }
                    break;

                default: // Should we do anything?
                    break;
            }
        }

        // Wait for scan to complete and close window once done.
        private void theAnalyser_ScanOnStateChange(object sender, StateChangeEventArgs e)
        {
            switch (e.NewState)
            {
                case State.ResetHardwareOk:
                    theAnalyser.AccessSpecimen();
                    break;

                case State.AccessSpecimenReady:
#if LIGHTPATH_SIMULATOR
                    // Next 2 lines for simulator only.
                    (theInstrument.SpecimenHolderDrawer as LightPath.InstrumentModel.Mock.MockSpecimenHolder).DrawerClosed = true;
                    (theInstrument.SpecimenHolderDrawer as LightPath.InstrumentModel.Mock.MockSpecimenHolder).SpecimenPresent = true;
#endif                    
                    theAnalyser.SecureSpecimen();
                    break;

                case State.SecureSpecimenReady:
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new eventData(Update_UI_ScanOnStateChange), e);
                    break;

                default: // Should we do anything?
                    break;
            }
        }
 
        private void CancelScan_Click(object sender, RoutedEventArgs e)
        {
            cancelPressed = true;
            StartMessage.Content = "Cancelling Scan";
            ScanProgressBar.Visibility = System.Windows.Visibility.Hidden;
            CancelScan.Visibility = System.Windows.Visibility.Hidden;
            CancelScan.IsEnabled = false;

            // Cancel image capture.
            try
            {
                theAnalyser.StopImageCapture();
            }
            // Operation not allowed by drivers at moment
            catch (SpecimenAnalyserOperationNotAllowedException)
            {
                DebugWindow debugWindow;

                debugWindow = new DebugWindow("Cancel operation not implmented in drivers - ScanningWindow.xaml.cs");
                debugWindow.ShowDialog();
                allowWindowClose = true;
            }
        }

         public void ScanDelayThread()
        {
            for (; ; )
            {
                Thread.Sleep(1000);

                // Schedule the update function in the UI thread.
                ScanProgressBar.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new delayEventData(UpdateScanDelayBar), new EventArgs());
            }
        }

        private void UpdateScanDelayBar(EventArgs argsIn)
        {
            if (ScanProgressBar.Value <= 300)
            {
                ScanProgressBar.Value += 10;
            }
            ProgressText.Content = "...approxmiately ??? minutes remaining.";
        }
    }
}


 

