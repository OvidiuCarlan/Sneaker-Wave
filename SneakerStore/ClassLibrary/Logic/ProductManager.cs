using DAL.DTOs;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ProductManager
    {

        IProductDataHandler productDataHandler;
        public ProductManager(IProductDataHandler productDb)
        {
            productDataHandler = productDb;
        }
        public void AddProduct(Product product)
        {   
            ProductDTO productDTO = new ProductDTO();
            productDataHandler.Add(productDTO);
        }
        public void RemoveProduct(int id)
        {
            productDataHandler.Remove(id);
        }
        public void EditProduct(Product product)
        {
            productDataHandler.Edit(product.ProductToProductDTO());
        }
        public ProductDTO GetProductById(int id)
        {
            ProductDTO productDTO = new ProductDTO();
            Product product = new Product(productDataHandler.GetProductById(id));
            productDTO = product.ProductToProductDTO();
            return productDTO;
        }
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            foreach (ProductDTO productDTO in productDataHandler.GetAll())
            {
                products.Add(new Product(productDTO));
            }
            return products;
        }
        public List<string> GetSizesById(int id)
        {
            return productDataHandler.GetSizesById(id);
        }
    }
}
