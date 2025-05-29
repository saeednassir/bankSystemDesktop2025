using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsCurrency
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }
        public string CurrencyNumber { set; get; }
        public string CodeCurrency { set; get; }
        public int CountryID { set; get; }
        public clsCountry CountryInfo;

        public string CurrencySymbol { set; get; }
        public byte DecimalPlaces { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreatedAt { set; get; }
        public DateTime UpdateAt { set; get; }
        public int CreateBy { set; get; }
        public int UpdateBy { set; get; }

        public clsCurrency()
        {
            this.ID = -1;
            this.Name = "";
            this.CurrencyNumber = "";
            this.CodeCurrency = "";
            this.CountryID = -1;

            this.CurrencySymbol = "";
            this.DecimalPlaces = 2;
            this.IsActive = true;
            this.CreatedAt = DateTime.Now;
            this.UpdateAt = new DateTime(1900, 01, 01);
            this.CreateBy = -1;
            this.UpdateBy = -1;

            Mode = enMode.AddNew;

        }

        private clsCurrency(int ID, string Name, string CurrencyNumber, string CodeCurrency,
            int CountryID, string CurrencySymbol, byte DecimalPlaces,
            bool IsActive, DateTime CreatedAt, DateTime UpdateAt, int CreateBy,
            int UpdateBy)
        {
            this.ID = ID;
            this.Name = Name;
            this.CurrencyNumber = CurrencyNumber;
            this.CodeCurrency = CodeCurrency;
            this.CountryID = CountryID;
            this.CountryInfo = clsCountry.Find(CountryID);
            this.CurrencySymbol = CurrencySymbol;
            this.DecimalPlaces = DecimalPlaces;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdateAt = UpdateAt;
            this.CreateBy = CreateBy;
            this.UpdateBy = UpdateBy;

            Mode = enMode.Update;
        }

        public static clsCurrency FindByID(int ID)
        {
            int CountryID = -1, CreateBy = -1, UpdateBy = -1;

            string Name = "", CurrencyNumber = "", CodeCurrency = "", CurrencySymbol = "";
            byte DecimalPlaces = 2;
            bool IsActive = true;
            DateTime CreatedAt = DateTime.Now, UpdateAt = new DateTime(1900, 01, 01);

            bool IsFound = CurrenciesDataAccess.GetCurrencyByID(ID, ref Name,
                ref CurrencyNumber, ref CodeCurrency, ref CountryID,
                ref CurrencySymbol, ref DecimalPlaces, ref IsActive,
                ref CreatedAt, ref UpdateAt, ref CreateBy, ref UpdateBy);

            if (IsFound)
                return new clsCurrency(ID, Name,
                 CurrencyNumber, CodeCurrency, CountryID,
                 CurrencySymbol, DecimalPlaces, IsActive, CreatedAt,
                 UpdateAt, CreateBy, UpdateBy);
            else
                return null;

        }

        public static clsCurrency FindByCurrencyNumber(string CurrencyNumber)
        {
            int ID = -1, CountryID = -1, CreateBy = -1, UpdateBy = -1;

            string Name = "", CodeCurrency = "", CurrencySymbol = "";
            byte DecimalPlaces = 2;
            bool IsActive = true;
            DateTime CreatedAt = DateTime.Now, UpdateAt = new DateTime(1900, 01, 01);

            bool IsFound = CurrenciesDataAccess.GetCurrencyByCurrencyNumber(CurrencyNumber, ref ID, ref Name,
                ref CodeCurrency, ref CountryID,
                ref CurrencySymbol, ref DecimalPlaces, ref IsActive,
                ref CreatedAt, ref UpdateAt, ref CreateBy, ref UpdateBy);

            if (IsFound)
                return new clsCurrency(ID, Name,
                 CurrencyNumber, CodeCurrency, CountryID,
                 CurrencySymbol, DecimalPlaces, IsActive, CreatedAt,
                 UpdateAt, CreateBy, UpdateBy);
            else
                return null;



        }

        public static clsCurrency FindByCodeCurrency(string CodeCurrency)
        {
            int ID = -1, CountryID = -1, CreateBy = -1, UpdateBy = -1;

            string Name = "", CurrencyNumber = "", CurrencySymbol = "";
            byte DecimalPlaces = 2;
            bool IsActive = true;
            DateTime CreatedAt = DateTime.Now, UpdateAt = new DateTime(1900, 01, 01);

            bool IsFound = CurrenciesDataAccess.GetCurrencyByCodeCurrency(CodeCurrency, ref ID, ref Name,
                ref CurrencyNumber, ref CountryID,
                ref CurrencySymbol, ref DecimalPlaces, ref IsActive,
                ref CreatedAt, ref UpdateAt, ref CreateBy, ref UpdateBy);

            if (IsFound)
                return new clsCurrency(ID, Name,
                 CurrencyNumber, CodeCurrency, CountryID,
                 CurrencySymbol, DecimalPlaces, IsActive, CreatedAt,
                 UpdateAt, CreateBy, UpdateBy);
            else
                return null;



        }


        private bool _AddNewCurrency()
        {
            this.ID = CurrenciesDataAccess.AddNewCurrency(Name, CurrencyNumber,
                CodeCurrency, CountryID, CurrencySymbol, DecimalPlaces,
                IsActive, CreatedAt, UpdateAt, CreateBy, UpdateBy);
            return (this.ID != -1);
        }

        private bool _UpdateCurrency()
        {
            return CurrenciesDataAccess.UpdateCurrency(ID, Name, CurrencyNumber,
                CodeCurrency, CountryID, CurrencySymbol, DecimalPlaces,
                IsActive, CreatedAt, UpdateAt, CreateBy, UpdateBy);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCurrency())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateCurrency();

            }

            return false;
        }


        public static bool DeleteCurrency(int ID)
        {
            return CurrenciesDataAccess.DeleteCurrency(ID);
        }

        public static bool isCurrencyExist(int ID)
        {
            return CurrenciesDataAccess.IscurrencyExistByID(ID);
        }

        public static DataTable GetAllCurrencies()
        {
            return CurrenciesDataAccess.GetAllCurrencies();
        }



    }
}
