using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebScraper
{
     class Person
    {
       public Person(string FirstName, string LastName, int Age, int EyeColor, int HairColor)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.EyeColor = EyeColor;
            this.HairColor = HairColor;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int EyeColor { get; set; }
        public int HairColor { get; set; }


    }
}

//    private string _ssn;
    //    private string _passportData;
    //    private string _driversLicenseNumber;

    //    public Person(string ssn, string passportData, string driversLicenseNumber)
    //    {
    //        _ssn = ssn;
    //        _passportData = passportData;
    //        _driversLicenseNumber = driversLicenseNumber;
    //    }

    //    public bool HasProperDocuments 
    //    { 
    //        get
    //        {
    //            return _ssn.Length > 0 && _passportData.Length > 0 && _driversLicenseNumber.Length > 0;
    //        }
    //    }
        //public string FirstName
        //{
        //    get
        //    {
        //        return _firstName;
        //    }
        //    set
        //    {
        //        if(value.Length < 1)
        //        {
        //            Console.WriteLine("Input is not accepted");
        //            //branching statement
        //            return;
        //        }

        //        _firstName = value;
                
        //    }
        //}
        //public string LastName {
        //    get
        //    {
        //        return _lastName;
        //    }
        //    set
        //    {
        //        if (value.Length < 1)
        //        {
        //            Console.WriteLine("Input is not accepted");
        //            //branching statement
        //            return;
        //        }

        //        _lastName = value;

        //    }
        //}
    

