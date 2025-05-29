using BankOfPalestineSystemBusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankOfPalestineSystemDesktopAppPresentationLayer.Global_Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static DateTime LastLogin = DateTime.Now;

        public static HashSet<string> hashSetPermissions = new HashSet<string>();
        public static void ClearSession()
        {
            CurrentUser = null;
            hashSetPermissions.Clear();
        }
        public static bool HasPermissions(string permission)
        {

            if (hashSetPermissions == null || string.IsNullOrEmpty(permission))
                return false;

            if (hashSetPermissions.Contains("الجمبع"))
                return true;

            return hashSetPermissions.Contains(permission);
        }



        public static string CreateCardNumber()
        {
            int Part = 0;
            string CardNumber = "";

            Random rnd = new Random();
           

            for (int i = 1; i <= 4; i++)
            {
                Part = rnd.Next(1000, 9999);
                CardNumber += Part.ToString();
                if(i != 4)
                    CardNumber += " ";
            }

            if (clsCard.Find(CardNumber) != null)
                CreateCardNumber();

            return CardNumber;

        }

        public static string CreateClientNumber()
        {
            int AccountNumber = 0;

            Random rnd = new Random();
            AccountNumber = rnd.Next(1000000, 9999999);

            if (clsClient.Find(AccountNumber.ToString()) != null)
                CreateClientNumber();

            return AccountNumber.ToString();

        }

        public static string CreateBrancheCode()
        {
            int RandomNumber = 0;

            Random rnd = new Random();
            RandomNumber = rnd.Next(100, 999);

            string BrancheCode = string.Format("{0:0000}", RandomNumber);

            if (clsBranche.FindByCode(BrancheCode) != null)
                CreateBrancheCode();

            return BrancheCode;

        }

        public static string CreateAccountTypeCode()
        {
            int RandomNumber = 0;

            Random rnd = new Random();
            RandomNumber = rnd.Next(1000, 9999);

            string AccountTypeCode = string.Format("{0:0000}", RandomNumber);

            if (clsAccountType.isAccountTypeExist(AccountTypeCode))
                CreateBrancheCode();

            return AccountTypeCode;

        }

        public static string CreateFullAccountNumber(string BrancheCode,
            string ClientNumber, string AccountTypeCode, string CurrencyNumber,
            string SubAccount = "000")
        {
            return $"{BrancheCode}{ClientNumber}{AccountTypeCode}{CurrencyNumber}{SubAccount}";
        }

        public static string Create_IBAN(string AccountNumber)
        {

            Random rnd = new Random();

            string CHKNumber = string.Format("{0:00}", rnd.Next(1, 99));

            return $"PS{CHKNumber}PALS{AccountNumber}";

        }

        public static string GetSubAccount(int ClientID, int AccountTypeID, int CurrencyID)
        {
            string SubAccount = "000";
            int Count = clsAccount.HowCountSubAccountForClient(ClientID, AccountTypeID, CurrencyID);

            if (Count == 0)
                SubAccount = "000";
            else
                SubAccount = string.Format("{0:000}", Count);

            return SubAccount;
        }

        public static string CreateDefaultNicName(string AccountTypeName, string CodeCurrency, int SubAccount = 0)
        {
            string DefaultNicName = $"حساب {AccountTypeName}-{CodeCurrency}";

            if (SubAccount != 0)
                DefaultNicName += $" {SubAccount + 1}";

            return DefaultNicName;
        }

      
        public static string CreateCvvNumberCard()
        {
            int CvvNumber = 0;

            Random rnd = new Random();
            CvvNumber = rnd.Next(100, 999);

            return CvvNumber.ToString();
        }
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";

                //incase the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "يناير";
                case 2:
                    return "فبراير";
                case 3:
                    return "مارس";
                case 4:
                    return "إبريل";
                case 5:
                    return "مايو";
                case 6:
                    return "يونيو";
                case 7:
                    return "يوليو";
                case 8:
                    return "أغسطس";
                case 9:
                    return "سبتمبر";
                case 10:
                    return "أكتوبر";
                case 11:
                    return "نوفمبر";
                case 12:
                    return "ديسمبر";
                default:
                    return "غير معروف";
            }
        }

        public static string FomatNumber(decimal  number)
        {
            if (number >= 10000 && number < 1000000)
                return $"{Math.Round(number / 1000, 2) }K";
            else if (number >= 1000000 && number < 1000000000)
                return $"{Math.Round(number / 1000000, 2)}M";
            else
                return number.ToString();
        }
    }
}
