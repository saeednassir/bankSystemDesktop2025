using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsCard
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string NameOnCard { set; get; }
        public string CardNumber { set; get; }
        public string CVVNumber { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpierdDate { set; get; }
        public int AccountLinked { set; get; }
        public clsAccount AccountLinkedInfo;
        public bool IsActive { set; get; }
        public int CreatedByUser { set; get; }
        public clsUser CreatedByUserInfo;
        public string PinCode { set; get; }
        public int CardTypeID { set; get; }
        public clsCardType CardTypeInfo { set; get; }

        public clsCard()
        {
            this.ID = -1;
            this.NameOnCard = "";
            this.CardNumber = "";
            this.CVVNumber = "";
            this.IssueDate = DateTime.Now;
            this.ExpierdDate = DateTime.Now.AddYears(5);
            this.AccountLinked = -1;
            this.IsActive = true;
            this.CreatedByUser = -1;
            this.PinCode = "";
            this.CardTypeID = -1;

            Mode = enMode.AddNew;

        }


        private clsCard(int ID,string NameOnCard, string CardNumber, string CVVNumber,
            DateTime IssueDate, DateTime ExpierdDate, int AccountLinked,
            bool IsActive, int CreatedByUser, string PinCode, int CardTypeID)
        {
            this.ID = ID;
            this.NameOnCard = NameOnCard.ToUpper();
            this.CardNumber = CardNumber;
            this.CVVNumber = CVVNumber;
            this.IssueDate = IssueDate;
            this.ExpierdDate = ExpierdDate;
            this.AccountLinked = AccountLinked;
            this.AccountLinkedInfo = clsAccount.Find(AccountLinked);
            this.IsActive = IsActive;
            this.CreatedByUser = CreatedByUser;
            this.CreatedByUserInfo = clsUser.Find(CreatedByUser);
            this.PinCode = PinCode;
            this.CardTypeID = CardTypeID;
            this.CardTypeInfo = clsCardType.Find(CardTypeID);

            Mode = enMode.Update;
        }

        public string HashString(string plainString)
        {

            string hashedString = BCrypt.Net.BCrypt.HashPassword(plainString, 12);
            return hashedString;
        }
        public static bool VerifyString(string enteredString, string storedHashedString)
        {
            bool isStringCorrect = false;
            try
            {

                isStringCorrect = BCrypt.Net.BCrypt.Verify(enteredString, storedHashedString);
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error verifying password: {ex.Message}");
                isStringCorrect = false;
            }
            return isStringCorrect;
        }

        public static clsCard Find(int ID)
        {
            int AccountLinked = -1, CreatedByUser = -1, CardTypeID = -1;
            string NameOnCard ="", CardNumber = "", CVVNumber = "", PinCode = "";
            DateTime IssueDate = DateTime.Now, ExpierdDate = DateTime.Now.AddYears(5);
            bool IsActive = true;

            bool IsFound = CardsDataAccess.GetCardByID(ID,ref NameOnCard, ref CardNumber, ref CVVNumber,
                ref IssueDate, ref ExpierdDate, ref AccountLinked, ref IsActive, ref CreatedByUser, ref PinCode, ref CardTypeID);

            if (IsFound)
                return new clsCard(ID,NameOnCard, CardNumber, CVVNumber,
                IssueDate, ExpierdDate, AccountLinked, IsActive, CreatedByUser, PinCode, CardTypeID);
            else
                return null;

        }

        public static clsCard Find(string CardNumber)
        {
            int ID = -1, AccountLinked = -1, CreatedByUser = -1, CardTypeID = -1;
            string NameOnCard ="", CVVNumber = "", PinCode = "";
            DateTime IssueDate = DateTime.Now, ExpierdDate = DateTime.Now.AddYears(5);
            bool IsActive = true;

            bool IsFound = CardsDataAccess.GetCardByCardNumber(CardNumber, ref ID, ref NameOnCard, ref CVVNumber,
                ref IssueDate, ref ExpierdDate, ref AccountLinked, ref IsActive, ref CreatedByUser, ref PinCode, ref CardTypeID);

            if (IsFound)
                return new clsCard(ID, NameOnCard, CardNumber, CVVNumber,
                IssueDate, ExpierdDate, AccountLinked, IsActive, CreatedByUser, PinCode, CardTypeID);
            else
                return null;

        }

        private bool _AddNewCard()
        {
            string hashPinCode = HashString(PinCode);
            string hashCvv = HashString(CVVNumber);

            this.ID = CardsDataAccess.AddNewCard(NameOnCard.ToUpper(),CardNumber, hashCvv,
                IssueDate, ExpierdDate, AccountLinked, IsActive, CreatedByUser,
                hashPinCode, CardTypeID);
            return (this.ID != -1);
        }
        private bool _UpdateCard()
        {
            string hashPinCode = HashString(PinCode);
            string hashCvv = HashString(CVVNumber);

            return CardsDataAccess.UpdateCard(ID,NameOnCard.ToUpper(), CardNumber, hashCvv,
                IssueDate, ExpierdDate, AccountLinked, IsActive, CreatedByUser, hashPinCode, CardTypeID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCard())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateCard();

            }

            return false;
        }

        public static bool DeleteCard(int ID)
        {
            return CardsDataAccess.DeleteCard(ID);
        }

        public static bool isCardExist(int ID)
        {
            return CardsDataAccess.IsCardExistByID(ID);
        }

        public static DataTable GetAllCards()
        {
            return CardsDataAccess.GetAllCards();
        }

        public static DataTable GetAllCardsForClient(string ClientNumber)
        {
            return CardsDataAccess.GetAllCardsForClient(ClientNumber);
        }
    }
}
