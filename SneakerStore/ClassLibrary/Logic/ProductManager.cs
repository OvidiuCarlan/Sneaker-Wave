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
        //ProductDataHandler productDataHandler = new ProductDataHandler();

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
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            foreach (ProductDTO productDTO in productDataHandler.GetAll())
            {
                products.Add(new Product(productDTO));
            }
            return products;
        }
        public void GetAllAvailableProducts()
        {

        }
    }
}
