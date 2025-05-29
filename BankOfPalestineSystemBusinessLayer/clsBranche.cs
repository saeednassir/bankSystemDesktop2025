using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsBranche
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public int BankID { get; set; }
        public clsBank BankInfo;
        public int MangerID { get; set; }
        public clsEmployee MangerInfo;


        public clsBranche()
        {
            this.ID = -1;
            this.Code = "";
            this.Name = "";
            this.Address = "";
            this.PhoneNumber = "";
            this.OpeningDate = DateTime.Now;
            this.BankID = -1;
            this.MangerID = -1;
            Mode = enMode.AddNew;
        }

        private clsBranche(int ID, string Code, string Name, string Address,
            string PhoneNumber, DateTime OpeningDate, int BankID, int MangerID)
        {
            this.ID = ID;
            this.Code = Code;
            this.Name = Name;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            this.OpeningDate = OpeningDate;
            this.BankID = BankID;
            this.BankInfo = clsBank.Find(BankID);
            this.MangerID = MangerID;
            this.MangerInfo = clsEmployee.FindByID(MangerID);
            Mode = enMode.Update;
        }

        public static clsBranche FindByID(int ID)
        {
            string Code = "", Name = "", Address = "", PhoneNumber = "";
            DateTime OpeningDate = DateTime.Now;
            int BankID = -1, MangerID = -1;

            bool IsFound = BranchesDataAccess.GetBranchByID(ID, ref Code, ref Name,
                ref Address, ref PhoneNumber, ref OpeningDate,
                ref BankID, ref MangerID);

            if (IsFound)
                return new clsBranche(ID, Code, Name, Address, PhoneNumber, OpeningDate,
                 BankID, MangerID);
            else
                return null;

        }

        public static clsBranche FindByName(string Name)
        {
            string Code = "", Address = "", PhoneNumber = "";
            DateTime OpeningDate = DateTime.Now;
            int ID = -1, BankID = -1, MangerID = -1;

            bool IsFound = BranchesDataAccess.GetBranchByName(Name, ref ID, ref Code,
                ref Address, ref PhoneNumber, ref OpeningDate,
                ref BankID, ref MangerID);

            if (IsFound)
                return new clsBranche(ID, Code, Name, Address, PhoneNumber, OpeningDate,
                 BankID, MangerID);
            else
                return null;

        }
        public static clsBranche FindByCode(string Code)
        {
            string Name = "", Address = "", PhoneNumber = "";
            DateTime OpeningDate = DateTime.Now;
            int ID = -1, BankID = -1, MangerID = -1;

            bool IsFound = BranchesDataAccess.GetBranchByCode(Code, ref ID, ref Name,
                ref Address, ref PhoneNumber, ref OpeningDate,
                ref BankID, ref MangerID);

            if (IsFound)
                return new clsBranche(ID, Code, Name, Address, PhoneNumber, OpeningDate,
                 BankID, MangerID);
            else
                return null;

        }

        private bool _AddNewBranche()
        {
            this.ID = BranchesDataAccess.AddNewBranch(Code, Name, Address,
                PhoneNumber, OpeningDate, BankID, MangerID);
            return (this.ID != -1);
        }

        private bool _UpdateBranche()
        {
            return BranchesDataAccess.UpdateBranch(ID, Code, Name, Address,
                PhoneNumber, OpeningDate, BankID, MangerID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBranche())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateBranche();

            }

            return false;
        }

        public static bool DeleteBranche(int ID)
        {
            return BranchesDataAccess.DeleteBranch(ID);
        }

        public static bool isBrancheExist(int ID)
        {
            return BranchesDataAccess.IsBranchExistByID(ID);
        }

        public static DataTable GetAllBranches()
        {
            return BranchesDataAccess.GetAllBranches();
        }

        public static int GetCountBranches()
        {
            return BranchesDataAccess.GetCountBranches();
        }
    }
}
