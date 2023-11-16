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
        public fAdmin()
        {
            InitializeComponent();
            Load();
            LoadAccountList();
            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
        }

        void Load ()
        {
            dataGridViewFood.DataSource = foodList;
            dataGridViewAdmin.DataSource = accountList;
            LoadAccountList();
            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
            LoadFoodList();
            AddFoodBinding();
            AddAccountBinding();
            LoadCaterogyIntoCombobox(cbCaterogyFood);
            LoadAccountTypeIntoCombobox(cbAccountType);
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

        void LoadCaterogyIntoCombobox (ComboBox cb)
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
            if (textbUserName.Text != "")
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
    }
}
