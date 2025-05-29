using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class PeopleDataAccess
    {
        public static bool GetPersonByID(int PersonID, ref string NationalNumber,
            ref string FirstName, ref string SecoundName, ref string ThirdName,
            ref string LastName, ref short Gender, ref string PhoneNumber,
            ref string Email, ref string Address, ref int NationalityID, ref DateTime DateOfBirth)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from People where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNumber = (string)reader["NationalNumber"];
                    Address = (string)reader["Address"];
                    FirstName = (string)reader["FirstName"];
                    SecoundName = (string)reader["SecoundName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];
                    Gender = (byte)reader["Gender"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    Address = (string)reader["Address"];
                    NationalityID = (int)reader["NationalityID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetPersonByNationalNumber(string NationalNumber, ref int PersonID,
           ref string FirstName, ref string SecoundName, ref string ThirdName,
           ref string LastName, ref short Gender, ref string PhoneNumber,
           ref string Email, ref string Address, ref int NationalityID, ref DateTime DateOfBirth)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from People where NationalNumber = @NationalNumber";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    Address = (string)reader["Address"];
                    FirstName = (string)reader["FirstName"];
                    SecoundName = (string)reader["SecoundName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";

                    LastName = (string)reader["LastName"];
                    Gender = (byte)reader["Gender"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";

                    Address = (string)reader["Address"];
                    NationalityID = (int)reader["NationalityID"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }


        public static int AddNewPerson(string NationalNumber,
            string FirstName, string SecoundName, string ThirdName,
            string LastName, short Gender, string PhoneNumber,
            string Email, string Address, int NationalityID, DateTime DateOfBirth)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into People(NationalNumber,
            FirstName, SecoundName, ThirdName,
            LastName, Gender, PhoneNumber,
            Email, Address, NationalityID,DateOfBirth)
                             Values (@NationalNumber,
            @FirstName, @SecoundName, @ThirdName,
            @LastName, @Gender, @PhoneNumber,
            @Email, @Address, @NationalityID,@DateOfBirth);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecoundName", SecoundName);

            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@NationalityID", NationalityID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return PersonID;
        }


        public static bool UpdatePerson(int PersonID, string NationalNumber,
            string FirstName, string SecoundName, string ThirdName,
            string LastName, short Gender, string PhoneNumber,
            string Email, string Address, int NationalityID, DateTime DateOfBirth)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update People 
                             Set 
                             NationalNumber = @NationalNumber,
                             FirstName = @FirstName,
                             SecoundName = @SecoundName,
                             ThirdName = @ThirdName,
                             LastName = @LastName,
                             Gender = @Gender,
                             PhoneNumber = @PhoneNumber,
                             Email = @Email,
                             Address = @Address,
                             NationalityID = @NationalityID,
                             DateOfBirth = @DateOfBirth
                             Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecoundName", SecoundName);

            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@NationalityID", NationalityID);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeletePerson(int PersonID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From People Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffectedRows > 0);

        }

        public static bool IsPersonExistByID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from People Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExistByNationalNumber(string NationalNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from People Where NationalNumber = @NationalNumber";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

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


        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from AllPeople order by FullName Asc;";

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
