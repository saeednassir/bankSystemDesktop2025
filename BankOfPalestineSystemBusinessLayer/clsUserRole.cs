using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsUserRole
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int UserID { set; get; }
        public clsUser UserInfo;
        public int RoleID { set; get; }
        public clsRole RoleInfo;



        public clsUserRole()
        {
            this.ID = -1;
            this.UserID = -1;
            this.RoleID = -1;

            Mode = enMode.AddNew;
        }

        private clsUserRole(int id, int userID, int roleID)
        {
            this.ID = id;
            this.UserID = userID;
            this.UserInfo = clsUser.Find(userID);
            this.RoleID = roleID;
            this.RoleInfo = clsRole.Find(roleID);

            Mode = enMode.Update;
        }

        public static clsUserRole Find(int ID)
        {
            int UserID = -1, RoleID = -1;

            bool IsFound = UserRolesDataAccess.GetUserRoleByID(ID, ref UserID,
                ref RoleID);

            if (IsFound)
                return new clsUserRole(ID, UserID, RoleID);
            else
                return null;

        }

        public static clsUserRole Find(int UserID, int RoleID)
        {
            int ID = -1;

            bool IsFound = UserRolesDataAccess.GetUserRoleByUserIDAndRoleID(UserID, RoleID,
                ref ID);

            if (IsFound)
                return new clsUserRole(ID, UserID, RoleID);
            else
                return null;

        }

        private bool _AddNewUserRole()
        {
            this.ID = UserRolesDataAccess.AddNewUserRole(UserID, RoleID);
            return (this.ID != -1);
        }
        private bool _UpdateUserRole()
        {
            return UserRolesDataAccess.UpdateUserRole(ID, UserID, RoleID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUserRole())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateUserRole();

            }

            return false;
        }

        public static bool DeleteUserRole(int ID)
        {
            return UserRolesDataAccess.DeleteUserRole(ID);
        }

        public static bool isUserRoleExist(int ID)
        {
            return UserRolesDataAccess.IsUserRoleExistByID(ID);
        }

        public static bool IsUserRoleExistByUserIDandRoleID(int UserID,int RoleID)
        {
            return UserRolesDataAccess.IsUserRoleExistByUserIDandRoleID(UserID,RoleID);
        }

        public static DataTable GetAllUserRoles()
        {
            return UserRolesDataAccess.GetAllUserRoles();
        }


    }
}
