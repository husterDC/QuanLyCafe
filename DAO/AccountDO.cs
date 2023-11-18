using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe.DAO
{
    public class AccountDO
    {
        private static AccountDO instance;
        public static AccountDO Instance 
        {
            get { if (instance == null) instance = new AccountDO(); return instance; } 
            private set { instance = value; }
        }
        private AccountDO() { }

        public bool Login(string userName, string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            //var list = hasData.ToString();
            //list.Reverse();

            
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hasPass /*list*/ });

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount (string userName, string displayName, string pass, string newPass)
        {
            byte[] temp1 = ASCIIEncoding.ASCII.GetBytes(newPass);
            byte[] hasNewData = new MD5CryptoServiceProvider().ComputeHash(temp1);

            string hasNewPass = "";

            foreach (byte item in hasNewData)
            {
                hasNewPass += item;
            }

            byte[] temp2 = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp2);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @userName , @displayName , @passWord , @newPassWord ", new object[] {userName, displayName, hasPass, hasNewPass});
            return result > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            string query = "SELECT * FROM dbo.Account WHERE userName = '" + userName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public int GetIdByUserName(string userName)
        {
            string query = "SELECT * FROM dbo.Account WHERE userName = '" + userName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int id = -1;
            foreach (DataRow item in data.Rows)
            {
                return (int)item["id"];
            }
            return id;
        }

        public List<Account> GetAccountList()
        {
            string query = "SELECT * FROM dbo.Account";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<Account> accountList = new List<Account>();
            foreach (DataRow item in data.Rows)
            {
                accountList.Add(new Account(item));
            }
            return accountList;
        }

        public DataTable LoadAccountList()
        {
            string query = "SELECT userName, displayName, Type FROM dbo.Account";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
            
        }

        public int GetAccountTypeByUserName(string userName)
        {
            string query = "SELECT Type FROM dbo.Account WHERE userName = N'" + userName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            int type = -1;
            foreach (DataRow item in data.Rows)
            {
                type = (int)item["Type"];
            
            }
            return type;
        }

        public bool InsertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.Account (userName, displayName, Type , passWord) VALUES (N'{0}' , N'{1}' , {2}, N'{3}')", userName, displayName , type , "1962026656160185351301320480154111117132155");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateAccount(string userName, string displayName, int type, int id)
        {
            string query = string.Format("UPDATE dbo.Account SET userName = N'{0}' , displayName = N'{1}' , Type = {2} WHERE id = {3}", userName, displayName, type, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAccount(string userName)
        {
            string query = string.Format("DELETE dbo.Account WHERE userName = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ResetPass(string userName)
        {
            string query = string.Format("UPDATE dbo.Account SET passWord = N'1962026656160185351301320480154111117132155' WHERE userName = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
