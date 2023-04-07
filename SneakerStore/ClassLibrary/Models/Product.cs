using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Product
    {
        private int id;
        private string brand;
        private string name;
        private double price;
        private string category;
        private string image;


       
        public int Id { get { return id; } }
        public string? Brand { get { return brand; } }
        public string? Name { get { return name; } }
        public double Price { get { return price; } }
        public string? Category { get { return category; } }
        public string Image { get { return image; } }


        public Product(string brand, string name, double price, string category, string image)
        {
            id = 0;
            this.brand = brand;
            this.name = name;
            this.price = price;
            this.category = category;
            this.image = image;
        }
        public Product(int id, string brand, string name, double price, string category, string image)
        {
            this.id = id;
            this.brand = brand;
            this.name = name;
            this.price = price;
            this.category = category;
            this.image = image;
        }
        public Product()
        {
            id = 0;
            brand = "";
            name = "";
            price = 0;
            category = "";
            image = "";
        }

        public ProductDTO ProductToProductDTO()
        {
            return new ProductDTO()
            {
                Id = id,
                Brand = brand,
                Name = name,
                Price = price,
                Category = category,
                Image = image
            };
        }
        public Product(ProductDTO productDTO)
        {
            id = productDTO.Id;
            brand = productDTO.Brand;
            name = productDTO.Name;
            price = productDTO.Price;
            category = productDTO.Category;
            image = productDTO.Image;
        }
    }

}
