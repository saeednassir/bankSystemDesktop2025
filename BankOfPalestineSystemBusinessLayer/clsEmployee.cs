using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsEmployee
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int PersonID { set; get; }
        public clsPerson PersonInfo;
        public int BranchID { set; get; }
        public string JobTitle { set; get; }
        public int DepartmentID { set; get; }
        public clsDepartment DepartmentInfo;
        public decimal Salary { set; get; }
        public DateTime CreatedDate { set; get; }

        public clsEmployee()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.BranchID = -1;
            this.JobTitle = "";
            this.DepartmentID = -1;
            this.Salary = 0;
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsEmployee(int ID, int PersonID, int BranchID, string JobTitle,
            int DepartmentID, decimal Salary, DateTime CreatedDate)
        {
            this.ID = ID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.BranchID = BranchID;
            this.JobTitle = JobTitle;
            this.DepartmentID = DepartmentID;
            this.DepartmentInfo = clsDepartment.Find(DepartmentID);
            this.Salary = Salary;
            this.CreatedDate = CreatedDate;

            this.Mode = enMode.Update;
        }

        public static clsEmployee FindByID(int ID)
        {
            int PersonID = -1, BranchID = -1, DepartmentID = -1;
            string JobTitle = "";
            decimal Salary = 0;
            DateTime CreatedDate = DateTime.Now;

            bool IsFound = EmployeesDataAccess.GetEmployeeByID(ID, ref PersonID,
                ref BranchID, ref JobTitle, ref DepartmentID, ref Salary,
                ref CreatedDate);

            if (IsFound)
                return new clsEmployee(ID, PersonID, BranchID, JobTitle, DepartmentID,
                    Salary, CreatedDate);
            else
                return null;

        }

        public static int FindByFullName(string FullName)
        {
            int ID = -1;

            bool IsFound = EmployeesDataAccess.GetEmployeeIDByFullName(FullName, ref ID);

            if (IsFound)
                return ID;
            else
                return -1;

        }

        public static string FindEmployeeNameByID(int ID)
        {
            string FullName = "";

            bool IsFound = EmployeesDataAccess.GetEmployeeNameByID(ID, ref FullName);

            if (IsFound)
                return FullName;
            else
                return "";

        }
        public static clsEmployee FindByNationalNumber(string NationalNumber)
        {
            int ID = -1, PersonID = -1, BranchID = -1, DepartmentID = -1;
            string JobTitle = "";
            decimal Salary = 0;
            DateTime CreatedDate = DateTime.Now;

            bool IsFound = EmployeesDataAccess.GetEmployeeByNationalNumber(NationalNumber,
                ref ID, ref PersonID, ref BranchID, ref JobTitle,
                ref DepartmentID, ref Salary, ref CreatedDate);

            if (IsFound)
                return new clsEmployee(ID, PersonID, BranchID, JobTitle, DepartmentID,
                    Salary, CreatedDate);
            else
                return null;

        }


        public static clsEmployee FindByPersonID(int PersonID)
        {
            int ID = -1, BranchID = -1, DepartmentID = -1;
            string JobTitle = "";
            decimal Salary = 0;
            DateTime CreatedDate = DateTime.Now;

            bool IsFound = EmployeesDataAccess.GetEmployeeByPersonID(PersonID, ref ID,
                ref BranchID, ref JobTitle, ref DepartmentID, ref Salary,
                ref CreatedDate);

            if (IsFound)
                return new clsEmployee(ID, PersonID, BranchID, JobTitle, DepartmentID,
                    Salary, CreatedDate);
            else
                return null;

        }

        private bool _AddNewEmployee()
        {
            this.ID = EmployeesDataAccess.AddNewEmployee(PersonID, BranchID, JobTitle,
                DepartmentID, Salary, CreatedDate);
            return (this.ID != -1);
        }

        private bool _UpdateEmployee()
        {
            return EmployeesDataAccess.UpdateEmployee(ID, PersonID, BranchID, JobTitle,
                DepartmentID, Salary, CreatedDate);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployee())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateEmployee();

            }

            return false;
        }

        public static bool DeleteEmployee(int ID)
        {
            return EmployeesDataAccess.DeleteEmployee(ID);
        }

        public static bool isEmployeeExist(int ID)
        {
            return EmployeesDataAccess.IsEmployeesExistByID(ID);
        }

        public static DataTable GetAllEmployees()
        {
            return EmployeesDataAccess.GetAllEmployees();
        }
        public static DataTable GetAllMangerEmployees()
        {
            return EmployeesDataAccess.GetAllMangerEmployees();
        }

        public static bool isEmployeeExistForPersonID(int PersonID)
        {
            return EmployeesDataAccess.IsEmployeeExistForPersonID(PersonID);
        }

        public static int GetCountEmployees()
        {
            return EmployeesDataAccess.GetCountEmployees();
        }

    }
}
