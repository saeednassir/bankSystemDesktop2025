using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsTransactionType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enDebitCreditIndicator { Debit = 0, Credit = 1, Transfer = 2 };

        public int TransactionTypeID { set; get; }
        public string TypeName { set; get; }
        public string Description { set; get; }
        public enDebitCreditIndicator DebitCreditIndicator { set; get; }

        public clsTransactionType()
        {
            this.TransactionTypeID = -1;
            this.TypeName = "";
            this.Description = "";
            this.DebitCreditIndicator = enDebitCreditIndicator.Debit;

            Mode = enMode.AddNew;

        }

        private clsTransactionType(int TransactionTypeID, string TypeName,
            string Description, enDebitCreditIndicator DebitCreditIndicator)
        {
            this.TransactionTypeID = TransactionTypeID;
            this.TypeName = TypeName;
            this.Description = Description;
            this.DebitCreditIndicator = DebitCreditIndicator;

            Mode = enMode.Update;
        }

        public static clsTransactionType Find(int TransactionTypeID)
        {
            string TypeName = "", Description = "";
            byte DebitCreditIndicator = 0;

            bool IsFound = TransactionTypesDataAccess.GetTransactionTypeByID(TransactionTypeID, ref TypeName,
                ref Description, ref DebitCreditIndicator);

            if (IsFound)
                return new clsTransactionType(TransactionTypeID, TypeName, Description, (enDebitCreditIndicator)DebitCreditIndicator);
            else
                return null;

        }

        public static clsTransactionType Find(string TypeName)
        {
            int TransactionTypeID = -1;
            string Description = "";
            byte DebitCreditIndicator = 0;

            bool IsFound = TransactionTypesDataAccess.GetTransactionTypeByID(TransactionTypeID, ref TypeName,
                ref Description, ref DebitCreditIndicator);

            if (IsFound)
                return new clsTransactionType(TransactionTypeID, TypeName, Description, (enDebitCreditIndicator)DebitCreditIndicator);
            else
                return null;

        }

        private bool _AddNewTransactionType()
        {
            this.TransactionTypeID = TransactionTypesDataAccess.AddNewTransactionType(TypeName, Description, (byte)DebitCreditIndicator);
            return (this.TransactionTypeID != -1);
        }
        private bool _UpdateTransactionType()
        {
            return TransactionTypesDataAccess.UpdateTransactionType(TransactionTypeID, TypeName, Description, (byte)DebitCreditIndicator);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransactionType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTransactionType();

            }

            return false;
        }

        public static bool DeleteTransactionType(int ID)
        {
            return TransactionTypesDataAccess.DeleteTransactionType(ID);
        }

        public static bool isTransactionTypeExist(int ID)
        {
            return TransactionTypesDataAccess.IsTransactionTypeExistByID(ID);
        }

        public static DataTable GetAllTransactionTypes()
        {
            return TransactionTypesDataAccess.GetAllTransactionTypes();
        }

    }
}
