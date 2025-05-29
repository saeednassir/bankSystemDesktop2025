using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsPermission
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PermissionID { set; get; }
        public string PermissionName { set; get; }
        public string Description { set; get; }
        public string Category { set; get; }
        public DateTime CreatedAt { set; get; }

        public clsPermission()
        {
            this.PermissionID = -1;
            this.PermissionName = "";
            this.Description = "";
            this.Category = "";
            this.CreatedAt = DateTime.Now;

            Mode = enMode.AddNew;

        }

        private clsPermission(int PermissionID, string PermissionName, string Description,
            string Category, DateTime CreatedAt)
        {
            this.PermissionID = PermissionID;
            this.PermissionName = PermissionName;
            this.Description = Description;
            this.Category = Category;
            this.CreatedAt = CreatedAt;

            Mode = enMode.Update;
        }

        public static clsPermission Find(int PermissionID)
        {
            string PermissionName = "", Description = "", Category = "";
            DateTime CreatedAt = DateTime.Now;

            bool IsFound = PermissionsDataAccess.GetPermissionByID(PermissionID,
                ref PermissionName, ref Description, ref Category, ref CreatedAt);

            if (IsFound)
                return new clsPermission(PermissionID, PermissionName,
                    Description, Category, CreatedAt);
            else
                return null;

        }

        public static clsPermission Find(string PermissionName)
        {
            int PermissionID = -1;
            string Description = "", Category = "";
            DateTime CreatedAt = DateTime.Now;

            bool IsFound = PermissionsDataAccess.GetPermissionByName(PermissionName,
                ref PermissionID, ref Description, ref Category, ref CreatedAt);

            if (IsFound)
                return new clsPermission(PermissionID, PermissionName,
                    Description, Category, CreatedAt);
            else
                return null;

        }

        private bool _AddNewPermission()
        {
            this.PermissionID = PermissionsDataAccess.AddNewPermission(PermissionName,
                Description, Category, CreatedAt);
            return (this.PermissionID != -1);
        }
        private bool _UpdatePermission()
        {
            return PermissionsDataAccess.UpdatePermission(PermissionID, PermissionName,
                Description, Category, CreatedAt);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPermission())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdatePermission();

            }

            return false;
        }

        public static bool DeletePermission(int PermissionID)
        {
            return PermissionsDataAccess.DeletePermission(PermissionID);
        }

        public static bool isPermissionExist(int PermissionID)
        {
            return PermissionsDataAccess.IsPermissionExistByID(PermissionID);
        }

        public static DataTable GetAllPermissions()
        {
            return PermissionsDataAccess.GetAllPermissions();
        }

        public static HashSet<string> GetAllPermissionNameByUserID(int UserID)
        {
            return PermissionsDataAccess.GetAllPermissionNameByUserID(UserID);
        }

    }
}
