using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class ClientsDataAccess
    {

        public static bool GetClientByID(int ID, ref int PersonID, ref string ClientNumber,
            ref string Profession, ref string CompanyName, ref byte ClientType,
            ref byte Status, ref DateTime CreatedAt, ref DateTime UpdatedAt,
            ref int CreatedByUserID, ref int UpdatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Clients where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    ClientNumber = (string)reader["ClientNumber"];
                    Profession = (string)reader["Profession"];

                    ClientType = (byte)reader["ClientType"];
                    Status = (byte)reader["Status"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["CompanyName"] != DBNull.Value)
                        CompanyName = (string)reader["CompanyName"];
                    else
                        CompanyName = "";

                    if (reader["UpdatedAt"] != DBNull.Value)
                        UpdatedAt = (DateTime)reader["UpdatedAt"];
                    else
                        UpdatedAt = new DateTime(1900, 01, 01);

                    if (reader["CreatedByUserID"] != DBNull.Value)
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    else
                        CreatedByUserID = -1;

                    if (reader["UpdatedByUserID"] != DBNull.Value)
                        UpdatedByUserID = (int)reader["UpdatedByUserID"];
                    else
                        UpdatedByUserID = -1;

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        //public static bool GetClientByAccountNumber(string ClientNumber,ref int ID, ref int PersonID,
        //   ref string Profession, ref DateTime CreatedDate, ref int CreatedByUser)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

        //    string Query = @"select * from Clients where ClientNumber = @ClientNumber";

        //    SqlCommand command = new SqlCommand(Query, connection);

        //    command.Parameters.AddWithValue("@ClientNumber", ClientNumber);

        //    try
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            isFound = true;

        //            ID = (int)reader["ID"];
        //            PersonID = (int)reader["PersonID"];
        //            Profession = (string)reader["Profession"];
        //            CreatedDate = (DateTime)reader["CreatedDate"];
        //            CreatedByUser = (int)reader["CreatedByUser"];
        //        }
        //        else
        //            isFound = false;

        //        reader.Close();
        //    }
        //    catch (Exception ex) { }
        //    finally { connection.Close(); }

        //    return isFound;

        //}

        public static bool GetClientByPersonID(int PersonID, ref int ID, ref string ClientNumber,
            ref string Profession, ref string CompanyName, ref byte ClientType,
            ref byte Status, ref DateTime CreatedAt, ref DateTime UpdatedAt,
            ref int CreatedByUserID, ref int UpdatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Clients where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    ClientNumber = (string)reader["ClientNumber"];
                    Profession = (string)reader["Profession"];
                    ClientType = (byte)reader["ClientType"];
                    Status = (byte)reader["Status"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["CompanyName"] != DBNull.Value)
                        CompanyName = (string)reader["CompanyName"];
                    else
                        CompanyName = "";

                    if (reader["UpdatedAt"] != DBNull.Value)
                        UpdatedAt = (DateTime)reader["UpdatedAt"];
                    else
                        UpdatedAt = new DateTime(1900, 01, 01);

                    if (reader["CreatedByUserID"] != DBNull.Value)
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    else
                        CreatedByUserID = -1;

                    if (reader["UpdatedByUserID"] != DBNull.Value)
                        UpdatedByUserID = (int)reader["UpdatedByUserID"];
                    else
                        UpdatedByUserID = -1;
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetClientByClientNumber(string ClientNumber, ref int ID, ref int PersonID,
            ref string Profession, ref string CompanyName, ref byte ClientType,
            ref byte Status, ref DateTime CreatedAt, ref DateTime UpdatedAt,
            ref int CreatedByUserID, ref int UpdatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Clients where ClientNumber = @ClientNumber";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ClientNumber", ClientNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    PersonID = (int)reader["PersonID"];
                    Profession = (string)reader["Profession"];
                    ClientType = (byte)reader["ClientType"];
                    Status = (byte)reader["Status"];
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    if (reader["CompanyName"] != DBNull.Value)
                        CompanyName = (string)reader["CompanyName"];
                    else
                        CompanyName = "";

                    if (reader["UpdatedAt"] != DBNull.Value)
                        UpdatedAt = (DateTime)reader["UpdatedAt"];
                    else
                        UpdatedAt = new DateTime(1900, 01, 01);

                    if (reader["CreatedByUserID"] != DBNull.Value)
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    else
                        CreatedByUserID = -1;

                    if (reader["UpdatedByUserID"] != DBNull.Value)
                        UpdatedByUserID = (int)reader["UpdatedByUserID"];
                    else
                        UpdatedByUserID = -1;
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewClient(int PersonID, string ClientNumber,
             string Profession, string CompanyName, byte ClientType,
             byte Status, DateTime CreatedAt, DateTime UpdatedAt,
             int CreatedByUserID, int UpdatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Clients(PersonID,ClientNumber,
            Profession,CompanyName,ClientType,Status,CreatedAt,UpdatedAt,
            CreatedByUserID,UpdatedByUserID)
                             Values (@PersonID,@ClientNumber,
            @Profession,@CompanyName,@ClientType,@Status,@CreatedAt,@UpdatedAt,
            @CreatedByUserID,@UpdatedByUserID);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ClientNumber", ClientNumber);
            command.Parameters.AddWithValue("@Profession", Profession);
            command.Parameters.AddWithValue("@ClientType", ClientType);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (CompanyName != "" && CompanyName != null)
                command.Parameters.AddWithValue("@CompanyName", CompanyName);
            else
                command.Parameters.AddWithValue("@CompanyName", System.DBNull.Value);

            if (UpdatedAt != new DateTime(1900, 01, 01) && UpdatedAt != null)
                command.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
            else
                command.Parameters.AddWithValue("@UpdatedAt", System.DBNull.Value);

            if (CreatedByUserID != -1 && CreatedByUserID != null)
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            else
                command.Parameters.AddWithValue("@CreatedByUserID", System.DBNull.Value);

            if (UpdatedByUserID != -1 && UpdatedByUserID != null)
                command.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            else
                command.Parameters.AddWithValue("@UpdatedByUserID", System.DBNull.Value);



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

        public static bool UpdateClient(int ID, int PersonID, string ClientNumber,
             string Profession, string CompanyName, byte ClientType,
             byte Status, DateTime CreatedAt, DateTime UpdatedAt,
             int CreatedByUserID, int UpdatedByUserID)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Clients 
                             Set 
                             PersonID = @PersonID,
                             ClientNumber = @ClientNumber,
                             Profession = @Profession,
                             CompanyName = @CompanyName,
                             ClientType = @ClientType,
                             Status = @Status,
                             CreatedAt = @CreatedAt,
                             UpdatedAt = @UpdatedAt,
                             CreatedByUserID = @CreatedByUserID,
                             UpdatedByUserID = @UpdatedByUserID
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ClientNumber", ClientNumber);
            command.Parameters.AddWithValue("@Profession", Profession);
            command.Parameters.AddWithValue("@ClientType", ClientType);
            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            if (CompanyName != "" && CompanyName != null)
                command.Parameters.AddWithValue("@CompanyName", CompanyName);
            else
                command.Parameters.AddWithValue("@CompanyName", System.DBNull.Value);

            if (UpdatedAt != new DateTime(1900, 01, 01) && UpdatedAt != null)
                command.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
            else
                command.Parameters.AddWithValue("@UpdatedAt", System.DBNull.Value);

            if (CreatedByUserID != -1 && CreatedByUserID != null)
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            else
                command.Parameters.AddWithValue("@CreatedByUserID", System.DBNull.Value);

            if (UpdatedByUserID != -1 && UpdatedByUserID != null)
                command.Parameters.AddWithValue("@UpdatedByUserID", UpdatedByUserID);
            else
                command.Parameters.AddWithValue("@UpdatedByUserID", System.DBNull.Value);


            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteClient(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Clients Where ID = @ID";

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

        public static bool IsClientExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Clients Where ID = @ID";

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

        public static bool IsClientExistByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Clients Where PersonID = @PersonID";

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
        public static DataTable GetAllClients()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);
            /*select c.ID, 
FullName = p.FirstName + ' ' + p.SecoundName + ' ' + p.ThirdName + ' ' + p.LastName,
c.ClientNumber,c.Profession,c.CompanyName,
Case
    when c.ClientType = 0 then 'أفراد'

    when c.ClientType = 1 then 'شركة'

    else 'غير معروف'
end as ClientType,
Case
    when c.Status = 0 then 'معلق'

    when c.Status = 1 then 'فعال'

    when c.Status = 2 then 'غير فعال'

    when c.Status = 3 then 'محظور'

    else 'غير معروف'
end as Status,c.CreatedAt
from Clients As c
inner join People as p ON p.PersonID = c.PersonID;*/

            string Query = @"select * from AllClients;";

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

        public static decimal GetCountClientsByStatus(byte status)
        {
            int countClient = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select count(*) from clients as c
                             where c.Status = @status;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@status", status);

            try
            {
                connection.Open();
                object resault = command.ExecuteScalar();
                if (resault != null && int.TryParse(resault.ToString(), out int res))
                {
                    countClient = res;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return countClient;

        }


    }
}
