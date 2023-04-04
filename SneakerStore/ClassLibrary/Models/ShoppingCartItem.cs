using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartItem(int productId, string productName, string productSize, float productPrice, int productQuantity)
        {
            this.ProductId = productId;
            this.Name = productName;
            this.Size = productSize;
            this.Price = productPrice;
            this.Quantity = productQuantity;
        }
    }
    
}
