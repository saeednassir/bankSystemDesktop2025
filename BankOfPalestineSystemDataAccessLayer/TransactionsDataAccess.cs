using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class TransactionsDataAccess
    {
        public static bool GetTransactionsByID(int ID, ref int TransactionTypeID,
                ref int SourceAccountID, ref int DestinationAccountID, ref decimal Amount,
                ref int CurrencyID, ref DateTime TransactionDateTime, ref string Description,
                ref string ReferenceNumber, ref byte Status, ref decimal ExchangeRateUsed,
                ref decimal FeeAmount, ref int FeeCurrencyID, ref DateTime CreatedAt,
                ref int CreatedByUser, ref int AffectedCard)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Transactions where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TransactionTypeID = (int)reader["TransactionTypeID"];
                    Amount = (decimal)reader["Amount"];
                    CurrencyID = (int)reader["CurrencyID"];
                    TransactionDateTime = (DateTime)reader["TransactionDateTime"];
                    Status = (byte)reader["Status"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    CreatedByUser = (int)reader["CreatedByUser"];

                    if (reader["SourceAccountID"] != DBNull.Value)
                        SourceAccountID = (int)reader["SourceAccountID"];
                    else
                        SourceAccountID = -1;

                    if (reader["DestinationAccountID"] != DBNull.Value)
                        DestinationAccountID = (int)reader["DestinationAccountID"];
                    else
                        DestinationAccountID = -1;

                    if (reader["Description"] != DBNull.Value)
                        Description = (string)reader["Description"];
                    else
                        Description = "";

                    if (reader["ReferenceNumber"] != DBNull.Value)
                        ReferenceNumber = (string)reader["ReferenceNumber"];
                    else
                        ReferenceNumber = "";

                    if (reader["ExchangeRateUsed"] != DBNull.Value)
                        ExchangeRateUsed = (decimal)reader["ExchangeRateUsed"];
                    else
                        ExchangeRateUsed = 0;

                    if (reader["FeeAmount"] != DBNull.Value)
                        FeeAmount = (decimal)reader["FeeAmount"];
                    else
                        FeeAmount = 0;

                    if (reader["FeeCurrencyID"] != DBNull.Value)
                        FeeCurrencyID = (int)reader["FeeCurrencyID"];
                    else
                        FeeCurrencyID = -1;

                    if (reader["AffectedCard"] != DBNull.Value)
                        AffectedCard = (int)reader["AffectedCard"];
                    else
                        AffectedCard = -1;



                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }


        public static bool GetTransactionsByReferanceNumber(string ReferenceNumber,
                ref int ID, ref int TransactionTypeID,
                ref int SourceAccountID, ref int DestinationAccountID, ref decimal Amount,
                ref int CurrencyID, ref DateTime TransactionDateTime, ref string Description,
                ref byte Status, ref decimal ExchangeRateUsed,
                ref decimal FeeAmount, ref int FeeCurrencyID, ref DateTime CreatedAt,
                ref int CreatedByUser, ref int AffectedCard)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Transactions where ReferenceNumber = @ReferenceNumber";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ReferenceNumber", ReferenceNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];

                    TransactionTypeID = (int)reader["TransactionTypeID"];
                    Amount = (decimal)reader["Amount"];
                    CurrencyID = (int)reader["CurrencyID"];
                    TransactionDateTime = (DateTime)reader["TransactionDateTime"];
                    Status = (byte)reader["Status"];
                    CreatedAt = (DateTime)reader["CreatedAt"];
                    CreatedByUser = (int)reader["CreatedByUser"];

                    if (reader["SourceAccountID"] != DBNull.Value)
                        SourceAccountID = (int)reader["SourceAccountID"];
                    else
                        SourceAccountID = -1;

                    if (reader["DestinationAccountID"] != DBNull.Value)
                        DestinationAccountID = (int)reader["DestinationAccountID"];
                    else
                        DestinationAccountID = -1;

                    if (reader["Description"] != DBNull.Value)
                        Description = (string)reader["Description"];
                    else
                        Description = "";

                    if (reader["ExchangeRateUsed"] != DBNull.Value)
                        ExchangeRateUsed = (decimal)reader["ExchangeRateUsed"];
                    else
                        ExchangeRateUsed = 0;

                    if (reader["FeeAmount"] != DBNull.Value)
                        FeeAmount = (decimal)reader["FeeAmount"];
                    else
                        FeeAmount = 0;

                    if (reader["FeeCurrencyID"] != DBNull.Value)
                        FeeCurrencyID = (int)reader["FeeCurrencyID"];
                    else
                        FeeCurrencyID = -1;

                    if (reader["AffectedCard"] != DBNull.Value)
                        AffectedCard = (int)reader["AffectedCard"];
                    else
                        AffectedCard = -1;
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }


        public static int AddNewTransaction(int TransactionTypeID,
                 int SourceAccountID, int DestinationAccountID, decimal Amount,
                 int CurrencyID, DateTime TransactionDateTime, string Description,
                 string ReferenceNumber, byte Status, decimal ExchangeRateUsed,
                 decimal FeeAmount, int FeeCurrencyID, DateTime CreatedAt,
                 int CreatedByUser, int AffectedCard)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Transactions(TransactionTypeID,SourceAccountID,
                             DestinationAccountID,Amount,CurrencyID,TransactionDateTime,
                             Description,ReferenceNumber,Status,ExchangeRateUsed,
                             FeeAmount,FeeCurrencyID,CreatedAt,CreatedByUser,AffectedCard)
                             Values (@TransactionTypeID,@SourceAccountID,
                             @DestinationAccountID,@Amount,@CurrencyID,@TransactionDateTime,
                             @Description,@ReferenceNumber,@Status,@ExchangeRateUsed,
                             @FeeAmount,@FeeCurrencyID,@CreatedAt,@CreatedByUser,@AffectedCard);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@TransactionDateTime", TransactionDateTime);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);


            if (SourceAccountID != -1 && SourceAccountID != null)
                command.Parameters.AddWithValue("@SourceAccountID", SourceAccountID);
            else
                command.Parameters.AddWithValue("@SourceAccountID", System.DBNull.Value);

            if (DestinationAccountID != -1 && DestinationAccountID != null)
                command.Parameters.AddWithValue("@DestinationAccountID", DestinationAccountID);
            else
                command.Parameters.AddWithValue("@DestinationAccountID", System.DBNull.Value);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Description", Description);
            else
                command.Parameters.AddWithValue("@Description", System.DBNull.Value);

            if (ReferenceNumber != "" && ReferenceNumber != null)
                command.Parameters.AddWithValue("@ReferenceNumber", ReferenceNumber);
            else
                command.Parameters.AddWithValue("@ReferenceNumber", System.DBNull.Value);

            if (ExchangeRateUsed != 0 && ExchangeRateUsed != 1 && ExchangeRateUsed != null)
                command.Parameters.AddWithValue("@ExchangeRateUsed", ExchangeRateUsed);
            else
                command.Parameters.AddWithValue("@ExchangeRateUsed", System.DBNull.Value);

            if (FeeAmount != 0 && FeeAmount != null)
                command.Parameters.AddWithValue("@FeeAmount", FeeAmount);
            else
                command.Parameters.AddWithValue("@FeeAmount", System.DBNull.Value);

            if (FeeCurrencyID != -1 && FeeCurrencyID != null)
                command.Parameters.AddWithValue("@FeeCurrencyID", FeeCurrencyID);
            else
                command.Parameters.AddWithValue("@FeeCurrencyID", System.DBNull.Value);

            if (AffectedCard != -1 && AffectedCard != null)
                command.Parameters.AddWithValue("@AffectedCard", AffectedCard);
            else
                command.Parameters.AddWithValue("@AffectedCard", System.DBNull.Value);



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

        public static bool UpdateTransaction(int ID, int TransactionTypeID,
                 int SourceAccountID, int DestinationAccountID, decimal Amount,
                 int CurrencyID, DateTime TransactionDateTime, string Description,
                 string ReferenceNumber, byte Status, decimal ExchangeRateUsed,
                 decimal FeeAmount, int FeeCurrencyID, DateTime CreatedAt,
                 int CreatedByUser, int AffectedCard)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Transactions 
                             Set 
                             TransactionTypeID = @TransactionTypeID,
                             SourceAccountID = @SourceAccountID,
                             DestinationAccountID = @DestinationAccountID,
                             Amount = @Amount,
                             CurrencyID = @CurrencyID,
                             TransactionDateTime = @TransactionDateTime,
                             Description = @Description,
                             ReferenceNumber = @ReferenceNumber,
                             Status = @Status,
                             ExchangeRateUsed = @ExchangeRateUsed,
                             FeeAmount = @FeeAmount,
                             FeeCurrencyID = @FeeCurrencyID,
                             CreatedAt = @CreatedAt,
                             CreatedByUser = @CreatedByUser,
                             AffectedCard = @AffectedCard
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@TransactionDateTime", TransactionDateTime);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);


            if (SourceAccountID != -1 && SourceAccountID != null)
                command.Parameters.AddWithValue("@SourceAccountID", SourceAccountID);
            else
                command.Parameters.AddWithValue("@SourceAccountID", System.DBNull.Value);

            if (DestinationAccountID != -1 && DestinationAccountID != null)
                command.Parameters.AddWithValue("@DestinationAccountID", DestinationAccountID);
            else
                command.Parameters.AddWithValue("@DestinationAccountID", System.DBNull.Value);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Description", Description);
            else
                command.Parameters.AddWithValue("@Description", System.DBNull.Value);

            if (ReferenceNumber != "" && ReferenceNumber != null)
                command.Parameters.AddWithValue("@ReferenceNumber", ReferenceNumber);
            else
                command.Parameters.AddWithValue("@ReferenceNumber", System.DBNull.Value);

            if (ExchangeRateUsed != 0 && ExchangeRateUsed != 1 && ExchangeRateUsed != null)
                command.Parameters.AddWithValue("@ExchangeRateUsed", ExchangeRateUsed);
            else
                command.Parameters.AddWithValue("@ExchangeRateUsed", System.DBNull.Value);

            if (FeeAmount != 0 && FeeAmount != null)
                command.Parameters.AddWithValue("@FeeAmount", FeeAmount);
            else
                command.Parameters.AddWithValue("@FeeAmount", System.DBNull.Value);

            if (FeeCurrencyID != -1 && FeeCurrencyID != null)
                command.Parameters.AddWithValue("@FeeCurrencyID", FeeCurrencyID);
            else
                command.Parameters.AddWithValue("@FeeCurrencyID", System.DBNull.Value);

            if (AffectedCard != -1 && AffectedCard != null)
                command.Parameters.AddWithValue("@AffectedCard", AffectedCard);
            else
                command.Parameters.AddWithValue("@AffectedCard", System.DBNull.Value);


            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteTransaction(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Transactions Where ID = @ID";

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

        public static bool IsTransactionExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Transactions Where ID = @ID";

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

        public static bool IsTransactionExistByRandomNumber(string RandomNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Transactions Where RandomNumber = @RandomNumber";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@RandomNumber", RandomNumber);

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

        public static DataTable GetAllTransactions()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
          
            string Query = @"select t.ID,Tt.TypeName,accSource.AccountNumber as accSourse,accDestination.AccountNumber as accDestination,
t.Amount,cur.CodeCurrency,t.TransactionDateTime,t.Description,t.ReferenceNumber,
CASE
 WHEN t.Status = 0 THEN 'قيد المراجعة'
 WHEN t.Status = 1 THEN 'مكتملة'
 WHEN t.Status = 2 THEN 'مرفوضة'
 ELSE 'غير معروف'
END as Status,
t.ExchangeRateUsed
from Transactions as t
inner join TransactionTypes as Tt ON Tt.TransactionTypeID = t.TransactionTypeID
left join Accounts as accSource ON accSource.ID = t.SourceAccountID
left join Accounts as accDestination ON accDestination.ID = t.DestinationAccountID
inner join Currencies as cur ON cur.ID = t.CurrencyID
order by t.TransactionDateTime Desc
;";

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

        public static DataTable GetAllTransactionsForAccount(int AccountID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select t.ID,Tt.TypeName,
t.Amount,cur.CodeCurrency,t.TransactionDateTime,t.Description,t.ReferenceNumber,
CASE
 WHEN t.Status = 0 THEN 'قيد المراجعة'
 WHEN t.Status = 1 THEN 'مكتملة'
 WHEN t.Status = 2 THEN 'مرفوضة'
 ELSE 'غير معروف'
END as Status,
t.ExchangeRateUsed
from Transactions as t
inner join TransactionTypes as Tt ON Tt.TransactionTypeID = t.TransactionTypeID
left join Accounts as accSource ON accSource.ID = t.SourceAccountID
left join Accounts as accDestination ON accDestination.ID = t.DestinationAccountID
inner join Currencies as cur ON cur.ID = t.CurrencyID
where accDestination.ID = @AccountID or accSource.ID = @AccountID
order by t.TransactionDateTime Desc";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@AccountID", AccountID);


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

        public static string createReferenceNumber()
        {
            int RandomNumber = 0;

            Random rnd = new Random();
            RandomNumber = rnd.Next(10000, 1000000);

           
            if (IsTransactionExistByRandomNumber("#"+RandomNumber.ToString()) == true)
                createReferenceNumber();

            return "#" + RandomNumber.ToString();
        }
        public static bool Deposit(decimal amountToCreditInAccountCurrency, int AccountID,
            decimal ExchangeRateUsed,int CreatedByUser,int AffectedCard,decimal Amount, int CurrencyID)
        {
            bool isSucceed = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {

                string updateQuery = @"UPDATE Accounts SET Balance = Balance + @amountToCreditInAccountCurrency WHERE ID = @AccountID";

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);

                updateCommand.Parameters.AddWithValue("@amountToCreditInAccountCurrency", amountToCreditInAccountCurrency);
                updateCommand.Parameters.AddWithValue("@AccountID", AccountID);

                int AffectedRowsUpdate = updateCommand.ExecuteNonQuery();
                if (AffectedRowsUpdate != 1)
                {
                    isSucceed = false;
                    throw new Exception("فشل تحديث رصيد الحساب الوجهة.");
                }

             
                string Query = @"Insert Into Transactions(TransactionTypeID,SourceAccountID,
                             DestinationAccountID,Amount,CurrencyID,TransactionDateTime,
                             Description,ReferenceNumber,Status,ExchangeRateUsed,
                             FeeAmount,FeeCurrencyID,CreatedAt,CreatedByUser,AffectedCard)
                             Values (@TransactionTypeID,@SourceAccountID,
                             @DestinationAccountID,@Amount,@CurrencyID,@TransactionDateTime,
                             @Description,@ReferenceNumber,@Status,@ExchangeRateUsed,
                             @FeeAmount,@FeeCurrencyID,@CreatedAt,@CreatedByUser,@AffectedCard);
                             Select Scope_Identity();";

                SqlCommand InsetCommand = new SqlCommand(Query, connection,transaction);

                InsetCommand.Parameters.AddWithValue("@TransactionTypeID", 1008);
                InsetCommand.Parameters.AddWithValue("@Amount", Amount);
                InsetCommand.Parameters.AddWithValue("@CurrencyID", CurrencyID);
                InsetCommand.Parameters.AddWithValue("@TransactionDateTime", DateTime.Now);
                InsetCommand.Parameters.AddWithValue("@Status", 1);
                InsetCommand.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                InsetCommand.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
                InsetCommand.Parameters.AddWithValue("@SourceAccountID", System.DBNull.Value);
                InsetCommand.Parameters.AddWithValue("@DestinationAccountID", AccountID);
                InsetCommand.Parameters.AddWithValue("@Description", $"إيداع نقدي بملغ {Amount} ");
                InsetCommand.Parameters.AddWithValue("@ReferenceNumber", createReferenceNumber());
                InsetCommand.Parameters.AddWithValue("@FeeAmount", System.DBNull.Value);
                InsetCommand.Parameters.AddWithValue("@FeeCurrencyID", System.DBNull.Value);

                if (ExchangeRateUsed != 0 && ExchangeRateUsed != 1 && ExchangeRateUsed != null)
                    InsetCommand.Parameters.AddWithValue("@ExchangeRateUsed", ExchangeRateUsed);
                else
                    InsetCommand.Parameters.AddWithValue("@ExchangeRateUsed", System.DBNull.Value);

                if (AffectedCard != -1 && AffectedCard != null)
                    InsetCommand.Parameters.AddWithValue("@AffectedCard", AffectedCard);
                else
                    InsetCommand.Parameters.AddWithValue("@AffectedCard", System.DBNull.Value);

                int rowsAffectedInsert = InsetCommand.ExecuteNonQuery();

                if (rowsAffectedInsert != 1) 
                { 
                    isSucceed = false;
                    throw new Exception("فشل تسجيل المعاملة في السجل.");
                }





                transaction.Commit();
                isSucceed =  true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                isSucceed = false;
            }
            finally { connection.Close(); }

            return isSucceed;
        }


        public static bool Withdrawal(decimal amountToCreditInAccountCurrency, int AccountID,
           decimal ExchangeRateUsed, int CreatedByUser, int AffectedCard, decimal Amount, int CurrencyID)
        {
            bool isSucceed = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {

                string updateQuery = @"UPDATE Accounts SET Balance = Balance - @AmountToDebit WHERE ID = @AccountID AND Balance >= @AmountToDebit";

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);

                updateCommand.Parameters.AddWithValue("@AmountToDebit", amountToCreditInAccountCurrency);
                updateCommand.Parameters.AddWithValue("@AccountID", AccountID);

                int AffectedRowsUpdate = updateCommand.ExecuteNonQuery();
                if (AffectedRowsUpdate != 1)
                {
                    isSucceed = false;
                    throw new Exception("فشل خصم المبلغ من رصيد الحساب");
                }


                string Query = @"Insert Into Transactions(TransactionTypeID,SourceAccountID,
                             DestinationAccountID,Amount,CurrencyID,TransactionDateTime,
                             Description,ReferenceNumber,Status,ExchangeRateUsed,
                             FeeAmount,FeeCurrencyID,CreatedAt,CreatedByUser,AffectedCard)
                             Values (@TransactionTypeID,@SourceAccountID,
                             @DestinationAccountID,@Amount,@CurrencyID,@TransactionDateTime,
                             @Description,@ReferenceNumber,@Status,@ExchangeRateUsed,
                             @FeeAmount,@FeeCurrencyID,@CreatedAt,@CreatedByUser,@AffectedCard);
                             Select Scope_Identity();";

                SqlCommand InsetCommand = new SqlCommand(Query, connection, transaction);

                InsetCommand.Parameters.AddWithValue("@TransactionTypeID", 1009);
                InsetCommand.Parameters.AddWithValue("@Amount", Amount);
                InsetCommand.Parameters.AddWithValue("@CurrencyID", CurrencyID);
                InsetCommand.Parameters.AddWithValue("@TransactionDateTime", DateTime.Now);
                InsetCommand.Parameters.AddWithValue("@Status", 1);
                InsetCommand.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                InsetCommand.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
                InsetCommand.Parameters.AddWithValue("@SourceAccountID", AccountID);
                InsetCommand.Parameters.AddWithValue("@DestinationAccountID", System.DBNull.Value);
                InsetCommand.Parameters.AddWithValue("@Description", $"سحب نقدي بملغ {Amount} ");
                InsetCommand.Parameters.AddWithValue("@ReferenceNumber", createReferenceNumber());
                InsetCommand.Parameters.AddWithValue("@FeeAmount", System.DBNull.Value);
                InsetCommand.Parameters.AddWithValue("@FeeCurrencyID", System.DBNull.Value);

                if (ExchangeRateUsed != 0 && ExchangeRateUsed != 1 && ExchangeRateUsed != null)
                    InsetCommand.Parameters.AddWithValue("@ExchangeRateUsed", ExchangeRateUsed);
                else
                    InsetCommand.Parameters.AddWithValue("@ExchangeRateUsed", System.DBNull.Value);

                if (AffectedCard != -1 && AffectedCard != null)
                    InsetCommand.Parameters.AddWithValue("@AffectedCard", AffectedCard);
                else
                    InsetCommand.Parameters.AddWithValue("@AffectedCard", System.DBNull.Value);

                int rowsAffectedInsert = InsetCommand.ExecuteNonQuery();

                if (rowsAffectedInsert != 1)
                {
                    isSucceed = false;
                    throw new Exception("فشل تسجيل المعاملة في السجل.");
                }


                transaction.Commit();
                isSucceed = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                isSucceed = false;
            }
            finally { connection.Close(); }

            return isSucceed;
        }


        public static bool TransferBetweenAccounts(decimal amountToCreditInAccountCurrency,
            int sourceAccountId,
            int destinationAccountId, decimal Amount, int CurrencyID,
            int CreatedByUser, decimal ExchangeRateUsed,string Description)
        {
            bool isSucceed = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string updateSourceAccountQuery = @"UPDATE Accounts SET Balance = Balance - @AmountToDebit WHERE ID = @sourceAccountId AND Balance >= @AmountToDebit";

                SqlCommand updateSourceAccountCommand = new SqlCommand(updateSourceAccountQuery, connection, transaction);

                updateSourceAccountCommand.Parameters.AddWithValue("@AmountToDebit", Amount);
                updateSourceAccountCommand.Parameters.AddWithValue("@sourceAccountId", sourceAccountId);

                int AffectedRowsUpdateSourceAccount = updateSourceAccountCommand.ExecuteNonQuery();
                if (AffectedRowsUpdateSourceAccount != 1)
                {
                    isSucceed = false;
                    throw new Exception("فشل خصم المبلغ من رصيد الحساب");
                }

                string updateDestinationAccountQuery = @"UPDATE Accounts SET Balance = Balance + @amountToCreditInAccountCurrency WHERE ID = @destinationAccountId";

                SqlCommand updateDestinationAccountCommand = new SqlCommand(updateDestinationAccountQuery, connection, transaction);

                updateDestinationAccountCommand.Parameters.AddWithValue("@amountToCreditInAccountCurrency", amountToCreditInAccountCurrency);
                updateDestinationAccountCommand.Parameters.AddWithValue("@destinationAccountId", destinationAccountId);

                int AffectedRowsUpdatedestinationAccount = updateDestinationAccountCommand.ExecuteNonQuery();
                if (AffectedRowsUpdatedestinationAccount != 1)
                {
                    isSucceed = false;
                    throw new Exception("فشل تحديث رصيد الحساب الوجهة.");
                }

                // 
                string Query = @"Insert Into Transactions(TransactionTypeID,SourceAccountID,
                             DestinationAccountID,Amount,CurrencyID,TransactionDateTime,
                             Description,ReferenceNumber,Status,ExchangeRateUsed,
                             FeeAmount,FeeCurrencyID,CreatedAt,CreatedByUser,AffectedCard)
                             Values (@TransactionTypeID,@SourceAccountID,
                             @DestinationAccountID,@Amount,@CurrencyID,@TransactionDateTime,
                             @Description,@ReferenceNumber,@Status,@ExchangeRateUsed,
                             @FeeAmount,@FeeCurrencyID,@CreatedAt,@CreatedByUser,@AffectedCard);
                             Select Scope_Identity();";

                SqlCommand InsetCommand = new SqlCommand(Query, connection, transaction);

                InsetCommand.Parameters.AddWithValue("@TransactionTypeID", 1010);
                InsetCommand.Parameters.AddWithValue("@Amount", Amount);
                InsetCommand.Parameters.AddWithValue("@CurrencyID", CurrencyID);
                InsetCommand.Parameters.AddWithValue("@TransactionDateTime", DateTime.Now);
                InsetCommand.Parameters.AddWithValue("@Status", 1);
                InsetCommand.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                InsetCommand.Parameters.AddWithValue("@CreatedByUser", CreatedByUser);
                InsetCommand.Parameters.AddWithValue("@SourceAccountID", sourceAccountId);
                InsetCommand.Parameters.AddWithValue("@DestinationAccountID", destinationAccountId);
                InsetCommand.Parameters.AddWithValue("@Description",Description);
                InsetCommand.Parameters.AddWithValue("@ReferenceNumber", createReferenceNumber());
                InsetCommand.Parameters.AddWithValue("@FeeAmount", System.DBNull.Value);
                InsetCommand.Parameters.AddWithValue("@FeeCurrencyID", System.DBNull.Value);

                if (ExchangeRateUsed != 0 && ExchangeRateUsed != 1 && ExchangeRateUsed != null)
                    InsetCommand.Parameters.AddWithValue("@ExchangeRateUsed", ExchangeRateUsed);
                else
                    InsetCommand.Parameters.AddWithValue("@ExchangeRateUsed", System.DBNull.Value);

                    InsetCommand.Parameters.AddWithValue("@AffectedCard", System.DBNull.Value);

                int rowsAffectedInsert = InsetCommand.ExecuteNonQuery();

                if (rowsAffectedInsert != 1)
                {
                    isSucceed = false;
                    throw new Exception("فشل تسجيل المعاملة في السجل.");
                }


                transaction.Commit();
                isSucceed = true;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                isSucceed = false;
            }
            finally { connection.Close(); }

            return isSucceed;
        
        }
       

        public static decimal GetTotalBalancesForTrasactions(int TransactionTypeID,
            int CurrencyID,byte Status,DateTime FromDate,DateTime ToDate)
        {
            decimal totalBalance = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select sum(t.Amount) as TotalBalances from Transactions as t
                                where t.TransactionTypeID = @TransactionTypeID 
                                and t.CurrencyID = @CurrencyID and t.Status = @Status
                                and t.TransactionDateTime >= @FromDate
                                and t.TransactionDateTime <= @ToDate;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@FromDate", FromDate);
            command.Parameters.AddWithValue("@ToDate", ToDate);

            try
            {
                connection.Open();

                object resault = command.ExecuteScalar();

                if(resault != null && decimal.TryParse(resault.ToString(),out decimal total))
                {
                    totalBalance = total;
                }

            }catch(Exception ex) {}
            finally { connection.Close(); }

            return totalBalance;

        }


        public static decimal GetCountTransactions(DateTime fromDate, DateTime ToDate, byte stauts)
        {
            int CountTransactions = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select count(*) from Transactions as t
                             where t.Status = @stauts
                             and t.TransactionDateTime >= @fromDate
                             and t.TransactionDateTime <= @ToDate;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@stauts", stauts);
            command.Parameters.AddWithValue("@fromDate", fromDate);
            command.Parameters.AddWithValue("@ToDate", ToDate);

            try
            {
                connection.Open();
                object resault = command.ExecuteScalar();
                if (resault != null && int.TryParse(resault.ToString(), out int res))
                {
                    CountTransactions = res;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return CountTransactions;

        }

    }
}
