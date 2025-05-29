using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemDataAccessLayer
{
    public class EmployeesDataAccess
    {

        public static bool GetEmployeeByID(int ID, ref int PersonID,
            ref int BranchID, ref string JobTitle, ref int DepartmentID,
            ref decimal Salary, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Employees where ID = @ID";

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
                    BranchID = (int)reader["BranchID"];
                    JobTitle = (string)reader["JobTitle"];
                    DepartmentID = (int)reader["DepartmentID"];
                    Salary = (decimal)reader["Salary"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetEmployeeIDByFullName(string FullName, ref int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from (select ID, FullName = People.FirstName + ' ' + People.SecoundName + ' ' + People.LastName 
from Employees inner join People ON People.PersonID = Employees.PersonID)R1
where FullName =  @FullName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@FullName", FullName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetEmployeeNameByID(int ID, ref string FullName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"
select FullName = People.FirstName + ' ' + People.SecoundName + ' ' + People.LastName
from Employees 
inner join People ON People.PersonID = Employees.PersonID
where Employees.ID = @ID;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    FullName = (string)reader["FullName"];

                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetEmployeeByNationalNumber(string NationalNumber, ref int ID, ref int PersonID,
           ref int BranchID, ref string JobTitle, ref int DepartmentID,
           ref decimal Salary, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select Employees.* from Employees 
inner join People ON Employees.PersonID = People.PersonID
where People.NationalNumber = @NationalNumber;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["ID"];
                    PersonID = (int)reader["PersonID"];
                    BranchID = (int)reader["BranchID"];
                    JobTitle = (string)reader["JobTitle"];
                    DepartmentID = (int)reader["DepartmentID"];
                    Salary = (decimal)reader["Salary"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static bool GetEmployeeByPersonID(int PersonID, ref int ID,
          ref int BranchID, ref string JobTitle, ref int DepartmentID,
          ref decimal Salary, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from Employees where PersonID = @PersonID";

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
                    BranchID = (int)reader["BranchID"];
                    JobTitle = (string)reader["JobTitle"];
                    DepartmentID = (int)reader["DepartmentID"];
                    Salary = (decimal)reader["Salary"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }
                else
                    isFound = false;

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static int AddNewEmployee(int PersonID,
             int BranchID, string JobTitle, int DepartmentID,
            decimal Salary, DateTime CreatedDate)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Insert Into Employees(PersonID,
             BranchID, JobTitle, DepartmentID,
             Salary,  CreatedDate)
                             Values (@PersonID,
             @BranchID, @JobTitle, @DepartmentID,
             @Salary,  @CreatedDate);
                             Select Scope_Identity();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@BranchID", BranchID);
            command.Parameters.AddWithValue("@JobTitle", JobTitle);
            command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);


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

        public static bool UpdateEmployee(int ID, int PersonID,
             int BranchID, string JobTitle, int DepartmentID,
            decimal Salary, DateTime CreatedDate)
        {
            int AffictedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Update Employees 
                             Set 
                             PersonID = @PersonID,
                             BranchID = @BranchID,
                             JobTitle = @JobTitle,
                             DepartmentID = @DepartmentID,
                             Salary = @Salary,
                             CreatedDate = @CreatedDate
                             Where ID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@BranchID", BranchID);
            command.Parameters.AddWithValue("@JobTitle", JobTitle);
            command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);


            try
            {
                connection.Open();

                AffictedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return (AffictedRows > 0);

        }

        public static bool DeleteEmployee(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"Delete From Employees Where ID = @ID";

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

        public static bool IsEmployeesExistByID(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select isFound = 1 from Employees Where ID = @ID";

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

        public static bool IsEmployeeExistForPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string query = "SELECT Found=1 FROM Employees WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select * from AllEmployees order by CreatedDate Desc;";

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

        public static DataTable GetAllMangerEmployees()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select FullName = People.FirstName + ' ' + People.SecoundName + ' ' + People.LastName 
from Employees inner join People ON People.PersonID = Employees.PersonID
where DepartmentID = 1002 order by CreatedDate Desc;";

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

        public static int GetCountEmployees()
        {
            int countEmployees = 0;

            SqlConnection connection = new SqlConnection(DataAccessSetting.ConnectionString);

            string Query = @"select count(*) from Employees;";

            SqlCommand command = new SqlCommand(Query, connection);



            try
            {
                connection.Open();
                object resault = command.ExecuteScalar();
                if (resault != null && int.TryParse(resault.ToString(), out int res))
                {
                    countEmployees = res;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return countEmployees;

        }


    }
}
