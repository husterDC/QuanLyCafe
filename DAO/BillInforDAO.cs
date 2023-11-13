using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    public class BillInforDAO
    {
        private static BillInforDAO instance;

        public static BillInforDAO Instance
        {
            get { if (instance == null) instance = new BillInforDAO(); return instance; }
            private set { instance = value; }
        }

        private BillInforDAO() { }

        public List<BillInfor> GetListBillInfor (int id)
        {
            List<BillInfor> listBillInfor = new List<BillInfor>();
            string query = "SELECT * FROM dbo.BillInfo WHERE idBill = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillInfor infor = new BillInfor(item);
                listBillInfor.Add(infor);
            }
            return listBillInfor;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            string query = "EXEC USP_InsertBillInfo @idTable , @idFood , @count";
            DataProvider.Instance.ExecuteQuery(query, new object[] { idBill , idFood , count });
        }
    }
}
