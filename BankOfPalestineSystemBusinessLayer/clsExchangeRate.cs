using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsExchangeRate
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enRateType { CUSTOMER_BUY = 0, CUSTOMER_SELL = 1, MID_MARKET = 2 };
        public enum enRateSource { PalestineMonetaryAuthority = 0, Manual = 1 };
        public int ExchangeRateID { set; get; }
        public int FromCurrencyCode { set; get; }
        public clsCurrency FromCurrencyInfo;
        public int ToCurrencyCode { set; get; }
        public clsCurrency ToCurrencyInfo;
        public decimal Rate { set; get; }
        public DateTime EffectiveDateTime { set; get; }
        public enRateType RateType { set; get; }
        public enRateSource RateSource { set; get; }
        public DateTime CreatedAt { set; get; }

        public clsExchangeRate()
        {

            this.ExchangeRateID = -1;
            this.FromCurrencyCode = -1;
            this.ToCurrencyCode = -1;
            this.Rate = 0;
            this.EffectiveDateTime = DateTime.Now;
            this.RateType = enRateType.MID_MARKET;
            this.RateSource = enRateSource.Manual;
            this.CreatedAt = DateTime.Now;


            Mode = enMode.AddNew;
        }

        private clsExchangeRate(int exchangeRateID, int fromCurrencyCode,
            int toCurrencyCode, decimal rate, DateTime effectiveDateTime,
            enRateType rateType, enRateSource rateSource, DateTime createdAt)
        {
            ExchangeRateID = exchangeRateID;
            FromCurrencyCode = fromCurrencyCode;
            FromCurrencyInfo = clsCurrency.FindByID(FromCurrencyCode);
            ToCurrencyCode = toCurrencyCode;
            ToCurrencyInfo = clsCurrency.FindByID(toCurrencyCode);
            Rate = rate;
            EffectiveDateTime = effectiveDateTime;
            RateType = rateType;
            RateSource = rateSource;
            CreatedAt = createdAt;

            Mode = enMode.Update;
        }

        public static clsExchangeRate Find(int ExchangeRateID)
        {

            int FromCurrencyCode = -1, ToCurrencyCode = -1;
            decimal Rate = 0;
            DateTime EffectiveDateTime = DateTime.Now, CreatedAt = DateTime.Now;
            byte RateType = (byte)enRateType.MID_MARKET;
            byte RateSource = (byte)enRateSource.Manual;

            bool IsFound = ExchangeRatesDataAccess.GetExchangeRateByID(ExchangeRateID,
                                ref FromCurrencyCode, ref ToCurrencyCode,
                                ref Rate, ref EffectiveDateTime,
                                ref RateType, ref RateSource, ref CreatedAt);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsExchangeRate(ExchangeRateID,
                                FromCurrencyCode, ToCurrencyCode,
                                Rate, EffectiveDateTime,
                                (enRateType)RateType, (enRateSource)RateSource, CreatedAt);
            else
                return null;
        }

        private bool _AddNewExchangeRate()
        {
            //call DataAccess Layer 

            this.ExchangeRateID = ExchangeRatesDataAccess.AddNewExchangeRate(this.FromCurrencyCode,
                this.ToCurrencyCode, this.Rate, this.EffectiveDateTime, (byte)this.RateType, (byte)this.RateSource,
                this.CreatedAt);

            return (this.ExchangeRateID != -1);
        }
        private bool _UpdateExchangeRate()
        {
            //call DataAccess Layer 

            return ExchangeRatesDataAccess.UpdateExchangeRate(this.ExchangeRateID, this.FromCurrencyCode,
                this.ToCurrencyCode, this.Rate, this.EffectiveDateTime, (byte)this.RateType, (byte)this.RateSource,
                this.CreatedAt);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewExchangeRate())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateExchangeRate();

            }

            return false;
        }

        public static DataTable GetAllExchangeRates()
        {
            return ExchangeRatesDataAccess.GetAllExchangeRates();
        }
        public static bool DeleteExchangeRate(int ID)
        {
            return ExchangeRatesDataAccess.DeleteExchangeRate(ID);
        }

        public static bool isExchangeRateExist(int ID)
        {
            return ExchangeRatesDataAccess.IsExchangeRateExistByID(ID);
        }

        public static decimal GetExchangeRate(int fromCurrency, int toCurrency,
           byte rateType, DateTime EffectiveTime)
        {
            return ExchangeRatesDataAccess.GetExchangeRate(fromCurrency,toCurrency, rateType, EffectiveTime);
        }
    }
}
