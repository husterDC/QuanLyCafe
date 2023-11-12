using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCaterogy();
            
        }
        #region Method
        void LoadTable()
        {
            List<Table> tablelist = TableDAO.Instance.LoadTableList();
            foreach (Table table in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += Btn_Click;
                btn.Tag = table;

                switch (table.Status) {

                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }

                flpanelTable.Controls.Add(btn);

            }
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
            ShowBill(tableID);
        }
        private void fTableManager_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
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
        #endregion


    }
}
