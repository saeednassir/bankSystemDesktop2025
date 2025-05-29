using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enGender { Male = 0, Female = 1 };

        public int PersonID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecoundName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecoundName + " " + ThirdName + " " + LastName; }

        }
        public enGender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int NationalityID { get; set; }
        public clsCountry CountryInfo { get; set; }
        public DateTime DateOfBirth { get; set; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecoundName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.PhoneNumber = "";
            this.Email = "";
            this.Address = "";
            this.NationalityID = -1;
            this.DateOfBirth = DateTime.Now;

            Mode = enMode.AddNew;

        }

        private clsPerson(int PersonID, string NationalNumber, string FirstName,
            string SecoundName, string ThirdName, string LastName, enGender Gender,
            string PhoneNumber, string Email, string Address, int NationalityID,
            DateTime DateOfBirth)
        {
            this.PersonID = PersonID;
            this.NationalNumber = NationalNumber;
            this.FirstName = FirstName;
            this.SecoundName = SecoundName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Address = Address;
            this.NationalityID = NationalityID;
            this.CountryInfo = clsCountry.Find(NationalityID);
            this.DateOfBirth = DateOfBirth;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = PeopleDataAccess.AddNewPerson(this.NationalNumber,
                this.FirstName, this.SecoundName, this.ThirdName,
                this.LastName, (short)this.Gender,
                this.PhoneNumber, this.Email, this.Address, this.NationalityID,
                this.DateOfBirth);

            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return PeopleDataAccess.UpdatePerson(this.PersonID, this.NationalNumber,
                this.FirstName, this.SecoundName, this.ThirdName,
                this.LastName, (short)this.Gender,
                this.PhoneNumber, this.Email, this.Address, this.NationalityID,
                this.DateOfBirth);
        }

        public static clsPerson Find(int PersonID)
        {

            string NationalNumber = "", FirstName = "", SecoundName = "",
                ThirdName = "", LastName = "", PhoneNumber = "", Email = "", Address = "";

            DateTime DateOfBirth = DateTime.Now;
            int NationalityID = -1;
            short Gender = 0;

            bool IsFound = PeopleDataAccess.GetPersonByID
                                (
                                    PersonID, ref NationalNumber, ref FirstName, ref SecoundName,
                                    ref ThirdName, ref LastName, ref Gender, ref PhoneNumber,
                                    ref Email, ref Address, ref NationalityID, ref DateOfBirth
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsPerson(PersonID, NationalNumber, FirstName, SecoundName,
                                    ThirdName, LastName, (enGender)Gender, PhoneNumber,
                                    Email, Address, NationalityID, DateOfBirth);
            else
                return null;
        }

        public static clsPerson Find(string NationalNumber)
        {
            int PersonID = -1;
            string FirstName = "", SecoundName = "",
                ThirdName = "", LastName = "", PhoneNumber = "", Email = "", Address = "";

            DateTime DateOfBirth = DateTime.Now;
            int NationalityID = -1;
            short Gender = 0;

            bool IsFound = PeopleDataAccess.GetPersonByNationalNumber
                                (
                                    NationalNumber, ref PersonID, ref FirstName, ref SecoundName,
                                    ref ThirdName, ref LastName, ref Gender, ref PhoneNumber,
                                    ref Email, ref Address, ref NationalityID, ref DateOfBirth
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsPerson(PersonID, NationalNumber, FirstName, SecoundName,
                                    ThirdName, LastName, (enGender)Gender, PhoneNumber,
                                    Email, Address, NationalityID, DateOfBirth);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }

        public static DataTable GetAllPeople()
        {
            return PeopleDataAccess.GetAllPeople();
        }
        public static bool DeletePerson(int ID)
        {
            return PeopleDataAccess.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return PeopleDataAccess.IsPersonExistByID(ID);
        }

        public static bool isPersonExist(string NationlNo)
        {
            return PeopleDataAccess.IsPersonExistByNationalNumber(NationlNo);
        }
    }
}
