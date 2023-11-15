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
    public partial class fLogin : Form
    {

        public fLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = texbUserName.Text;
            string passWord = texbPassword.Text;
            if(Login(userName, passWord))
            {
                Account loginAccount = AccountDO.Instance.GetAccountByUserName(userName);    
                fTableManager f = new fTableManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            } else
            {
                MessageBox.Show("Sai tên người dùng hoặc mật khẩu!");
            }
        }
        bool Login(string userName, string passWord)
        {
            return AccountDO.Instance.Login(userName, passWord);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnSeePassWord_Click(object sender, EventArgs e)
        {
            texbPassword.UseSystemPasswordChar = !texbPassword.UseSystemPasswordChar;
        }
    }
}
