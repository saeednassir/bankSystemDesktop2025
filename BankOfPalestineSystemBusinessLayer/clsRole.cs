using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsRole
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int RoleID { set; get; }
        public string RoleName { set; get; }
        public string Description { set; get; }

        public clsRole()
        {
            this.RoleID = -1;
            this.RoleName = "";
            this.Description = "";

            Mode = enMode.AddNew;
        }

        private clsRole(int RoleID, string RoleName, string Description)
        {
            this.RoleID = RoleID;
            this.RoleName = RoleName;
            this.Description = Description;

            Mode = enMode.Update;
        }

        public static clsRole Find(int RoleID)
        {
            string RoleName = "", Description = "";

            bool IsFound = RolesDataAccess.GetRoleByID(RoleID, ref RoleName,
                ref Description);

            if (IsFound)
                return new clsRole(RoleID, RoleName, Description);
            else
                return null;

        }

        public static clsRole Find(string RoleName)
        {
            int RoleID = -1;
            string Description = "";

            bool IsFound = RolesDataAccess.GetRoleByName(RoleName, ref RoleID,
                ref Description);

            if (IsFound)
                return new clsRole(RoleID, RoleName, Description);
            else
                return null;

        }

        private bool _AddNewRole()
        {
            this.RoleID = RolesDataAccess.AddNewRole(RoleName, Description);
            return (this.RoleID != -1);
        }
        private bool _UpdateRole()
        {
            return RolesDataAccess.UpdateRole(RoleID, RoleName, Description);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRole())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateRole();

            }

            return false;
        }

        public static bool DeleteRole(int RoleID)
        {
            return RolesDataAccess.DeleteRole(RoleID);
        }

        public static bool isRoleExist(int RoleID)
        {
            return RolesDataAccess.IsRoleExistByID(RoleID);
        }
        public static bool isRoleExist(string RoleName)
        {
            return RolesDataAccess.IsRoleExistByName(RoleName);
        }

        public static DataTable GetAllRoles()
        {
            return RolesDataAccess.GetAllRoles();
        }



    }
}
