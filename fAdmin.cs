using QuanLyCafe.DAO;
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
            LoadAccountList();
            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
            LoadFoodList();
            CultureInfo culture = new CultureInfo("vi-VN");
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            string customFormat = "dd 'tháng' MM yyyy";
            dateTimePickerFromDate.CustomFormat = customFormat;
            dateTimePickerToDate.CustomFormat = customFormat;
        } 
        void LoadFoodList()
        {
            dataGridViewFood.DataSource = FoodDAO.Instance.GetListFood();
        }

        void LoadAccountList()
        {

            
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

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {
            LoadFoodList();
        }
    }
}
