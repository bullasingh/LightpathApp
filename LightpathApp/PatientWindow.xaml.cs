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

using LightpathApp.Helper;

namespace LightpathApp
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        PatientDetails newPatientRecord;

        public PatientWindow(PatientDetails patientRecord)
        {
            InitializeComponent();
            Reset();
            FirstName.Text = patientRecord.firstName;
            LastName.Text = patientRecord.lastName;
            NhsNumber.Text = patientRecord.nhsNumber;
            NameOfStreet.Text = patientRecord.nameOfStreet;
            NameOfCity.Text = patientRecord.nameOfCity;
            NameOfCounty.Text = patientRecord.nameOfCounty;
            EntryPostCode.Text = patientRecord.postCode;
            DateOfBirth.Text = patientRecord.dateOfBirth;
            IsMarried.IsChecked = patientRecord.isMarried;
            newPatientRecord = patientRecord;
        }

        //
        // Save data for later use.
        //
        private void SavePatientData()
        {
            newPatientRecord.lastName = LastName.Text;
            newPatientRecord.firstName = FirstName.Text;
            newPatientRecord.nhsNumber = NhsNumber.Text;
            newPatientRecord.nameOfStreet = NameOfStreet.Text;
            newPatientRecord.nameOfCity = NameOfCity.Text;
            newPatientRecord.nameOfCounty = NameOfCounty.Text;
            newPatientRecord.postCode = EntryPostCode.Text;
            newPatientRecord.dateOfBirth = DateOfBirth.Text;
            newPatientRecord.isMarried = (Boolean)IsMarried.IsChecked;
        }

        //
        // Close entry window - data automatically saved by Window_Closing.
        //
        private void NewPatient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SavePatientData();
        }

        //
        // Same as clear for now.
        //
        private void LoadFromHis_Click(object sender, RoutedEventArgs e)
        {
            SavePatientData();
        }

        public void Reset()
        {
            FirstName.Text = "Bulla"; // String.Empty;
            LastName.Text = "Singh";  // String.Empty;
            NhsNumber.Text = "98734567";
            NameOfStreet.Text = "59 Kirklees Drive";
            NameOfCity.Text = "Leeds";
            NameOfCounty.Text = "West Yorkshire";
            EntryPostCode.Text = "LS28 5TD";
            DateOfBirth.Text = "09/10/1958";

            foreach (string patientName in patients)
            {
                NamePatients.Items.Add(patientName);
            }
            NamePatients.Text = NamePatients.Items[1] as string;

            IsMarried.IsChecked = true;
            //          dateOfBirth.Text = DateTime.Today.ToString();
        }

        private string[] patients = { "", "Bulla Singh", "Peter Brady", "Carl Warren" };

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            FirstName.Text = String.Empty;
            LastName.Text = String.Empty;
            NhsNumber.Text = String.Empty;
            NameOfStreet.Text = String.Empty;
            NameOfCity.Text = String.Empty;
            NameOfCounty.Text = String.Empty;
            EntryPostCode.Text = String.Empty;
            DateOfBirth.Text = String.Empty;
            NamePatients.Text = NamePatients.Items[0] as string;

            IsMarried.IsChecked = false;
            DateOfBirth.Text = DateTime.Today.ToString();
        }
    }
}


