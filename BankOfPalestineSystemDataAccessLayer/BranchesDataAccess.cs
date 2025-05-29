using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class BranchesDataAccess
    {
        public static bool GetBranchByID(int ID, ref string Code, ref string Name, ref string Address,
            ref string PhoneNumber, ref DateTime OpeningDate, ref int BankID, ref int MangerID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Branches where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    Code = (string)reader["Code"];
                    Name = (string)reader["Name"];
                    Address = (string)reader["Address"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    OpeningDate = (DateTime)reader["OpeningDate"];
                    BankID = (int)reader["BankID"];
                    MangerID = (int)reader["MangerID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetBranchByName(string Name, ref int ID, ref string Code, ref string Address,
           ref string PhoneNumber, ref DateTime OpeningDate, ref int BankID, ref int MangerID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Branches where Name = @Name";

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
                    Address = (string)reader["Address"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    OpeningDate = (DateTime)reader["OpeningDate"];
                    BankID = (int)reader["BankID"];
                    MangerID = (int)reader["MangerID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }


        public static bool GetBranchByCode(string Code, ref int ID, ref string Name, ref string Address,
          ref string PhoneNumber, ref DateTime OpeningDate, ref int BankID, ref int MangerID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Branches where Code = @Code";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Code", Code);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    Name = (string)reader["Name"];
                    Address = (string)reader["Address"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    OpeningDate = (DateTime)reader["OpeningDate"];
                    BankID = (int)reader["BankID"];
                    MangerID = (int)reader["MangerID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }



        public static int AddNewBranch(string Code, string Name, string Address,
             string PhoneNumber, DateTime OpeningDate, int BankID, int MangerID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Branches(Code,Name,Address,
              PhoneNumber,OpeningDate,BankID,MangerID)
                             Values (@Code,@Name,@Address,
              @PhoneNumber,@OpeningDate,@BankID,@MangerID);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@OpeningDate", OpeningDate);
            command.Parameters.AddWithValue("@BankID", BankID);
            command.Parameters.AddWithValue("@MangerID", MangerID);


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

        public static bool UpdateBranch(int ID, string Code, string Name, string Address,
             string PhoneNumber, DateTime OpeningDate, int BankID, int MangerID)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Branches 
                             Set 
                             Code = @Code,
                             Name = @Name,
                             Address = @Address,
                             PhoneNumber = @PhoneNumber,
                             OpeningDate = @OpeningDate,
                             BankID = @BankID,
                             MangerID = @MangerID
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@OpeningDate", OpeningDate);
            command.Parameters.AddWithValue("@BankID", BankID);
            command.Parameters.AddWithValue("@MangerID", MangerID);

            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteBranch(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Branches Where ID = @ID";

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

        public static bool IsBranchExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Branches Where ID = @ID";

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

        public static DataTable GetAllBranches()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select Branches.ID,Branches.Code,Branches.Name,Branches.Address,
Branches.PhoneNumber,Branches.OpeningDate,Banks.Name as BankName,
BrancheManger =FirstName+' '+SecoundName+' '+ LastName from Branches
inner join Banks ON Banks.ID = Branches.BankID
inner join Employees ON Employees.ID = Branches.MangerID
inner join People ON People.PersonID = Employees.PersonID;";

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

        public static int GetCountBranches()
        {
            int countBranches = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select count(*) from Branches;";

            SqlCommand command = new SqlCommand(Query, connection);

           

            try
            {
                connection.Open();
                object resault = command.ExecuteScalar();
                if (resault != null && int.TryParse(resault.ToString(), out int res))
                {
                    countBranches = res;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return countBranches;

        }

    }
}
