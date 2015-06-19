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
using System.Threading;
using System.Timers;

using LightPath.Process;
using LightPath.InstrumentModel;
using LightPath.Drivers;

using PropertyChanged;
using System.Diagnostics;

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for InternalEi.xaml
    /// </summary>
    [ImplementPropertyChanged]
    public partial class InternalEi : UserControl
    {
        /// <summary>
        /// A reference to the instrument model. This can be either a fake or real model.
        /// </summary>
        private readonly ILightPathInstrument instrument;
        private CancellationTokenSource cts;
        private readonly System.Timers.Timer componentsUpdateTimer;
        private const Int32 componentsUpdatePeriodMs = 500;
// Bulla       private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InternalEi(ILightPathInstrument instrument)
        {
            InitializeComponent();

            this.instrument = instrument;

            this.LabelEmccdCurrentTemp.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));

            componentsUpdateTimer = new System.Timers.Timer { AutoReset = true, Interval = componentsUpdatePeriodMs };
            componentsUpdateTimer.Elapsed += ComponentsUpdateTimer_Elapsed;
            componentsUpdateTimer.Start();
            
            this.DataContext = this;
        }

        private async void ComponentsUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (automaticHeartbeat)
            {
                await this.instrument.Heartbeat.Kick();
            }
            if(this.IsVisible)
            {
                try
                {
                    await RefreshOtherControls();
                    
                }
                catch (Exception ex)
                {
                    // Bulla log.ErrorFormat("Exception caught in ComponentsUpdateTimer_Elapsed. {0}", ex.Message);
                }
            }

        }

        #region Fan

        private async void ButtonFanOn_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.Fan.Start();
        }

        private async void ButtonFanOff_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.Fan.Disable();
        }
        #endregion

        #region RefCam

        private void CheckBoxRefCamAutoGain_Click(object sender, RoutedEventArgs e)
        {
            this.instrument.ReferenceCamera.AutoGainIsEnabled = this.CheckBoxRefCamAutoGain.IsChecked ?? false;
            this.SliderRefCamGain.IsEnabled = !(this.CheckBoxRefCamAutoGain.IsChecked ?? false);
        }

        private void CheckBoxRefCamAutoExp_Click(object sender, RoutedEventArgs e)
        {
            this.instrument.ReferenceCamera.AutoExposureIsEnabled = this.CheckBoxRefCamAutoExp.IsChecked ?? false;
            this.SliderRefCamExposure.IsEnabled = !(this.CheckBoxRefCamAutoExp.IsChecked ?? false);
        }

        private void SliderRefCamGain_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!this.instrument.ReferenceCamera.AutoGainIsEnabled)
            {
                this.instrument.ReferenceCamera.MasterGain = (Int32)this.SliderRefCamGain.Value;
            }
        }

        private void SliderRefCamExposure_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!this.instrument.ReferenceCamera.AutoExposureIsEnabled)
            {
                this.instrument.ReferenceCamera.Exposure = (Int32)this.SliderRefCamExposure.Value;
            }
        }

        private void ComboBoxRefCamAwbMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.instrument.ReferenceCamera.WhiteBalanceMode = (WhiteBalanceModeT)this.ComboBoxRefCamAwbMode.SelectedIndex;
        }

        private void SliderRefCamRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (WhiteBalanceModeT.Manual == this.instrument.ReferenceCamera.WhiteBalanceMode)
            {
                this.instrument.ReferenceCamera.RedGain = (Int32)this.SliderRefCamRed.Value;
            }
        }

        private void SliderRefCamGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (WhiteBalanceModeT.Manual == this.instrument.ReferenceCamera.WhiteBalanceMode)
            {
                this.instrument.ReferenceCamera.GreenGain = (Int32)this.SliderRefCamGreen.Value;
            }
        }

        private void SliderRefCamBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (WhiteBalanceModeT.Manual == this.instrument.ReferenceCamera.WhiteBalanceMode)
            {
                this.instrument.ReferenceCamera.BlueGain = (Int32)this.SliderRefCamBlue.Value;
            }
        }
#endregion

        #region Filter

        private async void ButtonFilterPosition1_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.FilterWheel.MoveTo(FilterWheelPosition.Position1);
        }

        private async void ButtonFilterPosition2_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.FilterWheel.MoveTo(FilterWheelPosition.Position2);
        }

        private async void ButtonFilterPosition3_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.FilterWheel.MoveTo(FilterWheelPosition.Position3);
        }

        private async void ButtonFilterPosition4_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.FilterWheel.MoveTo(FilterWheelPosition.Position4);
        }

        private async void ButtonFilterPositionHome_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.FilterWheel.MoveTo(FilterWheelPosition.Home);
        }

