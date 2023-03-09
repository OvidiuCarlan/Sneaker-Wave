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
        public void RemoveProduct()
        {

        }
        public void EditProduct()
        {

        }
        public void GetAllProducts()
        {

        }
        public void GetAllAvailableProducts()
        {

        }
    }
}
