using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class CurrenciesDataAccess
    {
        public static bool GetCurrencyByID(int ID, ref string Name,
            ref string CurrencyNumber, ref string CodeCurrency,
            ref int CountryID, ref string CurrencySymbol,
            ref byte DecimalPlaces, ref bool IsActive, ref DateTime CreatedAt,
            ref DateTime UpdateAt, ref int CreateBy, ref int UpdateBy)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Currencies where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    Name = (string)reader["Name"];
                    CurrencyNumber = (string)reader["CurrencyNumber"];
                    CodeCurrency = (string)reader["CodeCurrency"];
                    CountryID = (int)reader["CountryID"];

                    DecimalPlaces = (byte)reader["DecimalPlaces"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedAt = (DateTime)reader["CreatedAt"];


                    if (reader["CurrencySymbol"] != DBNull.Value)
                        CurrencySymbol = (string)reader["CurrencySymbol"];
                    else
                        CurrencySymbol = "";

                    if (reader["UpdateAt"] != DBNull.Value)
                        UpdateAt = (DateTime)reader["UpdateAt"];
                    else
                        UpdateAt = new DateTime(1900, 01, 01);

                    if (reader["CreateBy"] != DBNull.Value)
                        CreateBy = (int)reader["CreateBy"];
                    else
                        CreateBy = -1;

                    if (reader["UpdateBy"] != DBNull.Value)
                        UpdateBy = (int)reader["UpdateBy"];
                    else
                        UpdateBy = -1;


                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetCurrencyByCodeCurrency(string CodeCurrency, ref int ID,
            ref string Name, ref string CurrencyNumber,
            ref int CountryID, ref string CurrencySymbol,
            ref byte DecimalPlaces, ref bool IsActive, ref DateTime CreatedAt,
            ref DateTime UpdateAt, ref int CreateBy, ref int UpdateBy)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Currencies where CodeCurrency = @CodeCurrency";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CodeCurrency", CodeCurrency);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    Name = (string)reader["Name"];
                    CurrencyNumber = (string)reader["CurrencyNumber"];
                    CountryID = (int)reader["CountryID"];

                    DecimalPlaces = (byte)reader["DecimalPlaces"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedAt = (DateTime)reader["CreatedAt"];



                    if (reader["CurrencySymbol"] != DBNull.Value)
                        CurrencySymbol = (string)reader["CurrencySymbol"];
                    else
                        CurrencySymbol = "";

                    if (reader["UpdateAt"] != DBNull.Value)
                        UpdateAt = (DateTime)reader["UpdateAt"];
                    else
                        UpdateAt = new DateTime(1900, 01, 01);

                    if (reader["CreateBy"] != DBNull.Value)
                        CreateBy = (int)reader["CreateBy"];
                    else
                        CreateBy = -1;

                    if (reader["UpdateBy"] != DBNull.Value)
                        UpdateBy = (int)reader["UpdateBy"];
                    else
                        UpdateBy = -1;

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetCurrencyByCurrencyNumber(string CurrencyNumber, ref int ID,
           ref string Name, ref string CodeCurrency,
           ref int CountryID, ref string CurrencySymbol,
            ref byte DecimalPlaces, ref bool IsActive, ref DateTime CreatedAt,
            ref DateTime UpdateAt, ref int CreateBy, ref int UpdateBy)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Currencies where CurrencyNumber = @CurrencyNumber";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CurrencyNumber", CurrencyNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    Name = (string)reader["Name"];
                    CodeCurrency = (string)reader["CodeCurrency"];
                    CountryID = (int)reader["CountryID"];

                    DecimalPlaces = (byte)reader["DecimalPlaces"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["CurrencySymbol"] != DBNull.Value)
                        CurrencySymbol = (string)reader["CurrencySymbol"];
                    else
                        CurrencySymbol = "";

                    if (reader["UpdateAt"] != DBNull.Value)
                        UpdateAt = (DateTime)reader["UpdateAt"];
                    else
                        UpdateAt = new DateTime(1900, 01, 01);

                    if (reader["CreateBy"] != DBNull.Value)
                        CreateBy = (int)reader["CreateBy"];
                    else
                        CreateBy = -1;

                    if (reader["UpdateBy"] != DBNull.Value)
                        UpdateBy = (int)reader["UpdateBy"];
                    else
                        UpdateBy = -1;
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewCurrency(string Name,
             string CurrencyNumber, string CodeCurrency,
             int CountryID, string CurrencySymbol,
             byte DecimalPlaces, bool IsActive, DateTime CreatedAt,
            DateTime UpdateAt, int CreateBy, int UpdateBy)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Currencies( Name,
              CurrencyNumber, CodeCurrency,
             CountryID,CurrencySymbol,
            DecimalPlaces,IsActive,CreatedAt,
             UpdateAt,CreateBy,UpdateBy)
                             Values (@Name,
              @CurrencyNumber, @CodeCurrency,
             @CountryID,@CurrencySymbol,
            @DecimalPlaces,@IsActive,@CreatedAt,
             @UpdateAt,@CreateBy,@UpdateBy);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@CurrencyNumber", CurrencyNumber);
            command.Parameters.AddWithValue("@CodeCurrency", CodeCurrency);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            command.Parameters.AddWithValue("@DecimalPlaces", DecimalPlaces);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (CurrencySymbol != "" && CurrencySymbol != null)
                command.Parameters.AddWithValue("@CurrencySymbol", CurrencySymbol);
            else
                command.Parameters.AddWithValue("@CurrencySymbol", System.DBNull.Value);

            if (UpdateAt != new DateTime(1900, 01, 01) && UpdateAt != null)
                command.Parameters.AddWithValue("@UpdateAt", UpdateAt);
            else
                command.Parameters.AddWithValue("@UpdateAt", System.DBNull.Value);


            if (CreateBy != -1 && CreateBy != null)
                command.Parameters.AddWithValue("@CreateBy", CreateBy);
            else
                command.Parameters.AddWithValue("@CreateBy", System.DBNull.Value);


            if (UpdateBy != -1 && UpdateBy != null)
                command.Parameters.AddWithValue("@UpdateBy", UpdateBy);
            else
                command.Parameters.AddWithValue("@UpdateBy", System.DBNull.Value);

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


        public static bool UpdateCurrency(int ID, string Name,
             string CurrencyNumber, string CodeCurrency,
             int CountryID, string CurrencySymbol,
             byte DecimalPlaces, bool IsActive, DateTime CreatedAt,
            DateTime UpdateAt, int CreateBy, int UpdateBy)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Currencies 
                             Set 
                             Name = @Name,
                             CurrencyNumber = @CurrencyNumber,
                             CodeCurrency = @CodeCurrency,
                             CountryID = @CountryID,
                             CurrencySymbol = @CurrencySymbol,
                             DecimalPlaces = @DecimalPlaces,
                             IsActive = @IsActive,
                             CreatedAt = @CreatedAt,
                             UpdateAt = @UpdateAt,
                             CreateBy = @CreateBy,
                             UpdateBy = @UpdateBy
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@CurrencyNumber", CurrencyNumber);
            command.Parameters.AddWithValue("@CodeCurrency", CodeCurrency);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            command.Parameters.AddWithValue("@DecimalPlaces", DecimalPlaces);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);


            if (CurrencySymbol != "" && CurrencySymbol != null)
                command.Parameters.AddWithValue("@CurrencySymbol", CurrencySymbol);
            else
                command.Parameters.AddWithValue("@CurrencySymbol", System.DBNull.Value);

            if (UpdateAt != new DateTime(1900, 01, 01) && UpdateAt != null)
                command.Parameters.AddWithValue("@UpdateAt", UpdateAt);
            else
                command.Parameters.AddWithValue("@UpdateAt", System.DBNull.Value);


            if (CreateBy != -1 && CreateBy != null)
                command.Parameters.AddWithValue("@CreateBy", CreateBy);
            else
                command.Parameters.AddWithValue("@CreateBy", System.DBNull.Value);


            if (UpdateBy != -1 && UpdateBy != null)
                command.Parameters.AddWithValue("@UpdateBy", UpdateBy);
            else
                command.Parameters.AddWithValue("@UpdateBy", System.DBNull.Value);

            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteCurrency(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Currencies Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffectedRows > 0);

        }

        public static bool IscurrencyExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Currencies Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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

        public static DataTable GetAllCurrencies()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from AllCurrencies;";

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

    }
}
