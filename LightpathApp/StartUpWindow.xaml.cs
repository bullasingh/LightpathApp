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

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : Window
    {
        private delegate void eventData(StartUpDelayEventArgs argsIn);

        // Delegates to be used in placing jobs onto the Dispatcher. 
        private delegate void NoArgDelegate();
        private delegate void OneArgDelegate(String argIn);

        //object to manipulate for state changes etc
        private SpecimenAnalyser theAnalyser;

        private Boolean finishedFlag;

        private Thread childThread;
        
        public StartUpWindow()
        {
            InitializeComponent();

            // Hardware reset and access specimen calls.
            InitialiseSpecimenAnalyser();
            finishedFlag = false;

            ThreadStart childref = new ThreadStart(StartDelayThread);
            childThread = new Thread(childref);
            childThread.Start();

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

            //subscribe to state change events
            theAnalyser.OnStateChange += theAnalyser_OnStateChange;

            theAnalyser.ResetHardware();
        }

        private void UpdateFinishedFlag(StartUpDelayEventArgs argsIn)
        {
            finishedFlag = true;
        }

        private void theAnalyser_OnStateChange(object sender, StateChangeEventArgs e)
        {
            StartUpDelayEventArgs delayEventArgs = new StartUpDelayEventArgs();

            switch (e.NewState)
            {
                case State.ResetHardwareOk:
                    theAnalyser.AccessSpecimen();
                    break;

                case State.AccessSpecimenReady:
                    // Schedule the update function in the UI thread.
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new eventData(UpdateFinishedFlag), delayEventArgs);
                    break;

                default: // Should we do anything?
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Unscribe to events.
            theAnalyser.OnStateChange -= theAnalyser_OnStateChange;

            childThread.Abort();

            // Wait until timer thread aborted
            while (childThread.IsAlive);
        }

        public class StartUpDelayEventArgs : EventArgs
        {

            public StartUpDelayEventArgs()
            {
            }

            public String Message { get; private set; }
        }

        public void StartDelayThread()
        {
            StartUpDelayEventArgs delayEventArgs = new StartUpDelayEventArgs();

            for(;;)
            { 
                // Simulate the delay from network access.
                Thread.Sleep(1000);

                // Schedule the update function in the UI thread.
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new eventData(UpdateDelayBar), delayEventArgs);
            }
        }

        private void UpdateDelayBar(StartUpDelayEventArgs argsIn)
        {
            if (startProgressBar.Value <= 90)
            {
                startProgressBar.Value += 10;
            }
            
            if (startProgressBar.Value >= 100)
            {
                if (finishedFlag == true)
                {
                    this.Close();
                }
            }
        }
    }
}
