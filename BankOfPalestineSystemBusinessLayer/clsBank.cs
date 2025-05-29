using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsBank
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string SwiftCode { set; get; }


        public clsBank()
        {
            this.ID = -1;
            this.Name = "";
            this.Address = "";
            this.SwiftCode = "";

            Mode = enMode.AddNew;

        }

        private clsBank(int ID, string Name, string Address, string SwiftCode)
        {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
            this.SwiftCode = SwiftCode;

            Mode = enMode.Update;
        }


        public static clsBank Find(int ID)
        {
            string Name = "", Address = "", SwiftCode = "";

            bool IsFound = BanksDataAccess.GetBankByID(ID, ref Name,
                ref Address, ref SwiftCode);

            if (IsFound)
                return new clsBank(ID, Name, Address, SwiftCode);
            else
                return null;

        }

        public static clsBank Find(string Name)
        {
            int ID = -1;
            string Address = "", SwiftCode = "";

            bool IsFound = BanksDataAccess.GetBankByName(Name, ref ID,
                ref Address, ref SwiftCode);

            if (IsFound)
                return new clsBank(ID, Name, Address, SwiftCode);
            else
                return null;

        }

        private bool _AddNewBank()
        {
            this.ID = BanksDataAccess.AddNewBank(Name, Address, SwiftCode);
            return (this.ID != -1);
        }

        private bool _UpdateBank()
        {
            return BanksDataAccess.UpdateBank(ID, Name, Address, SwiftCode);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBank())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateBank();

            }

            return false;
        }

        public static bool DeleteBank(int ID)
        {
            return BanksDataAccess.DeleteBank(ID);
        }

        public static bool isBankExist(int ID)
        {
            return BanksDataAccess.IsBankExistByID(ID);
        }

        public static DataTable GetAllBanks()
        {
            return BanksDataAccess.GetAllBanks();
        }




    }
}
