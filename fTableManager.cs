using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fTableManager : Form
    {
        private Account logInAccount;

        public Account LogInAccount
        {
            get { return logInAccount; }
            set { logInAccount = value; }
        }

        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.logInAccount = acc;            
            ChangeAccount(logInAccount.Type);
            LoadTable();
            LoadCaterogy();
            LoadComboxTable(cbSwitchTable);
            
        }
        #region Method

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản " + "(" + logInAccount.DisplayName + ")";
        }
        void LoadTable()
        {
            flpanelTable.Controls.Clear();           
            List<Table> tablelist = TableDAO.Instance.LoadTableList();
            foreach (Table table in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                
                btn.Click += Btn_Click;
                btn.Tag = table;
                int idTable = table.Id;
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(idTable);
                List<BillInfor> billInfor = BillInforDAO.Instance.GetListBillInfor(idBill);
                if(billInfor.Count <= 0)
                {
                    string status = "Trống";
                    
                    TableDAO.Instance.UpdateStatusTable(idTable, status);
                    
                }
                string statusTable = TableDAO.Instance.GetTableStatusByID(idTable);
                switch (statusTable) {

                    case "Trống":
                        btn.Text = table.Name + Environment.NewLine + statusTable;
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.Text = table.Name + Environment.NewLine + statusTable;
                        btn.BackColor = Color.Red;
                        break;
                }
                flpanelTable.Controls.Add(btn);
            }
        }


        void LoadComboxTable (ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        void LoadCaterogy()
        {
            List<FoodCaterogy> listCaterogy = FoodCaterogyDAO.Instance.GetListFoodCaterogy();
            
            cbCaterogy.DataSource = listCaterogy;
            cbCaterogy.DisplayMember = "Name";
        }

        void LoadFoodListByCaterogyID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCaterogyId(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";
        }

        void ShowBill(int id)
        {
           
            listwBill.Items.Clear();
            List<MenuDTO> listBillInfor = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (MenuDTO item in listBillInfor)
            {
                ListViewItem listViewItem = new ListViewItem(item.FoodName.ToString());
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Price.ToString());
                listViewItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                listwBill.Items.Add(listViewItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            textTotalPrice.Text = totalPrice.ToString("c", culture);
            
        }

        #endregion

        #region Events

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).Id;
            listwBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void fTableManager_Load(object sender, EventArgs e)
        {

        }

        

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(logInAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        private void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName +")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin(logInAccount);
            f.InsertFood += F_InsertFood;
            f.UpdateFood += F_UpdateFood;
            f.DeleteFood += F_DeleteFood;

            f.InsertCaterogy += F_InsertCaterogy;
            f.UpdateCaterogy += F_UpdateCaterogy;
            f.DeleteCaterogy += F_DeleteCaterogy;

            f.InsertTable += F_InsertTable;
            f.UpdateTable += F_UpdateTable;
            f.DeleteTable += F_DeleteTable;

            f.UpdateAccount += F_UpdateAccount1;          

            f.ShowDialog();
        }

        private void F_UpdateAccount1(object sender, fAdmin.AccountEvent e)
        {
            logInAccount.UserName = e.Acc.UserName;
            logInAccount.DisplayName = e.Acc.DisplayName;
            logInAccount.Type = e.Acc.Type;
            ChangeAccount(logInAccount.Type);
        }

        

        private void F_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void F_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void F_InsertTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void F_DeleteCaterogy(object sender, EventArgs e)
        {
            LoadCaterogy();
        }

        private void F_UpdateCaterogy(object sender, EventArgs e)
        {
            LoadCaterogy();
        }

        private void F_InsertCaterogy(object sender, EventArgs e)
        {
            LoadCaterogy();
        }

        private void F_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCaterogyID((cbCaterogy.SelectedItem as FoodCaterogy).Id);
            LoadTable();
            if (listwBill.Tag != null)
            {
                ShowBill((listwBill.Tag as Table).Id);
            }
            
        }

        private void F_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCaterogyID((cbCaterogy.SelectedItem as FoodCaterogy).Id);
            if (listwBill.Tag != null)
            {
                ShowBill((listwBill.Tag as Table).Id);
            }
            
        }

        private void F_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCaterogyID((cbCaterogy.SelectedItem as FoodCaterogy).Id);
            if (listwBill.Tag != null)
            {
                ShowBill((listwBill.Tag as Table).Id);
            }
        }

        private void cbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            FoodCaterogy selected = cb.SelectedItem as FoodCaterogy;
            id = selected.Id;
            LoadFoodListByCaterogyID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = listwBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Xin hãy chọn bàn", "Thông báo");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.Id);
            int FoodId = (cbFood.SelectedItem as Food).Id;
            int count = (int)nUDFood.Value;

            if (idBill == -1)
            {
                if (count <= 0)
                {
                    MessageBox.Show("Không thể giảm món khi món ăn chưa có trong Bill", "Thông báo");
                    return;
                }
                else
                {
                    BillDAO.Instance.InsertBill(table.Id);

                    BillInforDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), FoodId, count);
                }
            }
            else
            {
                BillInforDAO.Instance.InsertBillInfo(idBill, FoodId, count);
            }
           

                       
            LoadTable();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

            int tableId = 1;
            Table table = listwBill.Tag as Table;
            if (table != null)
            {
                tableId = table.Id;
            }
            
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(tableId);
            int discount = (int)nUDDiscount.Value;
            double totalPrice = Convert.ToDouble(textTotalPrice.Text.Split(',')[0])*1000;
            
            double finalPrice = totalPrice - (totalPrice / 100) * discount;

            List<BillInfor> billInfor = BillInforDAO.Instance.GetListBillInfor(idBill);
            if (billInfor.Count > 0)
            {
                if (idBill > -1)
                {
                    if (MessageBox.Show(string.Format("Bạn có muốn thanh toán hóa đơn cho {0} \nTổng tiền - (Tổng tiền/100)x Giảm giá : \n{1} -{1}/100*{2} = {3}", table.Name, totalPrice, discount, finalPrice), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        BillDAO.Instance.CheckOut(idBill, discount, (float)finalPrice);
                        ShowBill(table.Id);
                    }
                }

            } else
            {
                BillDAO.Instance.DeleteUncheckBillByTableId(tableId);
            }
            
            
            LoadTable();
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            
            int idt1 = (listwBill.Tag as Table).Id;

            int idt2 = (cbSwitchTable.SelectedItem as Table).Id;
            if (MessageBox.Show(string.Format("Bạn có thực sự muốn chuyển bàn {0} sang {1} không?", (listwBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(idt1, idt2);
                LoadTable();
            }
            
        }
        #endregion

        

        private void đăngXuẩtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPay_Click(this, new EventArgs());
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFood_Click(this, new EventArgs());
        }
    }
}
