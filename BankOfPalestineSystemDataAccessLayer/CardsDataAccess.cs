using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class CardsDataAccess
    {
        public static bool GetCardByID(int ID,ref string NameOnCard, ref string CardNumber,
          ref string CVVNumber, ref DateTime IssueDate, ref DateTime ExpierdDate,
          ref int AccountLinked, ref bool IsActive, ref int CreatedByUser,
          ref string PinCode, ref int CardTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Cards where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NameOnCard = (string)reader["NameOnCard"];
                    CardNumber = (string)reader["CardNumber"];
                    CVVNumber = (string)reader["CVVNumber"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpierdDate = (DateTime)reader["ExpierdDate"];
                    AccountLinked = (int)reader["AccountLinked"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUser = (int)reader["CreatedByUser"];
                    PinCode = (string)reader["PinCode"];
                    CardTypeID = (int)reader["CardTypeID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetCardByCardNumber(string CardNumber, ref int ID,ref string NameOnCard,
            ref string CVVNumber, ref DateTime IssueDate, ref DateTime ExpierdDate,
            ref int AccountLinked, ref bool IsActive, ref int CreatedByUser,
            ref string PinCode, ref int CardTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Cards where CardNumber = @CardNumber";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CardNumber", CardNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    NameOnCard = (string)reader["NameOnCard"];
                    CVVNumber = (string)reader["CVVNumber"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpierdDate = (DateTime)reader["ExpierdDate"];
                    AccountLinked = (int)reader["AccountLinked"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUser = (int)reader["CreatedByUser"];
                    PinCode = (string)reader["PinCode"];
                    CardTypeID = (int)reader["CardTypeID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }


        public static int AddNewCard(string NameOnCard, string CardNumber, string CVVNumber,
            DateTime IssueDate, DateTime ExpierdDate, int AccountLinked,
            bool IsActive, int CreatedByUser, string PinCode, int CardTypeID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Cards(NameOnCard,CardNumber,CVVNumber,
                             IssueDate, ExpierdDate, AccountLinked,
                             IsActive, CreatedByUser, PinCode,CardTypeID)
                             Values (@NameOnCard,@CardNumber,@CVVNumber,
                             @IssueDate, @ExpierdDate, @AccountLinked,
                             @IsActive, @CreatedByUser, @PinCode,@CardTypeID);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NameOnCard", NameOnCard);
            command.Parameters.AddWithValue("@CardNumber", CardNumber);
            command.Parameters.AddWithValue("@CVVNumber", CVVNumber);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpierdDate", ExpierdDate);
            command.Parameters.AddWithValue("@AccountLinked", AccountLinked);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);


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


        public static bool UpdateCard(int ID, string NameOnCard, string CardNumber, string CVVNumber,
            DateTime IssueDate, DateTime ExpierdDate, int AccountLinked,
            bool IsActive, int CreatedByUser, string PinCode, int CardTypeID)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Cards 
                             Set 
                             CardNumber = @CardNumber,
                             CVVNumber = @CVVNumber,
                             IssueDate = @IssueDate,
                             ExpierdDate = @ExpierdDate,
                             AccountLinked = @AccountLinked,
                             IsActive = @IsActive,
                             CreatedByUser = @CreatedByUser,
                             PinCode = @PinCode,
                             CardTypeID = @CardTypeID
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);
            string pin = PinCode;
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@CardNumber", CardNumber);
            command.Parameters.AddWithValue("@CVVNumber", CVVNumber);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpierdDate", ExpierdDate);
            command.Parameters.AddWithValue("@AccountLinked", AccountLinked);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@CardTypeID", CardTypeID);

            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteCard(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Cards Where ID = @ID";

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

        public static bool IsCardExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Cards Where ID = @ID";

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

        public static DataTable GetAllCards()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select c.ID,c.NameOnCard,ct.TypeName,c.CardNumber,c.IssueDate,c.ExpierdDate,
a.AccountNumber,c.IsActive,u.Username from Cards as c
inner join CardTypes ct ON ct.ID = c.CardTypeID
inner join Accounts as a ON a.ID = c.AccountLinked 
inner join Users as u ON u.ID = c.CreatedByUser;";

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

        public static DataTable GetAllCardsForClient(string ClientNumber)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select c.ID as CardID,c.CardNumber,ct.TypeName,c.IsActive,c.IssueDate,c.ExpierdDate
from cards as c
inner join Accounts as a ON a.ID = c.AccountLinked
inner join Clients ON Clients.ID = a.ClientID 
inner join CardTypes as ct ON ct.ID = c.CardTypeID
where Clients.ClientNumber = @ClientNumber;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ClientNumber", ClientNumber);

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
