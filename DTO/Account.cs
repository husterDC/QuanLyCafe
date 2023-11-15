using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Account
    {
        public Account(string userName, string displayName, string password, int type)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Password = password;
            this.Type = type;

        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.password = row["passWord"].ToString();
            this.Type = (int)row["Type"];
            this.DisplayName = row["displayName"].ToString();
            
        }

        private string displayName;
        private string userName;
        private string password;
        private int type;

        public string DisplayName { get => displayName; set => displayName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }
    }
}
