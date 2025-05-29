using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class CardTypesDataAccess
    {
        public static bool GetCardTypeByID(int ID, ref string TypeName,
            ref byte DefaultValidityLength, ref decimal CardTypeFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from CardTypes where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TypeName = (string)reader["TypeName"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    CardTypeFees = (decimal)reader["CardTypeFees"];

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }


        public static bool GetCardTypeByName(string TypeName, ref int ID,
           ref byte DefaultValidityLength, ref decimal CardTypeFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from CardTypes where TypeName = @TypeName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TypeName", TypeName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    CardTypeFees = (decimal)reader["CardTypeFees"];

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewCardType(string TypeName, byte DefaultValidityLength,
            decimal CardTypeFees)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into CardTypes(TypeName,DefaultValidityLength,CardTypeFees)
                             Values (@TypeName,@DefaultValidityLength,@CardTypeFees);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TypeName", TypeName);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@CardTypeFees", CardTypeFees);

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


        public static bool UpdateCardType(int ID, string TypeName, byte DefaultValidityLength,
            decimal CardTypeFees)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update CardTypes 
                             Set 
                             TypeName = @TypeName,
                             DefaultValidityLength = @DefaultValidityLength,
                             CardTypeFees = @CardTypeFees
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@TypeName", TypeName);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@CardTypeFees", CardTypeFees);

            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteCardType(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From CardTypes Where ID = @ID";

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


        public static bool IsCardTypeExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from CardTypes Where ID = @ID";

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

        public static DataTable GetAllCardTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from CardTypes;";

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
