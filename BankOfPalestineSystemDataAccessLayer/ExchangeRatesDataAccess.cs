using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class ExchangeRatesDataAccess
    {
        
        public static bool GetExchangeRateByID(int ExchangeRateID, ref int FromCurrencyCode,
            ref int ToCurrencyCode, ref decimal Rate, ref DateTime EffectiveDateTime,
            ref byte RateType, ref byte RateSource, ref DateTime CreatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from ExchangeRates where ExchangeRateID = @ExchangeRateID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ExchangeRateID", ExchangeRateID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    FromCurrencyCode = (int)reader["FromCurrencyCode"];
                    ToCurrencyCode = (int)reader["ToCurrencyCode"];
                    Rate = (decimal)reader["Rate"];
                    EffectiveDateTime = (DateTime)reader["EffectiveDateTime"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    RateType = (byte)reader["RateType"];
                    RateSource = (byte)reader["RateSource"];





                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewExchangeRate(int FromCurrencyCode,
            int ToCurrencyCode, decimal Rate, DateTime EffectiveDateTime,
             byte RateType, byte RateSource, DateTime CreatedAt)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into ExchangeRates(FromCurrencyCode,
             ToCurrencyCode,Rate,EffectiveDateTime,RateType,RateSource,CreatedAt)
                             Values (@FromCurrencyCode,
             @ToCurrencyCode,@Rate,@EffectiveDateTime,@RateType,@RateSource,@CreatedAt);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FromCurrencyCode", FromCurrencyCode);
            command.Parameters.AddWithValue("@ToCurrencyCode", ToCurrencyCode);
            command.Parameters.AddWithValue("@Rate", Rate);
            command.Parameters.AddWithValue("@EffectiveDateTime", EffectiveDateTime);

            command.Parameters.AddWithValue("@RateType", RateType);
            command.Parameters.AddWithValue("@RateSource", RateSource);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return ID;
        }


        public static bool UpdateExchangeRate(int ExchangeRateID, int FromCurrencyCode,
            int ToCurrencyCode, decimal Rate, DateTime EffectiveDateTime,
             byte RateType, byte RateSource, DateTime CreatedAt)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update ExchangeRates 
                             Set 
                             FromCurrencyCode = @FromCurrencyCode,
                             ToCurrencyCode = @ToCurrencyCode,
                             Rate = @Rate,
                             EffectiveDateTime = @EffectiveDateTime,
                             RateType = @RateType,
                             RateSource = @RateSource,
                             CreatedAt = @CreatedAt
                             Where ExchangeRateID = @ExchangeRateID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ExchangeRateID", ExchangeRateID);
            command.Parameters.AddWithValue("@FromCurrencyCode", FromCurrencyCode);
            command.Parameters.AddWithValue("@ToCurrencyCode", ToCurrencyCode);
            command.Parameters.AddWithValue("@Rate", Rate);
            command.Parameters.AddWithValue("@EffectiveDateTime", EffectiveDateTime);
            command.Parameters.AddWithValue("@RateType", RateType);
            command.Parameters.AddWithValue("@RateSource", RateSource);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);



            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }


        public static bool DeleteExchangeRate(int ExchangeRateID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From ExchangeRates Where ExchangeRateID = @ExchangeRateID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ExchangeRateID", ExchangeRateID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffectedRows > 0);

        }

        public static bool IsExchangeRateExistByID(int ExchangeRate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from ExchangeRates Where ExchangeRate = @ExchangeRate";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ExchangeRate", ExchangeRate);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }

        public static DataTable GetAllExchangeRates()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from AllExchangeRates order by EffectiveDateTime Desc";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return dt;
        }

        public static decimal GetExchangeRate(int fromCurrency, int toCurrency, 
            byte rateType, DateTime EffectiveTime)
        {
            decimal ExchangeRate = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"SELECT TOP 1 Rate
FROM ExchangeRates as er
WHERE er.FromCurrencyCode = @fromCurrency
AND er.ToCurrencyCode = @toCurrency
AND er.RateType = @rateType
AND er.EffectiveDateTime <= @EffectiveTime
ORDER BY EffectiveDateTime DESC";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@fromCurrency", fromCurrency);
            command.Parameters.AddWithValue("@toCurrency", toCurrency);
            command.Parameters.AddWithValue("@rateType", rateType);
            command.Parameters.AddWithValue("@EffectiveTime", @EffectiveTime);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out decimal insertedID))
                {
                    ExchangeRate = insertedID;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return ExchangeRate;
        }


    }
}
