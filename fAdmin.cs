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
            LoadTimeFormat();
            LoadAccountList();
            LoadDateTimePickerBill();
            LoadListBillByDate(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
        }

        void LoadTimeFormat ()
        {
           
            CultureInfo culture = new CultureInfo("vi-VN");
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            string customFormat = "dd 'tháng' MM yyyy";
            dateTimePickerFromDate.CustomFormat = customFormat;
            dateTimePickerToDate.CustomFormat = customFormat;
        } 
        void LoadFoodList()
        {
            string query = "select * from food";

            dataGridViewFood.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadAccountList()
        {

            string query = "EXEC dbo.USP_GetListAccountByUserName @userName";

            dataGridViewAdmin.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { "K9" });
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
    }
}
