using QuanLyCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DAO
{
    public class FoodCaterogyDAO
    {
        private static FoodCaterogyDAO instance;

        public static FoodCaterogyDAO Instance { 
            get { if (instance == null) instance = new FoodCaterogyDAO() ; return instance; }
            private set { instance = value; }   
        }

        private FoodCaterogyDAO() { }

        public List<FoodCaterogy> GetListFoodCaterogy()
        {
            List<FoodCaterogy> listCaterogy = new List<FoodCaterogy>();

            string query = "SELECT * FROM dbo.FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FoodCaterogy itemCaterogy = new FoodCaterogy(item);
                listCaterogy.Add(itemCaterogy);
            }

            return listCaterogy;
        }

        public FoodCaterogy GetCaterogyById(int id)
        {
            FoodCaterogy foodCaterogy = null;
            string query = "SELECT * FROM dbo.FoodCategory WHERE id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                foodCaterogy = new FoodCaterogy(item);
                return foodCaterogy;
            }
            return foodCaterogy;
        }

        public bool InsertCaterogy( string name)
        {
            string query = string.Format("INSERT dbo.FoodCategory (name) VALUES (N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateCaterogy(string name, int id)
        {
            string query = string.Format("UPDATE dbo.FoodCategory SET name = N'{0}'  WHERE id = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFoodCaterogy(int id)
        {         
            string query = string.Format("DELETE dbo.FoodCategory WHERE id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
