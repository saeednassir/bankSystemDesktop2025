using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankOfPalestineSystemDataAccessLayer
{
    public class UsersDataAccess
    {

        public static bool GetUserByID(int ID, ref int EmployeeID, ref string Username,
            ref string Password, ref bool IsActive, ref DateTime CreatedAt, ref DateTime UpdatedAt,
            ref DateTime LastLogin)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Users where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    EmployeeID = (int)reader["EmployeeID"];
                    Username = (string)reader["Username"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["LastLogin"] != DBNull.Value)
                        LastLogin = (DateTime)reader["LastLogin"];

                    else
                        LastLogin = new DateTime(1900, 01, 01);


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

        public static bool GetUserByUsername(string Username, ref int ID, ref int EmployeeID,
            ref string Password, ref bool IsActive, ref DateTime CreatedAt, ref DateTime UpdatedAt,
            ref DateTime LastLogin)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Users where Username = @Username";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    EmployeeID = (int)reader["EmployeeID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["LastLogin"] != DBNull.Value)
                        LastLogin = (DateTime)reader["LastLogin"];

                    else
                        LastLogin = (DateTime)reader["LastLogin"];


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

        public static int AddNewUser(int EmployeeID, string Username,
            string Password, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt,
            DateTime LastLogin)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Users( EmployeeID, Username,
             Password,  IsActive,  CreatedAt,  UpdatedAt,LastLogin)
                             Values (@EmployeeID, @Username,
             @Password,  @IsActive,  @CreatedAt,  @UpdatedAt,@LastLogin);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
            

            if (LastLogin != new DateTime(1900, 01, 01) && LastLogin != null)
                command.Parameters.AddWithValue("@LastLogin", LastLogin);
            else
                command.Parameters.AddWithValue("@LastLogin", System.DBNull.Value);


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

        public static bool UpdateUser(int ID, int EmployeeID, string Username,
            string Password, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt,
            DateTime LastLogin)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Users 
                             Set 
                             EmployeeID = @EmployeeID,
                             Username = @Username,
                             Password = @Password,
                             IsActive = @IsActive,
                             CreatedAt = @CreatedAt,
                             UpdatedAt = @UpdatedAt,
                             LastLogin = @LastLogin
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (LastLogin != new DateTime(1900, 01, 01) && LastLogin != null)
                command.Parameters.AddWithValue("@LastLogin", LastLogin);
            else
                command.Parameters.AddWithValue("@LastLogin", System.DBNull.Value);


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

        public static bool DeleteUser(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Users Where ID = @ID";

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

        public static bool IsUserExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Users Where ID = @ID";

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

        public static bool IsUserExistByUserName(string Username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Users Where Username = @Username";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Username", Username);

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


        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            
            string Query = @"select * from AllUsers order by CreatedAt Desc;";

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

        public static bool IsUserExistForEmployeeID(int EmployeeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool GetUserInfoByUsernameAndPassword(string Username, string Password,
        ref int ID, ref int EmployeeID, ref bool IsActive, ref DateTime CreatedAt, ref DateTime UpdatedAt,
        ref DateTime LastLogin)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    ID = (int)reader["ID"];
                    EmployeeID = (int)reader["EmployeeID"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["LastLogin"] != DBNull.Value)
                        LastLogin = (DateTime)reader["LastLogin"];

                    else
                        LastLogin = new DateTime(1900, 01, 01);

                    if (reader["UpdatedAt"] != DBNull.Value)
                        UpdatedAt = (DateTime)reader["UpdatedAt"];
                    else
                        UpdatedAt = new DateTime(1900,01,01);



                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int GetCountActiveUsers()
        {
            int countUsers = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select count(*) from Users where IsActive = 1;";

            SqlCommand command = new SqlCommand(Query, connection);



            try
            {
                connection.Open();
                object resault = command.ExecuteScalar();
                if (resault != null && int.TryParse(resault.ToString(), out int res))
                {
                    countUsers = res;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return countUsers;

        }
    }
}
