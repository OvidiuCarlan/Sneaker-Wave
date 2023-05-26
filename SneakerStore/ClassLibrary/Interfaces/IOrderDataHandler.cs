using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IOrderDataHandler
    {
        public int SaveOrder(int customerId, int addressId, int cardId, DateTime dateTime, double price);  
        public int SaveCard(Card card);
        public bool SaveOrderItems(int orderId, List<ShoppingCartItem> items);
    }
}
