using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class ShoppingCartItem
    {
        public Product product { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartItem(Product product, string productSize, int productQuantity)
        {
            this.product = product;
            this.Size = productSize;
            this.Quantity = productQuantity;
        }
    }
    
}
