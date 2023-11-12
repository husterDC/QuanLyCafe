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
    }
}
