using System;
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

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightpathApp
{
    namespace Helper
    {
        public class PatientDetails
        {
            private String _firstName;
            private String _lastName;
            private String _nhsNumber;
            private String _nameOfStreet;
            private String _nameOfCity;
            private String _nameOfCounty;
            private String _postCode;
            private String _dateOfBirth;
            private Boolean _isMarried;

            public Boolean isMarried
            {
                get { return _isMarried; }
                set { _isMarried = value; }
            }


            public string postCode
            {
                get { return _postCode; }
                set { _postCode = value; }
            }

            public string dateOfBirth
            {
                get { return _dateOfBirth; }
                set { _dateOfBirth = value; }
            }

            public string nameOfCity
            {
                get { return _nameOfCity; }
                set { _nameOfCity = value; }
            }

            public string nameOfCounty
            {
                get { return _nameOfCounty; }
                set { _nameOfCounty = value; }
            }

            public string firstName
            {
                get { return _firstName; }
                set { _firstName = value; }
            }

            public string lastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }

            public string nhsNumber
            {
                get { return _nhsNumber; }
                set { _nhsNumber = value; }
            }

            public string nameOfStreet
            {
                get { return _nameOfStreet; }
                set { _nameOfStreet = value; }
            }


            public PatientDetails()
            {
                _firstName = "Test";
                _lastName = "Data";
            }
        }
    }
}
