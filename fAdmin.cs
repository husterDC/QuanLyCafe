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
        public fAdmin()
        {
            InitializeComponent();
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
            accountList.DataSource = AccountDO.Instance.GetAccountList();
            
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
            cb.DataSource = AccountDO.Instance.GetAccountList();
            cb.DisplayMember = "Type";
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
                foreach (Account item in cbAccountType.Items)
                {
                    if (item.Type == type)
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
    }
}
