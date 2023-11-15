using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fAccountProfile : Form
    {
        private Account logInAccount;

        public Account LogInAccount
        {
            get { return logInAccount; }
            set { logInAccount = value; ChangeAccount(LogInAccount); }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            
            this.LogInAccount = acc;
        }



        void ChangeAccount(Account acc)
        {
            texbUserName.Text = logInAccount.UserName;
            textbDisplayName.Text = logInAccount.DisplayName;
        }
        void UpdateAccountInfo ()
        {
            string displayName = textbDisplayName.Text;
            string passWord = textbPassWord.Text;
            string newPass = textbNewPassWord.Text;
            string newPassAgain = textbNewPassWordAgain.Text;
            string userName = texbUserName.Text;

            if (!newPass.Equals(newPassAgain))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu với mật khẩu mới!");
            }
            else
            {
                if(AccountDO.Instance.UpdateAccount(userName, displayName, passWord, newPass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                    {
                        updateAccount(this, new AccountEvent(AccountDO.Instance.GetAccountByUserName(userName)));
                    }

                    textbPassWord.Clear();
                    textbNewPassWord.Clear();
                    textbNewPassWordAgain.Clear();
                    
                        
                } else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }
        private event EventHandler <AccountEvent> updateAccount;
        public event EventHandler <AccountEvent> UpdateAccount 
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }

    public class AccountEvent : EventArgs 
    {
        private Account acc;

        

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }

        public Account Acc { get => acc; set => acc = value; }
    }

}
