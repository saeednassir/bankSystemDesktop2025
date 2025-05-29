using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class AccountTypesDataAccess
    {

        public static bool GetAccountTypeByID(int ID, ref string Name, ref string Code,
            ref string Description, ref decimal MinimumBalance, ref bool IsActive,
            ref DateTime CreatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from AccountTypes where ID = @ID";

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
                    Code = (string)reader["Code"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["Description"] != DBNull.Value)
                        Description = (string)reader["Description"];
                    else
                        Description = "";

                    if (reader["MinimumBalance"] != DBNull.Value)
                        MinimumBalance = (decimal)reader["MinimumBalance"];
                    else
                        MinimumBalance = 0;


                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetAccountTypeByName(string Name, ref int ID, ref string Code,
            ref string Description, ref decimal MinimumBalance, ref bool IsActive,
            ref DateTime CreatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from AccountTypes where Name = @Name";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    Code = (string)reader["Code"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["Description"] != DBNull.Value)
                        Description = (string)reader["Description"];
                    else
                        Description = "";

                    if (reader["MinimumBalance"] != DBNull.Value)
                        MinimumBalance = (decimal)reader["MinimumBalance"];
                    else
                        MinimumBalance = 0;

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewAccountType(string Name, string Code,
            string Description, decimal MinimumBalance, bool IsActive,
            DateTime CreatedAt)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into AccountTypes(Name,Code,Description,MinimumBalance,
                             IsActive,CreatedAt)
                             Values (@Name,@Code,@Description,@MinimumBalance,@IsActive,
                             @CreatedAt);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Description", Description);
            else
                command.Parameters.AddWithValue("@Description", System.DBNull.Value);

            if (MinimumBalance != 0 && MinimumBalance != null)
                command.Parameters.AddWithValue("@MinimumBalance", MinimumBalance);
            else
                command.Parameters.AddWithValue("@MinimumBalance", System.DBNull.Value);


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

        public static bool UpdateAccountType(int ID, string Name, string Code,
            string Description, decimal MinimumBalance, bool IsActive,
            DateTime CreatedAt)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update AccountTypes 
                             Set 
                             Name = @Name,
                             Code = @Code,
                             Description = @Description,
                             MinimumBalance = @MinimumBalance,
                             IsActive = @IsActive,
                             CreatedAt = @CreatedAt
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Description", Description);
            else
                command.Parameters.AddWithValue("@Description", System.DBNull.Value);

            if (MinimumBalance != 0 && MinimumBalance != null)
                command.Parameters.AddWithValue("@MinimumBalance", MinimumBalance);
            else
                command.Parameters.AddWithValue("@MinimumBalance", System.DBNull.Value);

            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteAccountType(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From AccountTypes Where ID = @ID";

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

        public static bool IsAccountTypeExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from AccountTypes Where ID = @ID";

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
        public static bool IsAccountTypeExistByCode(string Code)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from AccountTypes Where Code = @Code";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Code", Code);

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
        public static DataTable GetAllAccountTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from AccountTypes;";

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
