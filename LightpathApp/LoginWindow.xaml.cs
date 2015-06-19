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

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {  
        }

        private void StartLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
