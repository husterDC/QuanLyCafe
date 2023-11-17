using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            private set { instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;
        private TableDAO() { }

        public void SwitchTable(int idt1, int idt2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2" , new object[] { idt1, idt2 });
        }
        public List<Table> LoadTableList()
        {
            string query = "USP_GetTableList";
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }
            return tablelist;
        }

        public string GetTableStatusByID(int id)
        {
            string query = "SELECT status FROM dbo.TableFood WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string status = "";
            foreach (DataRow item in data.Rows)
            {
                status = item["status"].ToString();

            }
            return status;
        }

    }
}
