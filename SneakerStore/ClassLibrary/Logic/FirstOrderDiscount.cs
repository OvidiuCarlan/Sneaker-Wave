using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Logic
{
    public class FirstOrderDiscount : IDiscount
    {
        private readonly IOrderDataHandler orderDataHandler;
        public FirstOrderDiscount(IOrderDataHandler orderDb)
        {
            orderDataHandler = orderDb;
        }
       
        public double CalculateDiscount(double price)
        {
            int discount = 0;
            //hard coded discount percentage for first order
            int percentage = 15;
            price = price - price / 100 * percentage;

            return price;
        }

        public bool IsApplicable(double price, int userId)
        {
            if(userId == 0)
            {
                return false;
            }
            List<OrderDTO> orders = orderDataHandler.GetAllOrdersForUser(userId);
            if (orders.Count() == 0)
            {
                return true;
            }
            return false;
        }
    }
}
