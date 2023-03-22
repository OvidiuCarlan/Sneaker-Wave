using DAL;
using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ProductManager
    {
        ProductDataHandler productDataHandler = new ProductDataHandler();

        public void AddProduct(Product product)
        {          
            productDataHandler.AddProductToDataBase(product.ProductToProductDTO());
        }
        public void RemoveProduct(int id)
        {
            productDataHandler.DeleteProduct(id);
        }
        public void EditProduct(Product product)
        {
            productDataHandler.EditProduct(product.ProductToProductDTO());
        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            foreach(ProductDTO productDTO in productDataHandler.GetAllProducts())
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
