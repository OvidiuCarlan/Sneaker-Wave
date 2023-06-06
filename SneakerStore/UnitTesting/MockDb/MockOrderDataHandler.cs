using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MockDb
{
    public class MockOrderDataHandler : IOrderDataHandler
    {
        public List<OrderDTO> GetAllOrdersForUser(int userId)
        {
            if(userId == 1)
            {
                return new List<OrderDTO>();
            }
            else
            {
                OrderDTO order = new OrderDTO();
                order.Status = "Open";
                List<OrderDTO> orders = new List<OrderDTO>();
                orders.Add(order);
                return orders;
            }
        }

        public int SaveOrder(int customerId, int addressId, int cardId, DateTime dateTime, double price, string status)
        {
            throw new NotImplementedException();
        }

        public bool SaveOrderItems(int orderId, List<ShoppingCartItem> items)
        {
            throw new NotImplementedException();
        }
    }
}
