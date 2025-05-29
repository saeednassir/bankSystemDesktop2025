using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsDepartment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }

        public clsDepartment()
        {
            this.ID = -1;
            this.Name = "";

            Mode = enMode.AddNew;

        }

        private clsDepartment(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;

            Mode = enMode.Update;
        }

        public static clsDepartment Find(int ID)
        {
            string Name = "";

            bool IsFound = DepartmentsDataAccess.GetDepartmentByID(ID, ref Name);

            if (IsFound)
                return new clsDepartment(ID, Name);
            else
                return null;

        }

        public static clsDepartment Find(string Name)
        {
            int ID = -1;

            bool IsFound = DepartmentsDataAccess.GetDepartmentByName(Name, ref ID);

            if (IsFound)
                return new clsDepartment(ID, Name);
            else
                return null;

        }

        private bool _AddNewDepartment()
        {
            this.ID = DepartmentsDataAccess.AddNewDepartment(Name);
            return (this.ID != -1);
        }

        private bool _UpdateDepartment()
        {
            return DepartmentsDataAccess.UpdateDepartment(ID, Name);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDepartment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateDepartment();

            }

            return false;
        }

        public static bool DeleteDepartment(int ID)
        {
            return DepartmentsDataAccess.DeleteDepartment(ID);
        }

        public static bool isDepartmentExist(int ID)
        {
            return DepartmentsDataAccess.IsDepartmentExistByID(ID);
        }

        public static DataTable GetAllDepartments()
        {
            return DepartmentsDataAccess.GetAllDepartments();
        }



    }
}
