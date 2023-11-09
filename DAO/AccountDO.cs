using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
