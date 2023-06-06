using Logic.DTOs;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IOrderManager
    {
        public void AddAccountOrder(Order order, double discountedPrice);
        public void AddNoAccountOrder(Order order, double discountedPrice);
        public List<OrderDTO> GetAllOrdersForUser(int userId);
        public double CheckForDiscounts(double price, int userId);
    }
}
