using DAL.DTOs;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IProductManager
    {
        public void AddProduct(Product product);
        public void RemoveProduct(int id);
        public void EditProduct(Product product);
        public ProductDTO GetProductById(int id);
        public List<Product> GetAll();
        public List<string> GetSizesById(int id);
    }
}
