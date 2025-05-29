using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsClient
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enClientType { Individual = 0, Corporate = 1 };
        public enum enStatus { Pending = 0, Active = 1, Inactive = 2, Blocked = 3 };
        public int ID { set; get; }
        public int PersonID { set; get; }
        public clsPerson PersonInfo;
        public string ClientNumber { set; get; }
        public string Profession { set; get; }
        public string CompanyName { set; get; }
        public enClientType ClientType { set; get; }
        public enStatus Status { set; get; }
        public DateTime CreatedAt { set; get; }
        public DateTime UpdatedAt { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUser CreatedByUserInfo;

        public int UpdatedByUserID { set; get; }
        public clsUser UpdatedByUserInfo;



        public clsClient()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.ClientNumber = "";
            this.Profession = "";
            this.CompanyName = "";
            this.ClientType = enClientType.Individual;
            this.Status = enStatus.Pending;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = new DateTime(1900, 01, 01);
            this.CreatedByUserID = -1;
            this.UpdatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsClient(int iD, int personID, string ClientNumber,
            string profession, string companyName, enClientType clientType,
            enStatus status, DateTime createdAt, DateTime updatedAt,
            int createdByUserID, int updatedByUserID)
        {
            this.ID = iD;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.Find(personID);
            this.ClientNumber = ClientNumber;
            this.Profession = profession;
            this.CompanyName = companyName;
            this.ClientType = clientType;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.CreatedByUserID = createdByUserID;
            this.UpdatedByUserID = updatedByUserID;

            Mode = enMode.Update;
        }

        public static clsClient Find(int ID)
        {
            int PersonID = -1, CreatedByUserID = -1, UpdatedByUserID = -1;
            string ClientNumber = "", Profession = "", CompanyName = "";
            DateTime CreatedAt = DateTime.Now, UpdatedAt = new DateTime(1900, 01, 01);

            byte Status = (byte)enStatus.Pending, ClientType = (byte)enClientType.Individual;

            bool IsFound = ClientsDataAccess.GetClientByID(ID, ref PersonID,
                ref ClientNumber, ref Profession, ref CompanyName,
                ref ClientType, ref Status, ref CreatedAt, ref UpdatedAt,
                ref CreatedByUserID, ref UpdatedByUserID);

            if (IsFound)
                return new clsClient(ID, PersonID, ClientNumber, Profession,
                    CompanyName, (enClientType)ClientType, (enStatus)Status, CreatedAt, UpdatedAt, CreatedByUserID,
                    UpdatedByUserID);
            else
                return null;

        }

        public static clsClient Find(string ClientNumber)
        {
            int ID = -1, PersonID = -1, CreatedByUserID = -1, UpdatedByUserID = -1;
            string Profession = "", CompanyName = "";
            DateTime CreatedAt = DateTime.Now, UpdatedAt = new DateTime(1900, 01, 01);

            byte Status = (byte)enStatus.Pending, ClientType = (byte)enClientType.Individual;

            bool IsFound = ClientsDataAccess.GetClientByClientNumber(ClientNumber, ref ID, ref PersonID,
                ref Profession, ref CompanyName,
                ref ClientType, ref Status, ref CreatedAt, ref UpdatedAt,
                ref CreatedByUserID, ref UpdatedByUserID);

            if (IsFound)
                return new clsClient(ID, PersonID, ClientNumber, Profession,
                    CompanyName, (enClientType)ClientType, (enStatus)Status, CreatedAt, UpdatedAt, CreatedByUserID,
                    UpdatedByUserID);
            else
                return null;

        }

        public static clsClient FindByPersonID(int PersonID)
        {
            int ID = -1, CreatedByUserID = -1, UpdatedByUserID = -1;
            string ClientNumber = "", Profession = "", CompanyName = "";
            DateTime CreatedAt = DateTime.Now, UpdatedAt = new DateTime(1900, 01, 01);

            byte Status = (byte)enStatus.Pending, ClientType = (byte)enClientType.Individual;

            bool IsFound = ClientsDataAccess.GetClientByPersonID(PersonID, ref ID,
                ref ClientNumber, ref Profession, ref CompanyName,
                ref ClientType, ref Status, ref CreatedAt, ref UpdatedAt,
                ref CreatedByUserID, ref UpdatedByUserID);

            if (IsFound)
                return new clsClient(ID, PersonID, ClientNumber, Profession,
                    CompanyName, (enClientType)ClientType, (enStatus)Status, CreatedAt, UpdatedAt, CreatedByUserID,
                    UpdatedByUserID);
            else
                return null;

        }

        private bool _AddNewClient()
        {
            this.ID = ClientsDataAccess.AddNewClient(PersonID, ClientNumber,
                Profession, CompanyName, (byte)ClientType, (byte)Status, CreatedAt, UpdatedAt,
                CreatedByUserID, UpdatedByUserID);
            return (this.ID != -1);
        }

        private bool _UpdateClient()
        {
            return ClientsDataAccess.UpdateClient(ID, PersonID, ClientNumber,
                Profession, CompanyName, (byte)ClientType, (byte)Status, CreatedAt, UpdatedAt,
                CreatedByUserID, UpdatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateClient();

            }

            return false;
        }

        public static bool DeleteClient(int ID)
        {
            return ClientsDataAccess.DeleteClient(ID);
        }

        public static bool isClientExistByID(int ID)
        {
            return ClientsDataAccess.IsClientExistByID(ID);
        }
        public static bool isClientExistByPersonID(int PersonID)
        {
            return ClientsDataAccess.IsClientExistByPersonID(PersonID);
        }

        public static DataTable GetAllClients()
        {
            return ClientsDataAccess.GetAllClients();
        }


        public static decimal GetCountClientsByStatus(enStatus status)
        {
            return ClientsDataAccess.GetCountClientsByStatus((byte)status);
        }
    }
}

