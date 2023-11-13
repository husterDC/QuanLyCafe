﻿using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }

        private BillDAO() { }
        //Thành công: return BillID
        //Thất bại: -1
        public int GetUncheckBillIDByTableID(int id)
        {
            string query = "SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
            
        }

        public void InsertBill(int id)
        {
            string query = "EXEC USP_InsertBill @idTable";
            DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        public int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }

        public void CheckOut(int id, int discount)
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1, " + "discount = " + discount + " WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
