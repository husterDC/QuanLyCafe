using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount (string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @userName , @displayName , @passWord , @newPassWord ", new object[] {userName, displayName, pass, newPass});
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
            string query = string.Format("INSERT dbo.Account (userName, displayName, Type) VALUES (N'{0}' , N'{1}' , {2})", userName, displayName , type);
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
    }
}
