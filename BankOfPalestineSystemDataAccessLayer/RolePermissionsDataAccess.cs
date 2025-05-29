using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class RolePermissionsDataAccess
    {
        public static bool GetRolePermissionByID(int ID, ref int RoleID,
            ref int PermissionID, ref DateTime CreatedAt, ref int GrantedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from RolePermissions where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    RoleID = (int)reader["RoleID"];
                    PermissionID = (int)reader["PermissionID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["GrantedByUserID"] != DBNull.Value)
                        GrantedByUserID = (int)reader["GrantedByUserID"];
                    else
                        GrantedByUserID = -1;
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }


        public static bool GetRolePermissionByRoleAndPermissionID(int RoleID, int PermissionID,
            ref int ID, ref DateTime CreatedAt, ref int GrantedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from RolePermissions where RoleID = @RoleID and PermissionID = @PermissionID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@RoleID", RoleID);
            command.Parameters.AddWithValue("@PermissionID", PermissionID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    CreatedAt = (DateTime)reader["CreatedAt"];


                    if (reader["GrantedByUserID"] != DBNull.Value)
                        GrantedByUserID = (int)reader["GrantedByUserID"];
                    else
                        GrantedByUserID = -1;

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewRolePermission(int RoleID, int PermissionID,
            DateTime CreatedAt, int GrantedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into RolePermissions(RoleID,PermissionID,CreatedAt,GrantedByUserID)
                             Values (@RoleID,@PermissionID,@CreatedAt,@GrantedByUserID);
                             Select Scope_Identity();";
            
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@RoleID", RoleID);
            command.Parameters.AddWithValue("@PermissionID", PermissionID);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (GrantedByUserID != -1 && GrantedByUserID != null)
                command.Parameters.AddWithValue("@GrantedByUserID", GrantedByUserID);
            else
                command.Parameters.AddWithValue("@GrantedByUserID", System.DBNull.Value);


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

        public static bool UpdateRolePermission(int ID, int RoleID, int PermissionID,
            DateTime CreatedAt, int GrantedByUserID)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update RolePermissions 
                             Set 
                             RoleID = @RoleID,
                             PermissionID = @PermissionID,
                             CreatedAt = @CreatedAt,
                             GrantedByUserID = @GrantedByUserID
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@RoleID", RoleID);
            command.Parameters.AddWithValue("@PermissionID", PermissionID);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (GrantedByUserID != -1 && GrantedByUserID != null)
                command.Parameters.AddWithValue("@GrantedByUserID", GrantedByUserID);
            else
                command.Parameters.AddWithValue("@GrantedByUserID", DBNull.Value);

            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteRolePermission(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From RolePermissions Where ID = @ID";

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

        public static bool IsRolePermissionExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from RolePermissions Where ID = @ID";

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

        public static bool IsRolePermissionExistByRoleAndPermissionID(int RoleID, int PermissionID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from RolePermissions 
                            Where RoleID = @RoleID and PermissionID = @PermissionID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@RoleID", RoleID);
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

        public static DataTable GetAllRolePermissions()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select RolePermissions.ID,Roles.RoleName,Permissions.PermissionName,RolePermissions.CreatedAt
 from RolePermissions
inner join Roles ON Roles.RoleID = RolePermissions.RoleID
inner join Permissions ON Permissions.PermissionID = RolePermissions.PermissionID;";

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
