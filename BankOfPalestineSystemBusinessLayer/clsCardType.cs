using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsCardType
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string TypeName { set; get; }
        public byte DefaultValidityLength { set; get; }
        public decimal CardTypeFees { set; get; }

        public clsCardType()
        {
            this.ID = -1;
            this.TypeName = "";
            this.DefaultValidityLength = 0;
            this.CardTypeFees = 0;

            Mode = enMode.AddNew;

        }

        private clsCardType(int ID, string TypeName, byte DefaultValidityLength, decimal CardTypeFees)
        {
            this.ID = ID;
            this.TypeName = TypeName;
            this.DefaultValidityLength = DefaultValidityLength;
            this.CardTypeFees = CardTypeFees;

            Mode = enMode.Update;
        }

        public static clsCardType Find(int ID)
        {
            string TypeName = "";
            byte DefaultValidityLength = 0;
            decimal CardTypeFees = 0;

            bool IsFound = CardTypesDataAccess.GetCardTypeByID(ID, ref TypeName,
                ref DefaultValidityLength, ref CardTypeFees);

            if (IsFound)
                return new clsCardType(ID, TypeName, DefaultValidityLength, CardTypeFees);
            else
                return null;

        }

        public static clsCardType Find(string TypeName)
        {
            int ID = -1;
            byte DefaultValidityLength = 0;
            decimal CardTypeFees = 0;

            bool IsFound = CardTypesDataAccess.GetCardTypeByName(TypeName, ref ID,
                ref DefaultValidityLength, ref CardTypeFees);

            if (IsFound)
                return new clsCardType(ID, TypeName, DefaultValidityLength, CardTypeFees);
            else
                return null;

        }


        private bool _AddNewCardType()
        {
            this.ID = CardTypesDataAccess.AddNewCardType(TypeName, DefaultValidityLength, CardTypeFees);
            return (this.ID != -1);
        }

        private bool _UpdateCardType()
        {
            return CardTypesDataAccess.UpdateCardType(ID, TypeName, DefaultValidityLength, CardTypeFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCardType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateCardType();

            }

            return false;
        }

        public static bool DeleteCardType(int ID)
        {
            return CardTypesDataAccess.DeleteCardType(ID);
        }

        public static bool isCardTypeExist(int ID)
        {
            return CardTypesDataAccess.IsCardTypeExistByID(ID);
        }

        public static DataTable GetAllCardTypes()
        {
            return CardTypesDataAccess.GetAllCardTypes();
        }

    }
}
