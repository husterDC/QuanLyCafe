using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class Food
    {
        public Food(int id, string name, int caterogyId, float price)
        {
            this.Id = id;
            this.Name = name;
            this.CaterogyId = caterogyId;
            this.Price = price;
        }

        public Food(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = (string)row["name"];
            this.CaterogyId = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private int id;
        private string name;
        private int caterogyId;
        private float price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int CaterogyId { get => caterogyId; set => caterogyId = value; }
        public float Price { get => price; set => price = value; }
    }
}
