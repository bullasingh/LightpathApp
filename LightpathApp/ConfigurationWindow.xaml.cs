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

using LightPath.Process;
using LightPath.InstrumentModel;
using LightPath.Drivers;

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        // These need to be initialised from main window.
        private SpecimenAnalyser theAnalyser;
        private ILightPathInstrument theInstrument;

        public ConfigurationWindow()
        {
            InitializeComponent();
            theAnalyser = SpecimenAnalyser.Instance;
            theInstrument = theAnalyser.Instrument;
        }

        // Set the default settings for both the Emccd and Reference Camera's
        public void  DefaultCameraSettings()
        {
            ConfirmationWindow cameraError;

            //This will set default values for everything for Andor Camera
            var newSettings = new AndorSettings();
 
            newSettings.AcquisitionMode = AndorSettings.AcquisitionModeType.Single;
            newSettings.BinHeightPx = 1;
            newSettings.BinWidthPx = 1;
            //newSettings.CameraSensitivity is read only
            newSettings.CcdHorizontalShiftSpeed = AndorSettings.CcdHorizontalShiftSpeedType.Speed80kHz;
            newSettings.CoolingTimeoutS = 60 * 60;
            newSettings.EmccdGain = 300;
            newSettings.EmccdHorizontalShiftSpeed = AndorSettings.EmccdHorizontalShiftSpeedType.Speed1MHz;
#if LIGHTPATH_SIMULATOR
            newSettings.ExposureTimeSeconds = 10F;
#else
            newSettings.ExposureTimeSec = 10F;
#endif
            newSettings.FirstColumnUsed = 1;
            newSettings.FirstRowUsed = 1;
            newSettings.KineticSeriesLength = 2;
#if LIGHTPATH_SIMULATOR
            newSettings.KineticSeriesTimeMs = 0.01F * 1000;
#else
            newSettings.KineticSeriesTimeSec = 0.01F;
#endif
            newSettings.LastColumnUsed = 512;
            newSettings.LastRowUsed = 512;
            newSettings.OutputAmplifier = AndorSettings.OutputAmplifierType.Emccd;
            newSettings.PreAmpGain = AndorSettings.PreAmpGainType.Gain3;
            newSettings.ShutterMode = AndorSettings.ShutterModeType.Closed;
            newSettings.StabilisationRequired = true;
            newSettings.TemperatureDegC = -80;
            newSettings.VerticalClockAmplitude = AndorSettings.VerticalClockAmplitudeType.Normal;
            newSettings.VerticalShiftSpeed = AndorSettings.VerticalShiftSpeedType.Speed3300ns;

            // Check Emccd settings are valid and if they are apply the.
            if (newSettings.IsValid())
            {
                if (theInstrument.Emccd.Configure(newSettings) == false)
                {
                    cameraError = new ConfirmationWindow();
                    cameraError.confirmMessage.Content = "Emccd Camera: FAILED to configure.";
                    Environment.Exit(-1);
                }
            }
            else
            {
                cameraError = new ConfirmationWindow();
                cameraError.confirmMessage.Content = "Emccd Camera: Incorrect configuration.";
            }

            // Set referene camera settings.
            theInstrument.ReferenceCamera.Exposure = 100;
            theInstrument.ReferenceCamera.MasterGain = 100;
            theInstrument.ReferenceCamera.WhiteBalanceMode = WhiteBalanceModeT.Manual;
            theInstrument.ReferenceCamera.RedGain = 100;
            theInstrument.ReferenceCamera.GreenGain = 0;
            theInstrument.ReferenceCamera.BlueGain = 100;
        }


        private void ButtonEmccdApply_Click(object sender, RoutedEventArgs e)
        {
            //build a AndorSettings object from values of controls
            var newSettings = new AndorSettings();

            newSettings.BinHeightPx = Convert.ToInt32((String)((ComboBoxEmccdVBinSize.SelectedItem as ComboBoxItem).Content), 10);
            newSettings.BinWidthPx = Convert.ToInt32((String)((ComboBoxEmccdHBinSize.SelectedItem as ComboBoxItem).Content), 10);
            if (ComboBoxEmccdGainType.SelectedItem == EmccdGainEmccd)
            {
                newSettings.EmccdHorizontalShiftSpeed = (AndorSettings.EmccdHorizontalShiftSpeedType)this.ComboBoxEmccdGainType.SelectedIndex;
                newSettings.OutputAmplifier = AndorSettings.OutputAmplifierType.Emccd;
                newSettings.EmccdGain = (Int32)SliderEmccdGain.Value;
            }
            else
            {
                newSettings.CcdHorizontalShiftSpeed = (AndorSettings.CcdHorizontalShiftSpeedType)this.ComboBoxEmccdGainType.SelectedIndex;
                newSettings.OutputAmplifier = AndorSettings.OutputAmplifierType.Ccd;
            }
#if LIGHTPATH_SIMULATOR
            newSettings.ExposureTimeSeconds = Convert.ToSingle(TextBoxEmccdExposure.Text);
#else
            newSettings.ExposureTimeSec = Convert.ToSingle(TextBoxEmccdExposure.Text);
#endif
            newSettings.FirstColumnUsed = Convert.ToInt32(TextBoxEmccdFirstCol.Text, 10);
            newSettings.FirstRowUsed = Convert.ToInt32(TextBoxEmccdFirstRow.Text, 10);
            newSettings.LastColumnUsed = Convert.ToInt32(TextBoxEmccdLastCol.Text, 10);
            newSettings.LastRowUsed = Convert.ToInt32(TextBoxEmccdLastRow.Text, 10);
            newSettings.PreAmpGain = (AndorSettings.PreAmpGainType)ComboBoxEmccdPreAmp.SelectedIndex;
            newSettings.ShutterMode = (AndorSettings.ShutterModeType)ComboBoxEmccdShutter.SelectedIndex;
            newSettings.StabilisationRequired = CheckBoxEmccdStabilisation.IsChecked ?? false;
            newSettings.TemperatureDegC = Convert.ToInt32(TextboxEmccdTemp.Text, 10);
            newSettings.VerticalClockAmplitude = (AndorSettings.VerticalClockAmplitudeType)ComboBoxEmccdVcv.SelectedIndex;
            newSettings.VerticalShiftSpeed = (AndorSettings.VerticalShiftSpeedType)ComboBoxEmccdVss.SelectedIndex;
            newSettings.CoolingTimeoutS = Convert.ToInt32(TextBoxEmccdCoolTimeout.Text, 10);
#if LIGHTPATH_SIMULATOR
            newSettings.KineticSeriesTimeMs = Convert.ToSingle(TextBoxEmccdKineticTimeS.Text) * 1000;
#else
            newSettings.KineticSeriesTimeSec = Convert.ToSingle(TextBoxEmccdKineticTimeS.Text);
#endif
            newSettings.KineticSeriesLength = Convert.ToInt32(TextBoxEmccdKineticCount.Text);

            //check validity
            if (newSettings.IsValid())
            {
                //configure camera
                theInstrument.Emccd.Configure(newSettings);
            }
            else
            {
                MessageBox.Show("Invalid EMCCD Camera Settings.");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
