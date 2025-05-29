using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsAccountType
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string Description { set; get; }
        public decimal MinimumBalance { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreatedAt { set; get; }

        public clsAccountType()
        {
            this.ID = -1;
            this.Name = "";
            this.Code = "";
            this.Description = "";
            this.MinimumBalance = 0;
            this.IsActive = true;
            this.CreatedAt = DateTime.Now;

            Mode = enMode.AddNew;

        }

        private clsAccountType(int ID, string Name, string Code, string Description,
            decimal MinimumBalance, bool IsActive, DateTime CreatedAt)
        {
            this.ID = ID;
            this.Name = Name;
            this.Code = Code;
            this.Description = Description;
            this.MinimumBalance = MinimumBalance;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;

            Mode = enMode.Update;
        }

        public static clsAccountType Find(int ID)
        {
            string Name = "", Code = "", Description = "";
            decimal MinimumBalance = 0;
            bool IsActive = true;
            DateTime CreatedAt = DateTime.Now;

            bool IsFound = AccountTypesDataAccess.GetAccountTypeByID(ID, ref Name, ref Code,
                ref Description, ref MinimumBalance, ref IsActive, ref CreatedAt);

            if (IsFound)
                return new clsAccountType(ID, Name, Code, Description, MinimumBalance,
                    IsActive, CreatedAt);
            else
                return null;

        }

        public static clsAccountType Find(string Name)
        {
            int ID = -1;
            string Code = "", Description = "";
            decimal MinimumBalance = 0;
            bool IsActive = true;
            DateTime CreatedAt = DateTime.Now;

            bool IsFound = AccountTypesDataAccess.GetAccountTypeByName(Name, ref ID, ref Code,
                ref Description, ref MinimumBalance, ref IsActive, ref CreatedAt);

            if (IsFound)
                return new clsAccountType(ID, Name, Code, Description, MinimumBalance,
                    IsActive, CreatedAt);
            else
                return null;



        }

        private bool _AddNewAccountType()
        {
            this.ID = AccountTypesDataAccess.AddNewAccountType(Name, Code, Description,
                MinimumBalance, IsActive, CreatedAt);
            return (this.ID != -1);
        }

        private bool _UpdateAccountType()
        {
            return AccountTypesDataAccess.UpdateAccountType(ID, Name, Code, Description,
                MinimumBalance, IsActive, CreatedAt);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAccountType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateAccountType();

            }

            return false;
        }


        public static bool DeleteAccountType(int ID)
        {
            return AccountTypesDataAccess.DeleteAccountType(ID);
        }

        public static bool isAccountTypeExist(int ID)
        {
            return AccountTypesDataAccess.IsAccountTypeExistByID(ID);
        }

        public static bool isAccountTypeExist(string Code)
        {
            return AccountTypesDataAccess.IsAccountTypeExistByCode(Code);
        }

        public static DataTable GetAllAccountTypes()
        {
            return AccountTypesDataAccess.GetAllAccountTypes();
        }


    }
}
