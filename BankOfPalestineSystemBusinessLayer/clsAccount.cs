using BankOfPalestineSystemDataAccessLayer;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsAccount
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enStatus { Pending = 0, Active = 1, Dormant = 2, Closed = 3, Frozen = 4 };

        public int ID { set; get; }
        public int BranchID { set; get; }
        public clsBranche BranchInfo;
        public int ClientID { set; get; }
        public clsClient ClientInfo;

        public string AccountNumber { set; get; }
        public int AccountTypeID { set; get; }
        public clsAccountType AccountTypeInfo;

        public decimal Balance { set; get; }
        public int CurrencyID { set; get; }
        public clsCurrency CurrencyInfo;
        public enStatus Status { set; get; }
        public string NicName { set; get; }
        public string SubAccount { set; get; }
        public string IBAN { set; get; }
        public DateTime OpenDate { set; get; }
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }
        public DateTime ClosedDate { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUser CreatedByUserInfo;



        public clsAccount()
        {

            this.ID = -1;
            this.BranchID = -1;
            this.ClientID = -1;
            this.AccountNumber = "";
            this.AccountTypeID = -1;
            this.Balance = 0;
            this.CurrencyID = -1;
            this.Status = enStatus.Active;
            this.NicName = "";
            this.SubAccount = "000";
            this.IBAN = "";
            this.OpenDate = DateTime.Now;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = new DateTime(1900, 01, 01);
            this.ClosedDate = new DateTime(1900, 01, 01);
            this.CreatedByUserID = this.ID;

            Mode = enMode.AddNew;
        }


        private clsAccount(int ID, int BranchID, int ClientID, string AccountNumber,
            int AccountTypeID, decimal Balance, int CurrencyID,
            enStatus Status, string NicName, string SubAccount, string IBAN,
            DateTime OpenDate, DateTime CreatedAt, DateTime UpdatedAt,
            DateTime ClosedDate, int CreatedByUserID)
        {

            this.ID = ID;
            this.BranchID = BranchID;
            this.BranchInfo = clsBranche.FindByID(BranchID);
            this.ClientID = ClientID;
            this.ClientInfo = clsClient.Find(ClientID);
            this.AccountNumber = AccountNumber;
            this.AccountTypeID = AccountTypeID;
            this.AccountTypeInfo = clsAccountType.Find(AccountTypeID);
            this.Balance = Balance;
            this.CurrencyID = CurrencyID;
            this.CurrencyInfo = clsCurrency.FindByID(CurrencyID);
            this.Status = Status;
            this.NicName = NicName;
            this.SubAccount = SubAccount;
            this.IBAN = IBAN;
            this.OpenDate = OpenDate;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.ClosedDate = ClosedDate;
            this.CreatedByUserID = CreatedByUserID;
            if (CreatedByUserID != -1)
                this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);

            Mode = enMode.Update;
        }

        public string GetStatusName()
        {
            switch(Status)
            {
                case enStatus.Active:
                    return "فعال";
                case enStatus.Pending:
                    return "قيد المراجفة";
                case enStatus.Dormant:
                    return "خامل";
                case enStatus.Closed:
                    return "مغلق";
                case enStatus.Frozen:
                    return "مجمد";
                default:
                    return "غير موجود";
            }
        }

        public static clsAccount Find(int ID)
        {
            int BranchID = -1, ClientID = -1, AccountTypeID = -1,
                CurrencyID = -1, CreatedByUserID = -1;
            string AccountNumber = "", NicName = "", SubAccount = "", IBAN = "";
            decimal Balance = 0;
            DateTime OpenDate = DateTime.Now, CreatedAt = DateTime.Now,
                UpdatedAt = new DateTime(1900, 01, 01), ClosedDate = new DateTime(1900, 01, 01);
            short Status = 0;

            bool IsFound = AccountsDataAccess.GetAccountByID(ID, ref BranchID,
                ref ClientID, ref AccountNumber, ref AccountTypeID, ref Balance,
                ref CurrencyID, ref Status, ref NicName, ref SubAccount, ref IBAN, ref OpenDate,
                ref CreatedAt, ref UpdatedAt, ref ClosedDate, ref CreatedByUserID);

            if (IsFound)
                return new clsAccount(ID, BranchID, ClientID, AccountNumber,
                    AccountTypeID, Balance, CurrencyID, (enStatus)Status, NicName, SubAccount, IBAN,
                    OpenDate, CreatedAt, UpdatedAt, ClosedDate, CreatedByUserID);
            else
                return null;

        }

        public static clsAccount Find(int ClientID, string NicName)
        {
            int ID = -1, BranchID = -1, AccountTypeID = -1,
                 CurrencyID = -1, CreatedByUserID = -1;
            string AccountNumber = "", SubAccount = "", IBAN = "";
            decimal Balance = 0;
            DateTime OpenDate = DateTime.Now, CreatedAt = DateTime.Now,
                UpdatedAt = new DateTime(1900, 01, 01), ClosedDate = new DateTime(1900, 01, 01);
            short Status = 0;

            bool IsFound = AccountsDataAccess.GetAccountByClientIDAndNicName(ClientID, NicName, ref ID, ref BranchID,
                ref AccountNumber, ref AccountTypeID, ref Balance,
                ref CurrencyID, ref Status, ref SubAccount, ref IBAN, ref OpenDate,
                ref CreatedAt, ref UpdatedAt, ref ClosedDate, ref CreatedByUserID);

            if (IsFound)
                return new clsAccount(ID, BranchID, ClientID, AccountNumber,
                    AccountTypeID, Balance, CurrencyID, (enStatus)Status, NicName, SubAccount, IBAN,
                    OpenDate, CreatedAt, UpdatedAt, ClosedDate, CreatedByUserID);
            else
                return null;

        }

        public static clsAccount Find(string AccountNumber)
        {
            int ID = -1, BranchID = -1, ClientID = -1, AccountTypeID = -1,
                CurrencyID = -1, CreatedByUserID = -1;
            string NicName = "", SubAccount = "", IBAN = "";
            decimal Balance = 0;
            DateTime OpenDate = DateTime.Now, CreatedAt = DateTime.Now,
                UpdatedAt = new DateTime(1900, 01, 01), ClosedDate = new DateTime(1900, 01, 01);
            short Status = 0;

            bool IsFound = AccountsDataAccess.GetAccountByAccountNumber(AccountNumber, ref ID, ref BranchID,
                ref ClientID, ref AccountTypeID, ref Balance,
                ref CurrencyID, ref Status, ref NicName, ref SubAccount, ref IBAN, ref OpenDate,
                ref CreatedAt, ref UpdatedAt, ref ClosedDate, ref CreatedByUserID);

            if (IsFound)
                return new clsAccount(ID, BranchID, ClientID, AccountNumber,
                    AccountTypeID, Balance, CurrencyID, (enStatus)Status, NicName, SubAccount, IBAN,
                    OpenDate, CreatedAt, UpdatedAt, ClosedDate, CreatedByUserID);
            else
                return null;

        }

        private bool _AddNewAccount()
        {
            this.ID = AccountsDataAccess.AddNewAccount(BranchID, ClientID,
                AccountNumber, AccountTypeID, Balance, CurrencyID,
                (short)Status, NicName, SubAccount, IBAN, OpenDate,
                CreatedAt, UpdatedAt, ClosedDate, CreatedByUserID);
            return (this.ID != -1);
        }

        private bool _UpdateAccount()
        {
            return AccountsDataAccess.UpdateAccount(ID, BranchID, ClientID,
                AccountNumber, AccountTypeID, Balance, CurrencyID,
                (short)Status, NicName, SubAccount, IBAN, OpenDate,
                CreatedAt, UpdatedAt, ClosedDate, CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAccount())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateAccount();

            }

            return false;
        }

        public static bool DeleteAccount(int ID)
        {
            return AccountsDataAccess.DeleteAccount(ID);
        }

        public static bool isAccountExist(int ID)
        {
            return AccountsDataAccess.IsAccountExistByID(ID);
        }

        public static DataTable GetAllAccounts()
        {
            return AccountsDataAccess.GetAllAccounts();
        }

        public static DataTable GetAllAccountsForClient(int ClientID, enStatus Status)
        {
            return AccountsDataAccess.GetAllAccountsForClient(ClientID, (byte)Status);
        }

        public static DataTable GetAllAccountsForClient(string clientNumber)
        {
            return AccountsDataAccess.GetAllAccountsForClient(clientNumber);
        }

        public static int HowCountSubAccountForClient(int ClientID, int AccountTypeID, int CurrencyID)
        {
            return AccountsDataAccess.HowCountSubAccountsForClient(ClientID, AccountTypeID, CurrencyID);
        }

        public static decimal GetTotalBalancesByCurrency(int CurrencyID, enStatus stausAccount)
        {
            return AccountsDataAccess.GetTotalBalancesByCurrency(CurrencyID, (byte)stausAccount);
        }

        public static decimal GetTotalBalancesAllCurrencies(enStatus stausAccount)
        {
            decimal totalBalances = 0;

            DataTable dtCurrencies = clsCurrency.GetAllCurrencies();

            foreach(DataRow row in dtCurrencies.Rows)
            {  
                if(row["CodeCurrency"].ToString() != "PSP")
                {
                     decimal Rate = clsExchangeRate.GetExchangeRate((int)row["ID"], 11, (byte)clsExchangeRate.enRateType.MID_MARKET, DateTime.Now);
                    totalBalances += (GetTotalBalancesByCurrency((int)row["ID"], stausAccount)*Rate);
                }else
                    totalBalances += GetTotalBalancesByCurrency((int)row["ID"], stausAccount);
                
            }

            return totalBalances;
        }

        public static decimal GetCountAccountsByStatus(enStatus stausAccount)
        {
            return AccountsDataAccess.GetCountAccountsByStatus((byte)stausAccount);
        }

    }
}
