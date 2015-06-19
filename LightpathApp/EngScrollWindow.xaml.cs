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

using LightPath.Process; //High-level state-related methods and events as described in ISpecimenAnalyser.cs
using LightPath.InstrumentModel; //Instrument and component models for direct access (Engineering Interface functionality)

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for EngScrollWindow.xaml
    /// </summary>
    public partial class EngScrollWindow : Window
    {
        private SpecimenAnalyser theAnalyser;
        private ILightPathInstrument theInstrument;

        public EngScrollWindow()
        {
            InitializeComponent();

            theAnalyser = SpecimenAnalyser.Instance;
            theInstrument = theAnalyser.Instrument;
            EIViewPort.Content = new InternalEi(theInstrument);
        }
    }
}

