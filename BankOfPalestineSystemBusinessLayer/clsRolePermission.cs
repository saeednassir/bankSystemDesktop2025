using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsRolePermission
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int RoleID { set; get; }
        public clsRole RoleInfo;
        public int PermissionID { set; get; }
        public clsPermission PermissionInfo;

        public DateTime CreatedAt { set; get; }
        public int GrantedByUserID { set; get; }

        public clsRolePermission()
        {
            this.ID = -1;
            this.RoleID = -1;
            this.PermissionID = -1;
            this.CreatedAt = DateTime.Now;
            this.GrantedByUserID = -1;


            Mode = enMode.AddNew;

        }

        private clsRolePermission(int ID, int RoleID, int PermissionID,
            DateTime CreatedAt, int GrantedByUserID)
        {
            this.ID = ID;
            this.RoleID = RoleID;
            this.RoleInfo = clsRole.Find(RoleID);
            this.PermissionID = PermissionID;
            this.PermissionInfo = clsPermission.Find(PermissionID);
            this.CreatedAt = CreatedAt;
            this.GrantedByUserID = GrantedByUserID;

            Mode = enMode.Update;
        }

        public static clsRolePermission Find(int ID)
        {
            int RoleID = -1, PermissionID = -1, GrantedByUserID = -1;
            DateTime CreatedAt = DateTime.Now;

            bool IsFound = RolePermissionsDataAccess.GetRolePermissionByID(ID, ref RoleID,
                ref PermissionID, ref CreatedAt, ref GrantedByUserID);

            if (IsFound)
                return new clsRolePermission(ID, RoleID, PermissionID, CreatedAt, GrantedByUserID);
            else
                return null;

        }

        public static clsRolePermission Find(int RoleID, int PermissionID)
        {
            int ID = -1, GrantedByUserID = -1;
            DateTime CreatedAt = DateTime.Now;

            bool IsFound = RolePermissionsDataAccess.GetRolePermissionByRoleAndPermissionID(
                RoleID, PermissionID, ref ID, ref CreatedAt, ref GrantedByUserID);

            if (IsFound)
                return new clsRolePermission(ID, RoleID, PermissionID, CreatedAt, GrantedByUserID);
            else
                return null;

        }


        private bool _AddNewRolePermission()
        {
            this.ID = RolePermissionsDataAccess.AddNewRolePermission(RoleID, PermissionID,
                CreatedAt, GrantedByUserID);
            return (this.ID != -1);
        }
        private bool _UpdateRolePermission()
        {
            return RolePermissionsDataAccess.UpdateRolePermission(ID, RoleID, PermissionID,
                CreatedAt, GrantedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRolePermission())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateRolePermission();

            }

            return false;
        }


        public static bool DeleteRolePermission(int ID)
        {
            return RolePermissionsDataAccess.DeleteRolePermission(ID);
        }

        public static bool isRolePermissionExist(int ID)
        {
            return RolePermissionsDataAccess.IsRolePermissionExistByID(ID);
        }

        public static bool isRolePermissionExist(int RoleID, int PermissionID)
        {
            return RolePermissionsDataAccess.IsRolePermissionExistByRoleAndPermissionID(RoleID, PermissionID);
        }

        public static DataTable GetAllRolePermissions()
        {
            return RolePermissionsDataAccess.GetAllRolePermissions();
        }

    }
}
