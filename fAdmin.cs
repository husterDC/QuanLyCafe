using QuanLyCafe.DAO;
using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();

        private Account logInAccount;

        public Account LogInAccount
        {
            get { return logInAccount; }
            set { logInAccount = value; }
        }
        public fAdmin(Account acc)
        {
            InitializeComponent();
            this.logInAccount = acc;
            Load();
            LoadAccountList();
            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
        }

        void Load()
        {
            dataGridViewFood.DataSource = foodList;
            dataGridViewAdmin.DataSource = accountList;
            dataGridViewCaterogy.DataSource = categoryList;
            dataGridViewFoodTable.DataSource = tableList;
            LoadAccountList();
            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
            LoadFoodList();
            LoadCategoryList();
            LoadTableList();
            AddFoodBinding();
            AddAccountBinding();
            AddCaterogyBinding();
            AddTableBinding();
            LoadCaterogyIntoCombobox(cbCaterogyFood);           
            LoadAccountTypeIntoCombobox(cbAccountType);
            LoadTableStatusIntoCombobox(cbFoodTable);
            CultureInfo culture = new CultureInfo("vi-VN");
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            string customFormat = "dd 'tháng' MM yyyy";
            dateTimePickerFromDate.CustomFormat = customFormat;
            dateTimePickerToDate.CustomFormat = customFormat;
        } 
        void LoadFoodList()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }
        void LoadAccountList()
        {
            accountList.DataSource = AccountDO.Instance.LoadAccountList();
            
        }

        void LoadCategoryList()
        {
            categoryList.DataSource = FoodCaterogyDAO.Instance.GetListFoodCaterogy();
        }

        void LoadTableList()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
        }


        void LoadDateTimePickerBill ()
        {
         
            DateTime today = DateTime.Now;
            dateTimePickerFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePickerToDate.Value = dateTimePickerFromDate.Value.AddMonths(1).AddDays(-1);
           
        }

        void LoadListBillByDate (DateTime checkIn, DateTime checkOut) 
        {
            dataGridViewBill.DataSource = BillDAO.Instance.GetListBillByDate(checkIn, checkOut);
        }


        void AddFoodBinding()
        {
            textbFood.DataBindings.Add(new Binding("Text", dataGridViewFood.DataSource, "name", true, DataSourceUpdateMode.Never));
            textbIDFood.DataBindings.Add(new Binding("Text", dataGridViewFood.DataSource, "id", true, DataSourceUpdateMode.Never));
            nUDFoodPrice.DataBindings.Add(new Binding("Value", dataGridViewFood.DataSource, "price", true, DataSourceUpdateMode.Never));
            
        }


        void AddAccountBinding()
        {
            textbUserName.DataBindings.Add(new Binding("Text", dataGridViewAdmin.DataSource, "userName", true, DataSourceUpdateMode.Never));
            textbDisplayName.DataBindings.Add(new Binding("Text", dataGridViewAdmin.DataSource, "displayName", true, DataSourceUpdateMode.Never));

        }

        void AddCaterogyBinding()
        {
            textbIDCaterogy.DataBindings.Add(new Binding("Text", dataGridViewCaterogy.DataSource, "Id", true, DataSourceUpdateMode.Never));

            textbCaterogy.DataBindings.Add(new Binding("Text", dataGridViewCaterogy.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        void AddTableBinding()
        {
            textbIDFoodTable.DataBindings.Add(new Binding("Text", dataGridViewFoodTable.DataSource, "Id", true, DataSourceUpdateMode.Never));

            textbFoodTable.DataBindings.Add(new Binding("Text", dataGridViewFoodTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }



        void LoadCaterogyIntoCombobox(ComboBox cb)
        {
            cb.DataSource = FoodCaterogyDAO.Instance.GetListFoodCaterogy();
            cb.DisplayMember = "Name";
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void LoadAccountTypeIntoCombobox(ComboBox cb)
        {
            List<int> listType = new List<int>() { 0, 1 } ;
            cb.DataSource = listType;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void LoadTableStatusIntoCombobox(ComboBox cb)
        {
            List<string> listStatus = new List<string>() { "Trống" , "Có người"};
            cb.DataSource = listStatus;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadFoodList();
        }

        private void textbIDFood_TextChanged(object sender, EventArgs e)
        {
            
            if (dataGridViewFood.SelectedCells.Count > 0 && dataGridViewFood.SelectedCells[0].OwningRow.Cells["caterogyId"].Value != null)
            {
                int id = (int)dataGridViewFood.SelectedCells[0].OwningRow.Cells["caterogyId"].Value;
                FoodCaterogy foodCaterogy = FoodCaterogyDAO.Instance.GetCaterogyById(id);
                cbCaterogyFood.SelectedItem = foodCaterogy;
                int index = -1;
                int i = 0;
                foreach (FoodCaterogy item in cbCaterogyFood.Items)
                {
                    if (item.Id == foodCaterogy.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbCaterogyFood.SelectedIndex = index;
            }
                
            
            
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = textbFood.Text;
            int caterogyId = (cbCaterogyFood.SelectedItem as FoodCaterogy).Id;
            float price = (float)nUDFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, caterogyId, price))
            {
                LoadFoodList();
                MessageBox.Show("Thêm món thành công");
                if (inserFood != null)
                {
                    inserFood(this, new EventArgs());
                }
            } else
            {
                MessageBox.Show("Có lỗi sảy ra khi thêm thức ăn");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = textbFood.Text;
            int caterogyId = (cbCaterogyFood.SelectedItem as FoodCaterogy).Id;
            float price = (float)nUDFoodPrice.Value;
            int idFood = Convert.ToInt32(textbIDFood.Text);

            if (FoodDAO.Instance.UpdateFood(idFood, name, caterogyId, price))
            {
                LoadFoodList();
                MessageBox.Show("Sửa món ăn thành công");
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra khi sửa món ăn");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int idFood = Convert.ToInt32(textbIDFood.Text);

            if (FoodDAO.Instance.DeleteFood(idFood))
            {
                LoadFoodList();
                MessageBox.Show("Xóa món ăn thành công");
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());  
                }
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra khi xóa món ăn");
            }
        }

        private event EventHandler inserFood;
        public event EventHandler InsertFood
        {
            add { inserFood += value; }
            remove { inserFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private void btnFindFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(textbFindFood.Text);
            
        }

        private void btnViewAdmin_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        private void textbUserName_TextChanged(object sender, EventArgs e)
        {
            if (AccountDO.Instance.GetAccountTypeByUserName(textbUserName.Text) >= 0)
            {
                int type = AccountDO.Instance.GetAccountTypeByUserName(textbUserName.Text);
                int index = -1;
                int i = 0;
                foreach (int item in cbAccountType.Items)
                {
                    if (item == type)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbAccountType.SelectedIndex = index;
            }

        }

        private void btnViewCaterogy_Click(object sender, EventArgs e)
        {
            LoadCategoryList();
        }

        private void btnAddCaterogy_Click(object sender, EventArgs e)
        {
            
            string name = textbCaterogy.Text;           

            if (FoodCaterogyDAO.Instance.InsertCaterogy( name))
            {
                LoadCategoryList();
                MessageBox.Show("Thêm danh mục thành công");
                if (inserCaterogy != null)
                {
                    inserCaterogy(this, new EventArgs());
                }

            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra khi thêm danh mục ăn");
            }
        }

        private void btnEditCaterogy_Click(object sender, EventArgs e)
        {
            string name = textbCaterogy.Text;
            int id = Convert.ToInt32(textbIDCaterogy.Text);

            if (FoodCaterogyDAO.Instance.UpdateCaterogy(name , id))
            {
                LoadCategoryList();
                if (updateCaterogy != null)
                {
                    updateCaterogy(this, new EventArgs());
                }
                MessageBox.Show("Sửa danh mục thành công");

            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra khi sửa danh mục ăn");
            }
        }

        private void btnDeleteCaterogy_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textbIDCaterogy.Text);

            if (FoodCaterogyDAO.Instance.DeleteFoodCaterogy(id))
            {
                LoadCategoryList();
                if (deleteCaterogy != null)
                {
                    deleteCaterogy(this, new EventArgs());
                }
                MessageBox.Show("Xóa danh mục thành công");

            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra khi xóa danh mục ăn");
            }
        }

        private event EventHandler inserCaterogy;
        public event EventHandler InsertCaterogy
        {
            add { inserCaterogy += value; }
            remove { inserCaterogy -= value; }
        }

        private event EventHandler updateCaterogy;
        public event EventHandler UpdateCaterogy
        {
            add { updateCaterogy += value; }
            remove { updateCaterogy -= value; }
        }

        private event EventHandler deleteCaterogy;
        public event EventHandler DeleteCaterogy
        {
            add { deleteCaterogy += value; }
            remove { deleteCaterogy -= value; }
        }

        private void textbIDFoodTable_TextChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textbIDFoodTable.Text);
            if (TableDAO.Instance.GetTableStatusByID(id) != "")
            {
                string status = TableDAO.Instance.GetTableStatusByID(id);
                
                int index = -1;
                int i = 0;
                foreach (string item in cbFoodTable.Items)
                {              
                    if (item == status)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbFoodTable.SelectedIndex = index;
            }
        }

        private void btnViewFoodTable_Click(object sender, EventArgs e)
        {
            LoadTableList();
        }

        private void btnAddFoodTable_Click(object sender, EventArgs e)
        {
            string name = textbFoodTable.Text;
            if (TableDAO.Instance.InsertTable(name))
            {
                LoadTableList();
                if (insertTable != null)
                {
                    insertTable(this, new EventArgs());
                }
                MessageBox.Show("Thêm bàn thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra khi thêm bàn");
            }
        }

        private void btnEditFoodTable_Click(object sender, EventArgs e)
        {
            string name = textbFoodTable.Text;
            int id = Convert.ToInt32(textbIDFoodTable.Text);
            if (TableDAO.Instance.UpdateTable(name, id))
            {
                LoadTableList();
                if (updateTable != null)
                {
                    updateTable(this, new EventArgs());
                }
                MessageBox.Show("Sửa thông tin bàn thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra khi sửa thông tin bàn");
            }
        }

        private void btnDeleteFoodTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textbIDFoodTable.Text);
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(id);
            if (idBill >= 0) 
            {
                BillInforDAO.Instance.DeleteBillInfoByBillId(idBill);
            }           
            BillDAO.Instance.DeleteBillByTableId(id);
            if (TableDAO.Instance.DeleteFoodTable(id))
            {
                LoadTableList();
                if (deleteTable != null)
                {
                    deleteTable(this, new EventArgs());
                }
                MessageBox.Show("Xóa bàn thành công");

            }
            else
            {
                MessageBox.Show("Có lỗi sảy ra khi xóa bàn");
            }
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = textbUserName.Text;
            string displayName = textbDisplayName.Text;
            int type = (int)(cbAccountType.SelectedItem);
            
            if (AccountDO.Instance.InsertAccount(userName, displayName, type))
            {
                LoadAccountList();
                
                MessageBox.Show("Thêm tài khoản thành công");
            } else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm tài khoản");
            }
            
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = textbUserName.Text;
            string displayName = textbDisplayName.Text;
            bool isThisAccountUpdate = false;
            if (userName == logInAccount.UserName)
            {
                isThisAccountUpdate = true;
            }
            int type = (int)(cbAccountType.SelectedItem);

            int id = AccountDO.Instance.GetIdByUserName(userName);

            if (id > 0)
            {
                if (AccountDO.Instance.UpdateAccount(userName, displayName, type, id))
                {
                    LoadAccountList();
                    if (updateAccount != null && isThisAccountUpdate)
                    {
                        updateAccount(this, new AccountEvent(AccountDO.Instance.GetAccountByUserName(userName)));
                    }
                    MessageBox.Show("Sửa tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi sửa tài khoản");
                }
            } else
            {
                MessageBox.Show("Hãy nhập chính xác tài khoản muốn sửa");
                return;
            }

            
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = textbUserName.Text;            
            if (userName != logInAccount.UserName)
            {
                if (AccountDO.Instance.DeleteAccount(userName))
                {
                    LoadAccountList();
                    
                    MessageBox.Show("Xóa tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa tài khoản");
                }
            } else
            {
                MessageBox.Show("Bạn không thể tự xóa tài khoản của mình");
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
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
}
