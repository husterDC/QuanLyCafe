using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class BillInfor
    {
        public BillInfor(int id, int billId, int foodId, int count)
        {
            this.Id = id;
            this.BillId = billId;
            this.FoodId = foodId;
            this.Count = count;
        }

        public BillInfor(DataRow row)
        {
            this.Id = (int)row["id"];
            this.BillId = (int)row["idBill"];
            this.FoodId = (int)row["idFood"];
            this.Count = (int)row["count"];
        }

        private int id;
        private int billId;
        private int foodId;
        private int count;

        public int Id { get => id; set => id = value; }
        public int BillId { get => billId; set => billId = value; }
        public int FoodId { get => foodId; set => foodId = value; }
        public int Count { get => count; set => count = value; }
    }
}
