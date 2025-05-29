using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsTransaction
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enStatus { Pending = 0, Completed = 1, Failed = 2, Reversed = 3 }

        public int ID { set; get; }
        public int TransactionTypeID { set; get; }
        public clsTransactionType TransactionTypeInfo;
        public int SourceAccountID { set; get; }
        public clsAccount SourceAccountInfo;

        public int DestinationAccountID { set; get; }
        public clsAccount DestinationAccountInfo;

        public decimal Amount { set; get; }
        public int CurrencyID { set; get; }
        public clsCurrency CurrencyInfo;

        public DateTime TransactionDateTime { set; get; }
        public string Description { set; get; }
        public string ReferenceNumber { set; get; }
        public enStatus Status { set; get; }
        public decimal ExchangeRateUsed { set; get; }
        public decimal FeeAmount { set; get; }
        public int FeeCurrencyID { set; get; }
        public clsCurrency FeeCurrencyInfo;

        public DateTime CreatedAt { set; get; }
        public int CreatedByUser { set; get; }
        public clsUser CreatedByUserInfo;

        public int AffectedCard { set; get; }
        public clsCard AffectedCardInfo;



        public clsTransaction()
        {
            this.ID = -1;
            this.TransactionTypeID = -1;
            this.SourceAccountID = -1;
            this.DestinationAccountID = -1;
            this.Amount = 0;
            this.CurrencyID = -1;
            this.TransactionDateTime = DateTime.Now;
            this.Description = "";
            this.ReferenceNumber = "";
            this.Status = enStatus.Pending;
            this.ExchangeRateUsed = 0;
            this.FeeAmount = 0;
            this.FeeCurrencyID = -1;
            this.CreatedAt = DateTime.Now;
            this.CreatedByUser = -1;
            this.AffectedCard = -1;


            Mode = enMode.AddNew;
        }

        private clsTransaction(int ID, int TransactionTypeID,
                 int SourceAccountID, int DestinationAccountID, decimal Amount,
                 int CurrencyID, DateTime TransactionDateTime, string Description,
                 string ReferenceNumber, byte Status, decimal ExchangeRateUsed,
                 decimal FeeAmount, int FeeCurrencyID, DateTime CreatedAt,
                 int CreatedByUser, int AffectedCard)
        {
            this.ID = ID;
            this.TransactionTypeID = TransactionTypeID;
            this.TransactionTypeInfo = clsTransactionType.Find(TransactionTypeID);

            this.SourceAccountID = SourceAccountID;
            this.SourceAccountInfo = clsAccount.Find(SourceAccountID);

            this.DestinationAccountID = DestinationAccountID;
            this.DestinationAccountInfo = clsAccount.Find(DestinationAccountID);

            this.Amount = Amount;
            this.CurrencyID = CurrencyID;
            this.CurrencyInfo = clsCurrency.FindByID(CurrencyID);

            this.TransactionDateTime = TransactionDateTime;
            this.Description = Description;
            this.ReferenceNumber = ReferenceNumber;
            this.Status = (enStatus)Status;
            this.ExchangeRateUsed = ExchangeRateUsed;
            this.FeeAmount = FeeAmount;
            this.FeeCurrencyID = FeeCurrencyID;
            this.FeeCurrencyInfo = clsCurrency.FindByID(FeeCurrencyID);

            this.CreatedAt = CreatedAt;
            this.CreatedByUser = CreatedByUser;
            this.CreatedByUserInfo = clsUser.Find(CreatedByUser);

            this.AffectedCard = AffectedCard;
            this.AffectedCardInfo = clsCard.Find(AffectedCard);

            Mode = enMode.Update;
        }


        public static clsTransaction Find(int ID)
        {
            int TransactionTypeID = -1, SourceAccountID = -1, DestinationAccountID = -1,
                CurrencyID = -1, FeeCurrencyID = -1, CreatedByUser = -1, AffectedCard = -1;

            decimal Amount = 0, ExchangeRateUsed = 0, FeeAmount = 0;

            DateTime TransactionDateTime = DateTime.Now, CreatedAt = DateTime.Now;

            string Description = "", ReferenceNumber = "";

            byte Status = (byte)enStatus.Pending;


            bool IsFound = TransactionsDataAccess.GetTransactionsByID(ID, ref TransactionTypeID,
                ref SourceAccountID, ref DestinationAccountID, ref Amount, ref CurrencyID,
                ref TransactionDateTime, ref Description, ref ReferenceNumber, ref Status,
                ref ExchangeRateUsed, ref FeeAmount, ref FeeCurrencyID, ref CreatedAt,
                ref CreatedByUser, ref AffectedCard);

            if (IsFound)
                return new clsTransaction(ID, TransactionTypeID,
                 SourceAccountID, DestinationAccountID, Amount, CurrencyID,
                 TransactionDateTime, Description, ReferenceNumber, Status,
                 ExchangeRateUsed, FeeAmount, FeeCurrencyID, CreatedAt,
                 CreatedByUser, AffectedCard);
            else
                return null;

        }

        public static clsTransaction Find(string ReferenceNumber)
        {
            int ID = -1, TransactionTypeID = -1, SourceAccountID = -1, DestinationAccountID = -1,
               CurrencyID = -1, FeeCurrencyID = -1, CreatedByUser = -1, AffectedCard = -1;

            decimal Amount = 0, ExchangeRateUsed = 0, FeeAmount = 0;

            DateTime TransactionDateTime = DateTime.Now, CreatedAt = DateTime.Now;

            string Description = "";

            byte Status = (byte)enStatus.Pending;


            bool IsFound = TransactionsDataAccess.GetTransactionsByID(ID, ref TransactionTypeID,
                ref SourceAccountID, ref DestinationAccountID, ref Amount, ref CurrencyID,
                ref TransactionDateTime, ref Description, ref ReferenceNumber, ref Status,
                ref ExchangeRateUsed, ref FeeAmount, ref FeeCurrencyID, ref CreatedAt,
                ref CreatedByUser, ref AffectedCard);

            if (IsFound)
                return new clsTransaction(ID, TransactionTypeID,
                 SourceAccountID, DestinationAccountID, Amount, CurrencyID,
                 TransactionDateTime, Description, ReferenceNumber, Status,
                 ExchangeRateUsed, FeeAmount, FeeCurrencyID, CreatedAt,
                 CreatedByUser, AffectedCard);
            else
                return null;

        }

        private bool _AddNewTransaction()
        {
            this.ID = TransactionsDataAccess.AddNewTransaction(TransactionTypeID,
                 SourceAccountID, DestinationAccountID, Amount, CurrencyID,
                 TransactionDateTime, Description, ReferenceNumber, (byte)Status,
                 ExchangeRateUsed, FeeAmount, FeeCurrencyID, CreatedAt,
                 CreatedByUser, AffectedCard);
            return (this.ID != -1);
        }
        private bool _UpdateTransaction()
        {
            return TransactionsDataAccess.UpdateTransaction(ID, TransactionTypeID,
                 SourceAccountID, DestinationAccountID, Amount, CurrencyID,
                 TransactionDateTime, Description, ReferenceNumber, (byte)Status,
                 ExchangeRateUsed, FeeAmount, FeeCurrencyID, CreatedAt,
                 CreatedByUser, AffectedCard);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransaction())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTransaction();

            }

            return false;
        }

        public static bool DeleteTransaction(int ID)
        {
            return TransactionsDataAccess.DeleteTransaction(ID);
        }

        public static bool isTransactionExist(int ID)
        {
            return TransactionsDataAccess.IsTransactionExistByID(ID);
        }

        public static DataTable GetAllTransactions()
        {
            return TransactionsDataAccess.GetAllTransactions();
        }
        public static DataTable GetAllTransactionsForAccount(int AccountId)
        {
            return TransactionsDataAccess.GetAllTransactionsForAccount(AccountId);

        }

        public static bool Deposit(decimal amountToCreditInAccountCurrency, int AccountID,
            decimal ExchangeRateUsed, int CreatedByUser, int AffectedCard, decimal Amount, int CurrencyID)
        {
            return TransactionsDataAccess.Deposit(amountToCreditInAccountCurrency, AccountID,
                ExchangeRateUsed, CreatedByUser, AffectedCard,Amount,CurrencyID);
        }

        public static  bool Withdrawal (decimal amountToCreditInAccountCurrency, int AccountID,
            decimal ExchangeRateUsed, int CreatedByUser, int AffectedCard, decimal Amount, int CurrencyID)
        {
            return TransactionsDataAccess.Withdrawal(amountToCreditInAccountCurrency, AccountID,
                ExchangeRateUsed, CreatedByUser, AffectedCard, Amount, CurrencyID);
        }
        public static bool TransferBetweenAccounts(decimal amountToCreditInAccountCurrency,
            int sourceAccountId,
           int destinationAccountId, decimal Amount, int CurrencyID,
           int CreatedByUser, decimal ExchangeRateUsed,string Description)
        {
            return TransactionsDataAccess.TransferBetweenAccounts(amountToCreditInAccountCurrency,sourceAccountId
                ,destinationAccountId,Amount,CurrencyID,CreatedByUser, ExchangeRateUsed, Description);
        }

        public static decimal GetTotalBalancesForTrasactions(int TransactionTypeID,
            int CurrencyID, enStatus Status, DateTime FromDate, DateTime ToDate)
        {
            return TransactionsDataAccess.GetTotalBalancesForTrasactions(TransactionTypeID,
                CurrencyID,(byte)Status,FromDate,ToDate);
        }

        public static decimal GetTotalBalancesAccordingToPSPCurrency(int TransactionTypeID,
            enStatus Status, DateTime FromDate, DateTime ToDate)
        {
            decimal totalBalancePSP = 0;

            DataTable dtAllCurrecies = clsCurrency.GetAllCurrencies();

            foreach (DataRow row in dtAllCurrecies.Rows)
            {
                int CurrencyID = (int)row["ID"];

                if(row["CodeCurrency"].ToString() != "PSP")
                {
                    decimal rate = clsExchangeRate.GetExchangeRate(CurrencyID, 11, 2, DateTime.Now);
                    decimal totalDefferntCurrency = GetTotalBalancesForTrasactions(TransactionTypeID,
                    CurrencyID, Status, FromDate, ToDate);
                    totalBalancePSP += (rate*totalDefferntCurrency);
                }
                else
                {
                    totalBalancePSP += GetTotalBalancesForTrasactions(TransactionTypeID,
                    CurrencyID, Status, FromDate, ToDate);
                }

            }

            return totalBalancePSP;
        }


        public static decimal GetCountTransactions(DateTime fromDate, DateTime ToDate, enStatus stauts)
        {
            return TransactionsDataAccess.GetCountTransactions(fromDate, ToDate, (byte)stauts);
        }
    }
}
