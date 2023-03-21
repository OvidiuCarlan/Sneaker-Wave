using Logic.Persistance;
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
            productDataHandler.AddProductToDataBase(product);
        }
        public void RemoveProduct(int id)
        {
            productDataHandler.DeleteProduct(id);
        }
        public void EditProduct(Product product)
        {
            productDataHandler.EditProduct(product);
        }
        public List<Product> GetAllProducts()
        {
            return productDataHandler.GetAllProducts();
        }
        public void GetAllAvailableProducts()
        {

        }
    }
}
