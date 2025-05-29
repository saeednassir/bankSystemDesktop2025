using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class AccountsDataAccess
    {
        public static bool GetAccountByID(int ID, ref int BranchID, ref int ClientID,
            ref string AccountNumber, ref int AccountTypeID, ref decimal Balance,
            ref int CurrencyID, ref short Status, ref string NicName,
            ref string SubAccount, ref string IBAN, ref DateTime OpenDate,
            ref DateTime CreatedAt, ref DateTime UpdatedAt, ref DateTime ClosedDate,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Accounts where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    BranchID = (int)reader["BranchID"];
                    ClientID = (int)reader["ClientID"];
                    AccountNumber = (string)reader["AccountNumber"];
                    AccountTypeID = (int)reader["AccountTypeID"];
                    Balance = (decimal)reader["Balance"];
                    CurrencyID = (int)reader["CurrencyID"];
                    Status = (byte)reader["Status"];
                    NicName = (string)reader["NicName"];
                    SubAccount = (string)reader["SubAccount"];
                    IBAN = (string)reader["IBAN"];
                    OpenDate = (DateTime)reader["OpenDate"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["ClosedDate"] != DBNull.Value)
                        ClosedDate = (DateTime)reader["ClosedDate"];
                    else
                        ClosedDate = new DateTime(1900, 01, 01);

                    if (reader["UpdatedAt"] != DBNull.Value)
                        UpdatedAt = (DateTime)reader["UpdatedAt"];
                    else
                        UpdatedAt = new DateTime(1900, 01, 01);


                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }


        public static bool GetAccountByClientIDAndNicName(int ClientID, string NicName,
            ref int ID, ref int BranchID,
            ref string AccountNumber, ref int AccountTypeID, ref decimal Balance,
            ref int CurrencyID, ref short Status,
            ref string SubAccount, ref string IBAN, ref DateTime OpenDate,
            ref DateTime CreatedAt, ref DateTime UpdatedAt, ref DateTime ClosedDate,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Accounts where ClientID = @ClientID and 
                             NicName = @NicName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@NicName", NicName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    BranchID = (int)reader["BranchID"];
                    AccountNumber = (string)reader["AccountNumber"];
                    AccountTypeID = (int)reader["AccountTypeID"];
                    Balance = (decimal)reader["Balance"];
                    CurrencyID = (int)reader["CurrencyID"];
                    Status = (byte)reader["Status"];
                    SubAccount = (string)reader["SubAccount"];
                    IBAN = (string)reader["IBAN"];
                    OpenDate = (DateTime)reader["OpenDate"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["ClosedDate"] != DBNull.Value)
                        ClosedDate = (DateTime)reader["ClosedDate"];
                    else
                        ClosedDate = new DateTime(1900, 01, 01);

                    if (reader["UpdatedAt"] != DBNull.Value)
                        UpdatedAt = (DateTime)reader["UpdatedAt"];
                    else
                        UpdatedAt = new DateTime(1900, 01, 01);

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }



        public static bool GetAccountByAccountNumber(string AccountNumber, ref int ID, ref int BranchID, ref int ClientID,
            ref int AccountTypeID, ref decimal Balance,
            ref int CurrencyID, ref short Status, ref string NicName,
            ref string SubAccount, ref string IBAN, ref DateTime OpenDate,
            ref DateTime CreatedAt, ref DateTime UpdatedAt, ref DateTime ClosedDate,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Accounts where AccountNumber = @AccountNumber";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    BranchID = (int)reader["BranchID"];
                    ClientID = (int)reader["ClientID"];
                    AccountTypeID = (int)reader["AccountTypeID"];
                    Balance = (decimal)reader["Balance"];
                    CurrencyID = (int)reader["CurrencyID"];
                    Status = (byte)reader["Status"];
                    NicName = (string)reader["NicName"];
                    SubAccount = (string)reader["SubAccount"];
                    IBAN = (string)reader["IBAN"];
                    OpenDate = (DateTime)reader["OpenDate"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["ClosedDate"] != DBNull.Value)
                        ClosedDate = (DateTime)reader["ClosedDate"];
                    else
                        ClosedDate = new DateTime(1900, 01, 01);

                    if (reader["UpdatedAt"] != DBNull.Value)
                        UpdatedAt = (DateTime)reader["UpdatedAt"];
                    else
                        UpdatedAt = new DateTime(1900, 01, 01);
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewAccount(int BranchID, int ClientID,
             string AccountNumber, int AccountTypeID, decimal Balance,
             int CurrencyID, short Status, string NicName,
            string SubAccount, string IBAN, DateTime OpenDate,
             DateTime CreatedAt, DateTime UpdatedAt, DateTime ClosedDate,
             int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Accounts(BranchID,ClientID,
            AccountNumber, AccountTypeID, Balance,
            CurrencyID,Status, NicName, SubAccount,IBAN,OpenDate,CreatedAt,
            UpdatedAt,ClosedDate,CreatedByUserID)
                             Values (@BranchID,@ClientID,
            @AccountNumber, @AccountTypeID, @Balance,
            @CurrencyID,@Status, @NicName, @SubAccount,@IBAN,@OpenDate,@CreatedAt,
            @UpdatedAt,@ClosedDate,@CreatedByUserID);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@BranchID", BranchID);
            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@NicName", NicName);
            command.Parameters.AddWithValue("@SubAccount", SubAccount);
            command.Parameters.AddWithValue("@IBAN", IBAN);
            command.Parameters.AddWithValue("@OpenDate", OpenDate);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (ClosedDate != new DateTime(1900, 01, 01) && ClosedDate != null)
                command.Parameters.AddWithValue("@ClosedDate", ClosedDate);
            else
                command.Parameters.AddWithValue("@ClosedDate", System.DBNull.Value);

            if (UpdatedAt != new DateTime(1900, 01, 01) && UpdatedAt != null)
                command.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
            else
                command.Parameters.AddWithValue("@UpdatedAt", System.DBNull.Value);

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



        public static bool UpdateAccount(int ID, int BranchID, int ClientID,
             string AccountNumber, int AccountTypeID, decimal Balance,
             int CurrencyID, short Status, string NicName,
            string SubAccount, string IBAN, DateTime OpenDate,
             DateTime CreatedAt, DateTime UpdatedAt, DateTime ClosedDate,
             int CreatedByUserID)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Accounts 
                             Set 
                             BranchID = @BranchID,
                             ClientID = @ClientID,
                             AccountNumber = @AccountNumber,
                             AccountTypeID = @AccountTypeID,
                             Balance = @Balance,
                             CurrencyID = @CurrencyID,
                             Status = @Status,
                             NicName = @NicName,
                             SubAccount = @SubAccount,
                             IBAN = @IBAN,
                             OpenDate = @OpenDate,
                             CreatedAt = @CreatedAt,
                             UpdatedAt = @UpdatedAt,
                             ClosedDate = @ClosedDate,
                             CreatedByUserID = @CreatedByUserID
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@BranchID", BranchID);
            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@NicName", NicName);
            command.Parameters.AddWithValue("@SubAccount", SubAccount);
            command.Parameters.AddWithValue("@IBAN", IBAN);
            command.Parameters.AddWithValue("@OpenDate", OpenDate);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            if (ClosedDate != new DateTime(1900, 01, 01) && ClosedDate != null)
                command.Parameters.AddWithValue("@ClosedDate", ClosedDate);
            else
                command.Parameters.AddWithValue("@ClosedDate", System.DBNull.Value);

            if (UpdatedAt != new DateTime(1900, 01, 01) && UpdatedAt != null)
                command.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
            else
                command.Parameters.AddWithValue("@UpdatedAt", System.DBNull.Value);


            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }


        public static bool DeleteAccount(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Accounts Where ID = @ID";

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

        public static bool IsAccountExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Accounts Where ID = @ID";

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

        public static DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

           
            string Query = @"select a.ID,b.Name as BrancheName,
FullName = p.FirstName + ' ' + p.SecoundName +' ' + p.LastName,
a.AccountNumber,at.Name as AccountTypeName,a.Balance,cr.CodeCurrency,
Case
    when a.Status = 0 then 'قيد المراجعة'
    when a.Status = 1 then 'فعال'
	when a.Status = 2 then 'خامل'
	when a.Status = 3 then 'مغلق'
	when a.Status = 4 then 'مجمد'
    else 'غير معروف'
end as Status,
a.NicName,a.SubAccount,a.IBAN,a.OpenDate
from Accounts as a
inner join Branches as b ON b.ID = a.BranchID
inner join Clients as c ON c.ID = a.ClientID
inner join People as p ON p.PersonID = c.PersonID
inner join AccountTypes as at ON at.ID = a.AccountTypeID
inner join Currencies as cr ON cr.ID = a.CurrencyID 
order by a.CreatedAt Desc;";

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

        public static DataTable GetAllAccountsForClient(int ClientID, byte Status)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Accounts where ClientID = @ClientID and Accounts.Status = @Status
order by CreatedAt Desc;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@Status", Status);

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


        public static int HowCountSubAccountsForClient(int ClientID, int AccountTypeID,
           int CurrencyID)
        {
            int Count = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select Count(*) from Accounts where 
                             ClientID = @ClientID and
                             AccountTypeID = @AccountTypeID and
                             CurrencyID = @CurrencyID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountTypeID", AccountTypeID);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedCount))
                {
                    Count = insertedCount;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Count;
        }

        public static DataTable GetAllAccountsForClient(string ClientNumber)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select a.ID as AccountID,a.AccountNumber,at.Name as AccountType ,a.Balance,cur.CodeCurrency,a.NicName
from Accounts as a
inner join Clients as c ON c.ID = a.ClientID 
inner join AccountTypes as at ON at.ID = a.AccountTypeID
inner join Currencies as cur ON cur.ID = a.CurrencyID
where c.ClientNumber = @ClientNumber
order by a.CreatedAt Desc;";

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

        public static decimal GetTotalBalancesByCurrency(int CurrencyID,byte stausAccount)
        {
            decimal totalBalance = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select Sum(a.Balance) from Accounts as a
                                where a.CurrencyID = @CurrencyID 
                                and a.Status = @stausAccount;";

            SqlCommand command = new SqlCommand(Query,connection);

            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@stausAccount", stausAccount);

            try
            {
                connection.Open();
                object resault = command.ExecuteScalar();
                if (resault != null && decimal.TryParse(resault.ToString(),out decimal res))
                {
                    totalBalance = res;
                }
            }catch(Exception ex) { }
            finally { connection.Close(); }

            return totalBalance;

        }

        public static decimal GetCountAccountsByStatus( byte stausAccount)
        {
            int countAccounts = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select count(*) from Accounts as a
                              where a.Status = @stausAccount;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@stausAccount", stausAccount);

            try
            {
                connection.Open();
                object resault = command.ExecuteScalar();
                if (resault != null && int.TryParse(resault.ToString(), out int res))
                {
                    countAccounts = res;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return countAccounts;

        }


    }

}
