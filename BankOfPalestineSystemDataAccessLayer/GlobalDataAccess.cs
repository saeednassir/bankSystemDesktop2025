using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class GlobalDataAccess
    {
        public static int GetCountRecordsrFromTable(string TableName)
        {
            int CountRecords = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select Count(*) from People";

            SqlCommand command = new SqlCommand(Query, connection);

           // command.Parameters.AddWithValue("@TableName", TableName);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Count))
                {
                    CountRecords = Count;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return CountRecords;

        }

    }
}
