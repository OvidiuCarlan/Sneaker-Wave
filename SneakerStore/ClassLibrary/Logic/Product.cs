using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class Product
    {
        private int id;
        private string ? brand;
        private string ? name;
        private double price;
        private string ? size;
        private string ? category;
        private int quantity;



        public int Id { get { return id; } set { id = value; } }
        public string? Brand { get { return brand; } set { brand = value; } }
        public string? Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string? Size { get { return size; } set { size = value; } }
        public string? Category { get { return category; } set { category = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }


        public Product(string brand, string name, double price, string size, string category, int quantity)
        {
            this.brand = brand;
            this.name = name;
            this.price = price;
            this.size = size;
            this.category = category;
            this.quantity = quantity;
        }
    }
    
}
