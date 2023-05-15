using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class ShoppingCartItem
    {
        private Product product;
        private string size;
        private int quantity;

        public Product Product { get { return product; } }
        public string Size { get { return size; } }
        public int Quantity { get { return quantity; } }

        public ShoppingCartItem(Product product, string productSize, int productQuantity)
        {
            this.product = product;
            this.size = productSize;
            this.quantity = productQuantity;
        }
    }
    
}
