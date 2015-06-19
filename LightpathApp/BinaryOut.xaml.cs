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
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using PropertyChanged;

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for BinaryOut.xaml
    /// </summary>
    [ImplementPropertyChanged]
    public partial class BinaryOut
    {
        public static readonly DependencyProperty IsSetProperty = DependencyProperty.Register("IsSet", typeof(Boolean?), typeof(BinaryOut), new FrameworkPropertyMetadata { BindsTwoWayByDefault = true });
        private readonly Color disabledColor = Colors.Gray;
        private readonly Color ledOffColor = Colors.Black;
        private readonly Color ledDefaultColor = Colors.Red;

        public BinaryOut()
        {
            InitializeComponent();

            //this.DataContext = this;
            LayoutRoot.DataContext = this;

            this.FillColor = new SolidColorBrush(disabledColor);
            this.LedColor = new SolidColorBrush(ledDefaultColor);

            //A handler to value change is required because when IsSet in this usercontrol is data-bound into 
            //the main application in MainWindow i.e. <local:BinaryOut  Caption="Door lock" IsSet="{Binding OutputDoorIsLocked}"/>
            //Changing the value of OutputDoorIsLocked implicitly cause the SetValue for IsSetProperty to be call, without actually
            //triggering the IsSet::Set property!!.
            var dpd = DependencyPropertyDescriptor.FromProperty(IsSetProperty, typeof(BinaryOut));
            dpd.AddValueChanged(this, (sender, args) =>
            {
                var binaryOut = sender as BinaryOut;
                if (binaryOut != null) ColoriseLed(binaryOut.IsSet);
            });

        }

        public String Caption {get;set;}

        public SolidColorBrush FillColor { get; set; }

        public SolidColorBrush LedColor { get; set; }

        public Boolean? IsSet
        {
            get
            {
                return (Boolean?)GetValue(IsSetProperty);
            }

            set
            {
                SetValue(IsSetProperty, value);
                ColoriseLed(value);
            }
        }

        private void ColoriseLed(Boolean? isOn)
        {
            if (isOn.HasValue)
            {
                FillColor.Color = isOn.Value ? this.LedColor.Color : ledOffColor;
            }
            else
            {
                FillColor.Color = ledDefaultColor;
            }
        }

    }
}
