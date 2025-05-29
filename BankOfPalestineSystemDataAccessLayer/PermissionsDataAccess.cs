using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class PermissionsDataAccess
    {
        public static bool GetPermissionByID(int PermissionID, ref string PermissionName,
            ref string Description, ref string Category, ref DateTime CreatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Permissions where PermissionID = @PermissionID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PermissionID", PermissionID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PermissionName = (string)reader["PermissionName"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["Description"] != DBNull.Value)
                        Description = (string)reader["Description"];
                    else
                        Description = "";

                    if (reader["Category"] != DBNull.Value)
                        Category = (string)reader["Category"];
                    else
                        Category = "";
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetPermissionByName(string PermissionName, ref int PermissionID,
           ref string Description, ref string Category, ref DateTime CreatedAt)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Permissions where PermissionName = @PermissionName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PermissionName", PermissionName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PermissionID = (int)reader["PermissionID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["Description"] != DBNull.Value)
                        Description = (string)reader["Description"];
                    else
                        Description = "";

                    if (reader["Category"] != DBNull.Value)
                        Category = (string)reader["Category"];
                    else
                        Category = "";

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewPermission(string PermissionName, string Description, string Category, DateTime CreatedAt)
        {
            int PermissionID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Permissions(PermissionName,Description,Category,CreatedAt)
                         Values (@PermissionName,@Description,@Category,@CreatedAt);
                         Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PermissionName", PermissionName);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Description", Description);
            else
                command.Parameters.AddWithValue("@Description", DBNull.Value);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Category", Category);
            else
                command.Parameters.AddWithValue("@Category", Category);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PermissionID = insertedID;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return PermissionID;
        }

        public static bool UpdatePermission(int PermissionID, string PermissionName, string Description, string Category, DateTime CreatedAt)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Permissions 
                         Set 
                         PermissionName = @PermissionName,
                         Description = @Description,
                         Category = @Category,
                         CreatedAt = @CreatedAt
                         Where PermissionID = @PermissionID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PermissionID", PermissionID);
            command.Parameters.AddWithValue("@PermissionName", PermissionName);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Description", Description);
            else
                command.Parameters.AddWithValue("@Description", DBNull.Value);

            if (Description != "" && Description != null)
                command.Parameters.AddWithValue("@Category", Category);
            else
                command.Parameters.AddWithValue("@Category", Category);



            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeletePermission(int PermissionID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Permissions Where PermissionID = @PermissionID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PermissionID", PermissionID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffectedRows > 0);

        }

        public static bool IsPermissionExistByID(int PermissionID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Permissions Where PermissionID = @PermissionID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PermissionID", PermissionID);

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

        public static DataTable GetAllPermissions()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Permissions;";

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

        public static HashSet<string> GetAllPermissionNameByUserID(int UserID)
        {
            HashSet<string> Permissions = new HashSet<string>();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select DISTINCT p.PermissionName
from Permissions As p
inner join RolePermissions As rp ON p.PermissionID = rp.PermissionID
inner join UserRoles As ur ON ur.RoleID = rp.RoleID
where ur.UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Permissions.Add((string)reader["PermissionName"]);
                    }
                    
                }
                else
                    Permissions = null;
                
               
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return Permissions;

        }

    }
}
