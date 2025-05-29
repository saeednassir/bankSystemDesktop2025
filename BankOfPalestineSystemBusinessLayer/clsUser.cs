using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using System.Data.SqlClient;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int EmployeeID { set; get; }
        public clsEmployee EmployeeInfo;
        public string Username { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }
        public DateTime LastLogin { set; get; }


        public clsUser()
        {
            this.ID = -1;
            this.EmployeeID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = false;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = new DateTime(1900,01,01);
            this.LastLogin = new DateTime(1900, 01, 01);

            Mode = enMode.AddNew;

        }
        public static string GetplainPassword(string hashedPassword)
        {
            //string plainPassword = BCrypt.Net.BCrypt.(hashedPassword);

            // return plainPassword;
            return "";
        }
        public string HashPassword(string plainPassword)
        {
           
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword, 12);
            return hashedPassword;
        }
        public static bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            bool isPasswordCorrect = false;
            try
            {
               
                isPasswordCorrect = BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error verifying password: {ex.Message}");
                isPasswordCorrect = false;
            }
            return isPasswordCorrect;
        }

        private clsUser(int iD, int employeeID, string username, string password,
            bool isActive, DateTime createdAt, DateTime updatedAt, DateTime lastLogin)
        {
            this.ID = iD;
            this.EmployeeID = employeeID;
            this.EmployeeInfo = clsEmployee.FindByID(employeeID);
            this.Username = username;
            this.Password = password;
            this.IsActive = isActive;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.LastLogin = lastLogin;

            Mode = enMode.Update;
        }


        public static clsUser Find(int ID)
        {
            int EmployeeID = -1;
            string Username = "", Password = "";
            DateTime CreatedAt = DateTime.Now, UpdatedAt = new DateTime(1900, 01, 01),
                LastLogin = new DateTime(1900, 01, 01);
            bool IsActive = false;

            bool IsFound = UsersDataAccess.GetUserByID(ID, ref EmployeeID,
                ref Username, ref Password, ref IsActive, ref CreatedAt, ref UpdatedAt,
                ref LastLogin);

            if (IsFound)
                return new clsUser(ID, EmployeeID, Username, Password, IsActive,
                    CreatedAt, UpdatedAt, LastLogin);
            else
                return null;

        }

        public static clsUser Find(string Username)
        {
            int ID = -1, EmployeeID = -1;
            string Password = "";
            DateTime CreatedAt = DateTime.Now, UpdatedAt = new DateTime(1900, 01, 01),
                LastLogin = new DateTime(1900, 01, 01);
            bool IsActive = false;

            bool IsFound = UsersDataAccess.GetUserByUsername(Username, ref ID, ref EmployeeID,
                ref Password, ref IsActive, ref CreatedAt, ref UpdatedAt,
                ref LastLogin);

            if (IsFound)
                return new clsUser(ID, EmployeeID, Username, Password, IsActive,
                    CreatedAt, UpdatedAt, LastLogin);
            else
                return null;

        }


        private bool _AddNewUser()
        {
            string hashPassword = HashPassword(Password);

            this.ID = UsersDataAccess.AddNewUser(EmployeeID, Username, hashPassword,
                IsActive, CreatedAt, UpdatedAt, LastLogin);
            return (this.ID != -1);
        }

        private bool _UpdateUser()
        {
            string hashPassword = HashPassword(Password);

            return UsersDataAccess.UpdateUser(ID, EmployeeID, Username, hashPassword,
                IsActive, CreatedAt, UpdatedAt, LastLogin);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateUser();

            }

            return false;
        }

        public static bool DeleteUser(int ID)
        {
            return UsersDataAccess.DeleteUser(ID);
        }

        public static bool isUserExist(int ID)
        {
            return UsersDataAccess.IsUserExistByID(ID);
        }

        public static bool isUserExist(string Username)
        {
            return UsersDataAccess.IsUserExistByUserName(Username);
        }

        public static DataTable GetAllUsers()
        {
            return UsersDataAccess.GetAllUsers();
        }

        public static bool IsUserExistForEmployeeID(int EmployeeID)
        {
            return UsersDataAccess.IsUserExistForEmployeeID(EmployeeID);
        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int EmployeeID = -1;
            DateTime LastLogin = new DateTime(1900, 01, 01), CreatedAt = DateTime.Now, UpdatedAt = new DateTime(1900, 01, 01);
            bool IsActive = false;
            string storedHashedPassword = "";



            bool IsFound = UsersDataAccess.GetUserByUsername
                                (UserName, ref UserID, ref EmployeeID, 
                                ref storedHashedPassword, ref IsActive,
                                ref CreatedAt, ref UpdatedAt, ref LastLogin);
          
            if (IsFound && VerifyPassword(Password,storedHashedPassword))
                //we return new object of that User with the right data
                return new clsUser(UserID, EmployeeID, UserName, Password, IsActive, CreatedAt, UpdatedAt, LastLogin);
            else
                return null;
        }

        public static int GetCountActiveUsers()
        {
            return UsersDataAccess.GetCountActiveUsers();
        }

    }
}
