using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe.DTO
{
    public class FoodCaterogy
    {
        public FoodCaterogy(int id, string name) 
        {
            this.Id = id;
            this.Name = name;
        }

        public FoodCaterogy(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = (string)row["name"];
        }

        private int id;
        private string name;

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}
