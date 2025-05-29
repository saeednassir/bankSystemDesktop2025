using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class TransactionTypesDataAccess
    {
        public static bool GetTransactionTypeByID(int TransactionTypeID, ref string TypeName,
            ref string Description, ref byte DebitCreditIndicator)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from TransactionTypes where TransactionTypeID = @TransactionTypeID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TypeName = (string)reader["TypeName"];
                    DebitCreditIndicator = (byte)reader["DebitCreditIndicator"];

                    if (reader["Description"] != DBNull.Value)
                        Description = (string)reader["Description"];
                    else
                        Description = "";


                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetTransactionTypeByName(string TypeName, ref int TransactionTypeID,
            ref string Description, ref byte DebitCreditIndicator)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from TransactionTypes where TypeName = @TypeName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TypeName", TypeName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TransactionTypeID = (int)reader["TyTransactionTypeIDpeName"];
                    Description = (string)reader["Description"];
                    DebitCreditIndicator = (byte)reader["DebitCreditIndicator"];

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewTransactionType(string TypeName,
             string Description, byte DebitCreditIndicator)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into TransactionTypes(TypeName,
             Description,DebitCreditIndicator)
                             Values (@TypeName,
             @Description,@DebitCreditIndicator);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TypeName", TypeName);
            command.Parameters.AddWithValue("@DebitCreditIndicator", DebitCreditIndicator);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Description", Description);
            else
                command.Parameters.AddWithValue("@Description", System.DBNull.Value);


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

        public static bool UpdateTransactionType(int TransactionTypeID, string TypeName,
             string Description, byte DebitCreditIndicator)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update TransactionTypes 
                             Set 
                             TypeName = @TypeName,
                             Description = @Description,
                             DebitCreditIndicator = @DebitCreditIndicator
                             Where TransactionTypeID = @TransactionTypeID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);
            command.Parameters.AddWithValue("@TypeName", TypeName);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@DebitCreditIndicator", DebitCreditIndicator);

            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteTransactionType(int TransactionTypeID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From TransactionTypes Where TransactionTypeID = @TransactionTypeID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffectedRows > 0);

        }

        public static bool IsTransactionTypeExistByID(int TransactionTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from TransactionTypes Where TransactionTypeID = @TransactionTypeID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

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

        public static DataTable GetAllTransactionTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select Tt.TransactionTypeID,Tt.TypeName,Tt.Description,
CASE
 WHEN Tt.DebitCreditIndicator = 0 THEN 'Debit'
 WHEN Tt.DebitCreditIndicator = 1 THEN 'Credit'
 WHEN Tt.DebitCreditIndicator = 2 THEN 'Transfer'
 ELSE 'غير معروف'
END as DebitCreditIndicator
from TransactionTypes as Tt;";

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
