using DAL.DTOs;
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
        private string brand;
        private string name;
        private double price;
        private string size;
        private string category;
        private int quantity;
        private string image;



        public int Id { get { return id; } }
        public string? Brand { get { return brand; } }
        public string? Name { get { return name; } }
        public double Price { get { return price; } }
        public string? Size { get { return size; } }
        public string? Category { get { return category; } }
        public int Quantity { get { return quantity; } }
        public string Image { get { return image; } }


        public Product(string brand, string name, double price, string size, string category, int quantity, string image)
        {
            this.id = 0;
            this.brand = brand;
            this.name = name;
            this.price = price;
            this.size = size;
            this.category = category;
            this.quantity = quantity;
            this.image = image;
        }
        public Product(int id, string brand, string name, double price, string size, string category, int quantity, string image)
        {
            this.id = id;
            this.brand = brand;
            this.name = name;
            this.price = price;
            this.size = size;
            this.category = category;
            this.quantity = quantity;
            this.image = image;
        }
        public Product()
        {
            this.id = 0;
            this.brand = "";
            this.name = "";
            this.price = 0;
            this.size = "";
            this.category = "";
            this.quantity = 0;
            this.image = "";
        }

        public ProductDTO ProductToProductDTO()
        {
            return new ProductDTO()
            {
                Id = this.id,
                Brand = this.brand,
                Name = this.name,
                Price = this.price,
                Size = this.size,
                Category = this.category,
                Quantity = this.quantity,
                Image = this.image
            };
        }
        public Product(ProductDTO productDTO)
        {
            id = productDTO.Id;
            brand = productDTO.Brand;
            name = productDTO.Name;
            price = productDTO.Price;
            size = productDTO.Size;
            category = productDTO.Category;
            quantity = productDTO.Quantity;
            image = productDTO.Image;
        }
    }
    
}