#endregion

        #region Mirror

        private async void ButtonMirrorEmccd_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.Mirror.MoveTo(MirrorPosition.Emccd);
        }

        private async void ButtonMirrorReference_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.Mirror.MoveTo(MirrorPosition.Reference);
        }

        private async void ButtonMirrorHome_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.Mirror.Home();
        }

#endregion

        #region EMCCD

        private void TextBoxEmccdKineticTime_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                this.TextBoxEmccdKineticTimeS.Text = Convert.ToSingle(this.TextBoxEmccdKineticTimeS.Text).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be positive decimal number");
                FocusManager.SetFocusedElement(this, this.TextBoxEmccdKineticTimeS);
            }
        }

        private void TextBoxEmccdKineticCount_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                this.TextBoxEmccdKineticCount.Text = Convert.ToInt32(this.TextBoxEmccdKineticCount.Text).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be positive integer");
                FocusManager.SetFocusedElement(this, this.TextBoxEmccdKineticCount);
            }
        }

        private async void ButtonEmccdCool_Click(object sender, RoutedEventArgs e)
        {
            this.LabelEmccdCurrentTemp.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
            this.instrument.Emccd.TargetTemperatureDegC = Convert.ToInt32(this.TextboxEmccdTemp.Text, 10);
            var ct = GetNewCancellationToken();
            if(await this.instrument.Emccd.Cool(ct))
            {
                this.LabelEmccdCurrentTemp.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xFF, 0x00));
            }
            
        }

        private async void ButtonEmccdWarm_Click(object sender, RoutedEventArgs e)
        {
            this.LabelEmccdCurrentTemp.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
            var ct = GetNewCancellationToken();
            if(await this.instrument.Emccd.Warm(ct))
            {
                this.LabelEmccdCurrentTemp.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xFF, 0x00));
            }
        }

        private void TextboxEmccdTemp_LostFocus(object sender, RoutedEventArgs e)
        {
            var tempRange = this.instrument.Emccd.ValidTemperatureRangeDegC;
            if (!tempRange.ContainsValue(Convert.ToInt32(this.TextboxEmccdTemp.Text, 10)))
            {
                MessageBox.Show(String.Format("Target temperature must be between {0} and {1}", tempRange.Minimum, tempRange.Maximum));
            }
        }

        private void RepopulateHssComboBox()
        {
            if (this.ComboBoxEmccdGainType.SelectedIndex == (Int32)AndorSettings.OutputAmplifierType.Emccd)
            {
                ComboBoxEmccdHss.ItemsSource = LightPath.Utility.EnumUtil.GetValues<AndorSettings.EmccdHorizontalShiftSpeedType>();
                ComboBoxEmccdHss.SelectedItem = instrument.Emccd.Settings.EmccdHorizontalShiftSpeed;
                this.SliderEmccdGain.IsEnabled = true;
            }
            else
            {
                ComboBoxEmccdHss.ItemsSource = LightPath.Utility.EnumUtil.GetValues<AndorSettings.CcdHorizontalShiftSpeedType>();
                ComboBoxEmccdHss.SelectedItem = instrument.Emccd.Settings.CcdHorizontalShiftSpeed;
                this.SliderEmccdGain.IsEnabled = false;
            }
        }

        private void ComboBoxEmccdGainType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RepopulateHssComboBox();
        }

        private void RefreshEmccdControls()
        {
            
            this.Dispatcher.Invoke(() =>
            {
                var settings = this.instrument.Emccd.Settings;
                ComboBoxEmccdGainType.SelectedIndex = (Int32)settings.OutputAmplifier;
                ComboBoxEmccdPreAmp.SelectedIndex = (Int32)settings.PreAmpGain;
                SliderEmccdGain.Value = settings.EmccdGain;
                ComboBoxEmccdShutter.SelectedIndex = (Int32)settings.ShutterMode;
                TextboxEmccdTemp.Text = String.Format("{0}", settings.TemperatureDegC);
                CheckBoxEmccdStabilisation.IsChecked = settings.StabilisationRequired;
                if (AndorSettings.OutputAmplifierType.Ccd == settings.OutputAmplifier)
                {
                    ComboBoxEmccdHss.SelectedItem = instrument.Emccd.Settings.CcdHorizontalShiftSpeed;
                    SliderEmccdGain.IsEnabled = false;
                }
                else
                {
                    ComboBoxEmccdHss.SelectedItem = instrument.Emccd.Settings.EmccdHorizontalShiftSpeed;
                    SliderEmccdGain.IsEnabled = true;
                }
                ComboBoxEmccdVss.SelectedIndex = (Int32)settings.VerticalShiftSpeed;
                ComboBoxEmccdVcv.SelectedIndex = (Int32)settings.VerticalClockAmplitude;
#if LIGHTPATH_SIMULATOR
                TextBoxEmccdExposure.Text = String.Format("{0}", settings.ExposureTimeSeconds);
#else
                TextBoxEmccdExposure.Text = String.Format("{0}", settings.ExposureTimeSec);
#endif
                TextBoxEmccdFirstCol.Text = String.Format("{0}", settings.FirstColumnUsed);
                TextBoxEmccdLastCol.Text = String.Format("{0}", settings.LastColumnUsed);
                TextBoxEmccdFirstRow.Text = String.Format("{0}", settings.FirstRowUsed);
                TextBoxEmccdLastRow.Text = String.Format("{0}", settings.LastRowUsed);
                ComboBoxEmccdHBinSize.SelectedIndex = (Int32)Math.Log(settings.BinWidthPx, 2);
                ComboBoxEmccdVBinSize.SelectedIndex = (Int32)Math.Log(settings.BinHeightPx, 2);
                TextBoxEmccdCoolTimeout.Text = String.Format("{0}", settings.CoolingTimeoutS);
                TextBoxEmccdKineticCount.Text = settings.KineticSeriesLength.ToString();
#if LIGHTPATH_SIMULATOR
                TextBoxEmccdKineticTimeS.Text = (settings.KineticSeriesTimeMs / 1000).ToString();
#else
                TextBoxEmccdKineticTimeS.Text = (settings.KineticSeriesTimeSec).ToString();
#endif
            });
        }

        private void ButtonEmccdApply_Click(object sender, RoutedEventArgs e)
        {
            //build a AndorSettings object from values of controls
            var newSettings = new AndorSettings();
            newSettings.BinHeightPx = Convert.ToInt32((String)((this.ComboBoxEmccdVBinSize.SelectedItem as ComboBoxItem).Content), 10);
            newSettings.BinWidthPx = Convert.ToInt32((String)((this.ComboBoxEmccdHBinSize.SelectedItem as ComboBoxItem).Content), 10);
            if (this.ComboBoxEmccdGainType.SelectedItem == this.EmccdGainEmccd)
            {
                newSettings.EmccdHorizontalShiftSpeed = (AndorSettings.EmccdHorizontalShiftSpeedType)this.ComboBoxEmccdGainType.SelectedIndex;
                newSettings.OutputAmplifier = AndorSettings.OutputAmplifierType.Emccd;
                newSettings.EmccdGain = (Int32)this.SliderEmccdGain.Value;
            }
            else
            {
                newSettings.CcdHorizontalShiftSpeed = (AndorSettings.CcdHorizontalShiftSpeedType)this.ComboBoxEmccdGainType.SelectedIndex;
                newSettings.OutputAmplifier = AndorSettings.OutputAmplifierType.Ccd;
            }
#if LIGHTPATH_SIMULATOR
            newSettings.ExposureTimeSeconds = Convert.ToSingle(this.TextBoxEmccdExposure.Text);
#else
            newSettings.ExposureTimeSec = Convert.ToSingle(this.TextBoxEmccdExposure.Text);
#endif

            newSettings.FirstColumnUsed = Convert.ToInt32(this.TextBoxEmccdFirstCol.Text, 10);
            newSettings.FirstRowUsed = Convert.ToInt32(this.TextBoxEmccdFirstRow.Text, 10);
            newSettings.LastColumnUsed = Convert.ToInt32(this.TextBoxEmccdLastCol.Text, 10);
            newSettings.LastRowUsed = Convert.ToInt32(this.TextBoxEmccdLastRow.Text, 10);
            newSettings.PreAmpGain = (AndorSettings.PreAmpGainType)this.ComboBoxEmccdPreAmp.SelectedIndex;
            newSettings.ShutterMode = (AndorSettings.ShutterModeType)this.ComboBoxEmccdShutter.SelectedIndex;
            newSettings.StabilisationRequired = this.CheckBoxEmccdStabilisation.IsChecked ?? false;
            newSettings.TemperatureDegC = Convert.ToInt32(this.TextboxEmccdTemp.Text, 10);
            newSettings.VerticalClockAmplitude = (AndorSettings.VerticalClockAmplitudeType)this.ComboBoxEmccdVcv.SelectedIndex;
            newSettings.VerticalShiftSpeed = (AndorSettings.VerticalShiftSpeedType)this.ComboBoxEmccdVss.SelectedIndex;
            newSettings.CoolingTimeoutS = Convert.ToInt32(this.TextBoxEmccdCoolTimeout.Text, 10);
#if LIGHTPATH_SIMULATOR
            newSettings.KineticSeriesTimeMs = Convert.ToSingle(this.TextBoxEmccdKineticTimeS.Text) * 1000;
#else
            newSettings.KineticSeriesTimeSec = Convert.ToSingle(this.TextBoxEmccdKineticTimeS.Text);
#endif
            newSettings.KineticSeriesLength = Convert.ToInt32(this.TextBoxEmccdKineticCount.Text);

            //check validity
            if (newSettings.IsValid())
            {
                //configure camera
                this.instrument.Emccd.Configure(newSettings);
            }
            else
            {
                MessageBox.Show("Invalid EMCCD Camera Settings.");
            }
        }

        private void TextBoxEmccdCol_LostFocus(object sender, RoutedEventArgs e)
        {
            var fc = Convert.ToInt32(this.TextBoxEmccdFirstCol.Text, 10);
            var lc = Convert.ToInt32(this.TextBoxEmccdLastCol.Text, 10);
            var bs = 2 ^ this.ComboBoxEmccdHBinSize.SelectedIndex;
            if (fc > lc)
            {
                MessageBox.Show("First column index can't be more than last column index");
            }
            if (bs > (lc - fc))
            {
                MessageBox.Show("Horizontal bin size must be smaller than used width");
            }
        }

        private void TextBoxEmccdRow_LostFocus(object sender, RoutedEventArgs e)
        {
            var fr = Convert.ToInt32(this.TextBoxEmccdFirstRow.Text, 10);
            var lr = Convert.ToInt32(this.TextBoxEmccdLastRow.Text, 10);
            var bs = 2 ^ this.ComboBoxEmccdVBinSize.SelectedIndex;
            if (fr > lr)
            {
                MessageBox.Show("First row index can't be more than last row index");
            }
            if (bs > (lr - fr))
            {
                MessageBox.Show("Vertical bin size must be smalled than used height");
            }
        }

        private void TextBoxEmccdCoolTimeout_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(this.TextBoxEmccdCoolTimeout.Text, 10) < 180)
            {
                MessageBox.Show("Cooling very unlikely to complete before timeout.");
            }
        }

        private void ButtonEmccdLoad_Click(object sender, RoutedEventArgs e)
        {
            RefreshEmccdControls();
        }

        #endregion

        #region Door

        private async void ButtonDoorLock_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.Door.Lock();
        }

        private async void ButtonDoorUnlock_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.Door.Unlock();
        }

        #endregion

        #region SerialNumber

        private async void ButtonSerialSet_Click(object sender, RoutedEventArgs e)
        {
            await this.instrument.SerialNumber.Write(this.TextBoxSerialNumber.Text);
        }

        private async void ButtonSerialGet_Click(object sender, RoutedEventArgs e)
        {
            this.TextBoxSerialNumber.Text = await this.instrument.SerialNumber.Read();
        }

        private async Task RefreshSerialNumber()
        {
            var serial = await this.instrument.SerialNumber.Read();
            this.TextBoxSerialNumber.Text = serial;
        }

        #endregion

        #region Lights

        private Boolean changedByUser = true;

        private async Task SetInteriorLights(IlluminationBoard illumBoard, ColourChannel colour, Int32 illumLevel)
        {
            foreach (Light light in Enum.GetValues(typeof(Light)))
            {
                await this.instrument.InteriorLights.SetIndividual(illumBoard, light, colour, illumLevel);
            }
        }

        private async void Board1RSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.A, ColourChannel.Red, (Int32)(sender as Slider).Value);
            }
        }


        private async void Board1GSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.A, ColourChannel.Green, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board1BSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.A, ColourChannel.Blue, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board2RSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.B, ColourChannel.Red, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board2GSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.B, ColourChannel.Green, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board2BSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.B, ColourChannel.Blue, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board3RSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.C, ColourChannel.Red, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board3GSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.C, ColourChannel.Green, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board3BSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.C, ColourChannel.Blue, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board4RSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.D, ColourChannel.Red, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board4GSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.D, ColourChannel.Green, (Int32)(sender as Slider).Value);
            }
        }

        private async void Board4BSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (changedByUser)
            {
                await this.SetInteriorLights(IlluminationBoard.D, ColourChannel.Blue, (Int32)(sender as Slider).Value);
            }
        }

        private async void LedMasterSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changedByUser = false;
            this.Board1RSlider.Value = (sender as Slider).Value;
            this.Board1GSlider.Value = (sender as Slider).Value;
            this.Board2RSlider.Value = (sender as Slider).Value;
            this.Board2GSlider.Value = (sender as Slider).Value;
            this.Board3RSlider.Value = (sender as Slider).Value;
            this.Board3GSlider.Value = (sender as Slider).Value;
            this.Board4RSlider.Value = (sender as Slider).Value;
            this.Board4GSlider.Value = (sender as Slider).Value;
            changedByUser = true;
            await this.instrument.InteriorLights.SetAll((Int32)(sender as Slider).Value);
        }

        private void ButtonLightsOn_Click(object sender, RoutedEventArgs e)
        {
            this.LedMasterSlider.Value = 0xFF;
        }

        private void ButtonLightsOff_Click(object sender, RoutedEventArgs e)
        {
            this.LedMasterSlider.Value = 0;
        }

        #endregion

        #region SpecimenHolderDrawer

        public Boolean IsSpecimenPresent { get; set; }
        public Boolean IsDrawerClosed { get; set; }

        #endregion Specimen

        #region DebugLed

        private Boolean outputDebugLed1;
        public Boolean OutputDebugLed1
        {
            get
            {
                return outputDebugLed1;
            }

            set
            {
                outputDebugLed1 = value;
                this.instrument.DebugLed.SetLed(DebugLedOutput.Led1, value);
            }
        }

        private Boolean outputDebugLed2;
        public Boolean OutputDebugLed2
        {
            get
            {
                return outputDebugLed2;
            }

            set
            {
                outputDebugLed2 = value;
                this.instrument.DebugLed.SetLed(DebugLedOutput.Led2, value);
            }
        }

        private Boolean outputDebugLed3;
        public Boolean OutputDebugLed3
        {
            get
            {
                return outputDebugLed3;
            }

            set
            {
                outputDebugLed3 = value;
                this.instrument.DebugLed.SetLed(DebugLedOutput.Led3, value);
            }
        }

        private Boolean outputDebugLed4;
        public Boolean OutputDebugLed4
        {
            get
            {
                return outputDebugLed4;
            }

            set
            {
                outputDebugLed4 = value;
                this.instrument.DebugLed.SetLed(DebugLedOutput.Led4, value);
            }
        }

        #endregion Debug Led

        #region IndicatorLeds

        private IndicatorStatus indicator = IndicatorStatus.Unknown;
        public IndicatorStatus Indicator
        {
            get
            {
                return indicator;
            }
            set
            {
                indicator = value;

#if LIGHTPATH_SIMULATOR
                this.instrument.IndicatorLeds.SetOutput(indicator, true);
#else
                this.instrument.IndicatorLeds.DisplayStatus(indicator);
#endif
            }
        }

        private Boolean indicatorDoorLocked;
        public Boolean IndicatorDoorLocked
        {
            get
            {
                return indicatorDoorLocked;
            }

            set
            {
                indicatorDoorLocked = value;
#if LIGHTPATH_SIMULATOR
                this.instrument.IndicatorLeds.SetOutput(IndicatorStatus.DoorLocked, value);
#else
                this.instrument.IndicatorLeds.DisplayDrawerLock(value);
#endif
            }
        }

        private Boolean indicatorSpecimeHolderPresent;
        public Boolean IndicatorSpecimenHolderPresent
        {
            get
            {
                return indicatorSpecimeHolderPresent;
            }
            set
            {
                indicatorSpecimeHolderPresent = value;
                this.instrument.IndicatorLeds.SetOutput(IndicatorStatus.SpecimenDetected, value);
            }
        }

        private Boolean automaticHeartbeat;
        public Boolean AutomaticHeartbeat
        {
            set
            {
                automaticHeartbeat = value;
            }
        }


        private async void ButtonKickWdtClick(object sender, RoutedEventArgs e)
        {
            await this.instrument.Heartbeat.Kick();
        }

        #endregion IndicatorLeds

        #region Misc
        public Boolean IsI2CBusOk { get; private set; }
        #endregion Misc

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.instrument.Emccd.StopVideo();
            if(null != cts) cts.Cancel();
        }

        private async Task RefreshOtherControls()
        {
            try
            {

                var doorIsLocked = await this.instrument.Door.IsLocked();
                var doorLockIsOk = await this.instrument.Door.IsLockOk();
                var offBoardTemp = await this.instrument.Casing.GetTemperature(TemperatureSensor.OffBoard);
                var onBoardTemp = await this.instrument.Casing.GetTemperature(TemperatureSensor.Onboard);
                var lightsAreOn = await this.instrument.InteriorLights.IsOn();
                var activeFilter = await this.instrument.FilterWheel.GetPosition();
                var fanIsRunning = await this.instrument.Fan.IsStarted();

                this.IsDrawerClosed = await this.instrument.SpecimenHolderDrawer.IsDrawerClosed();
                this.IsSpecimenPresent = await this.instrument.SpecimenHolderDrawer.HasSpecimen();


                String filterWheelStatus;
                switch (activeFilter)
                {
                    case FilterWheelPosition.Position1:
                        filterWheelStatus = "Position 1";
                        break;
                    case FilterWheelPosition.Position2:
                        filterWheelStatus = "Position 2";
                        break;
                    case FilterWheelPosition.Position3:
                        filterWheelStatus = "Position 3";
                        break;
                    case FilterWheelPosition.Position4:
                        filterWheelStatus = "Position 4";
                        break;
                    default:
                        filterWheelStatus = "Unknown";
                        break;
                }

                this.Dispatcher.Invoke(() =>
                {
                    //emccd camera temperature
                    this.LabelEmccdCurrentTemp.Content = String.Format("{0}", this.instrument.Emccd.DetectorTemperatureDegC);

                    //reference camera
                    this.SliderRefCamBlue.Value = this.instrument.ReferenceCamera.BlueGain;
                    this.SliderRefCamExposure.Value = this.instrument.ReferenceCamera.Exposure;
                    this.SliderRefCamGain.Value = this.instrument.ReferenceCamera.MasterGain;
                    this.SliderRefCamGreen.Value = this.instrument.ReferenceCamera.GreenGain;
                    this.SliderRefCamRed.Value = this.instrument.ReferenceCamera.RedGain;
                    this.CheckBoxRefCamAutoExp.IsChecked = this.instrument.ReferenceCamera.AutoExposureIsEnabled;
                    this.CheckBoxRefCamAutoGain.IsChecked = this.instrument.ReferenceCamera.AutoGainIsEnabled;
                    this.ComboBoxRefCamAwbMode.SelectedIndex = (Int32)this.instrument.ReferenceCamera.WhiteBalanceMode;

                    //door
                    this.LabelDoorIsLocked.Content = (doorIsLocked) ? "Locked" : "Unlocked";
                    this.LabelDoorLockIsOk.Content = (doorLockIsOk) ? "Lock OK" : "Lock Faulty";

                    //casing
                    this.TextBlockOffBoardTemp.Text = String.Format("Off board temp: {0:F1} degC", offBoardTemp);
                    this.TextBlockOnBoardTemp.Text = String.Format("On board temp: {0:F1} degC", onBoardTemp);

                    //fan
                    this.TextBlockFanStatus.Text = fanIsRunning ? "Fan on" : "Fan off";

                    //interior lights
                    this.LabelLightsStatus.Content = lightsAreOn ? "Lights on" : "Lights off";

                    //filter wheel
                    this.LabelFilterPosition.Content = filterWheelStatus;

                    //mirror
                    this.LabelMirrorStatus.Content = this.instrument.Mirror.IsAtEmccd ? "For EMCCD" : "For Reference";
                });

            }
            catch (Exception ex)
            {
                // Bullalog.ErrorFormat("Failed to update controls: {0}", ex.ToString());
            }

            this.IsI2CBusOk = this.instrument.IsI2CBusHealthy;

        }

        private CancellationToken GetNewCancellationToken()
        {
            if (cts != null)
            {
                cts.Cancel();
            }

            cts = new CancellationTokenSource();
            return cts.Token;
        }

        private async void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Debug.Print("{0} {1}", e.NewValue, e.OldValue);

            if (this.IsVisible)
            {
                RefreshEmccdControls();
                await RefreshSerialNumber();
            }
        }

        private void ButtonResetInstrumentHardware_Click(object sender, RoutedEventArgs e)
        {
            this.instrument.ResetHardware();
        }

        private void ButtonKickWdt_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    /// <summary>
    /// For converting enum to boolean values for binding to XAML checkbox or radiobuttons
    /// </summary>
    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
