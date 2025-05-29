using BankOfPalestineSystemDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfPalestineSystemBusinessLayer
{
    public class clsGlobalBusiness
    {
        public static int GetCountRecordsrFromTable(string TableName)
        {
            return GlobalDataAccess.GetCountRecordsrFromTable(TableName);
        }


    }
}
