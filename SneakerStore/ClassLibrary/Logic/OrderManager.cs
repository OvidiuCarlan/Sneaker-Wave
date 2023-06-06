using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Logic
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDataHandler orderDataHandler;
        private readonly IAddressDataHandler addressDataHandler;
        private readonly ICardDataHandler cardDataHandler;
        private readonly IUserDataHandler userDataHandler;
        private readonly IBonusCardManager bonusCardManager;
        List<IDiscount> discounts = new List<IDiscount>();
        public OrderManager(IOrderDataHandler orderDb, IAddressDataHandler addressDb, ICardDataHandler cardDb, IUserDataHandler userDb, IBonusCardManager _bonusCardManager)
        {
            orderDataHandler = orderDb;
            addressDataHandler = addressDb;
            cardDataHandler = cardDb;
            userDataHandler = userDb;
            bonusCardManager = _bonusCardManager;

            IDiscount noDiscount = new NoDiscount();
            IDiscount firstOrderDiscount = new FirstOrderDiscount(orderDataHandler);
            IDiscount percentageDiscount = new PercentageDiscount();

            discounts.Add(noDiscount);
            discounts.Add(firstOrderDiscount);
            discounts.Add(percentageDiscount);
        }
        
        public void AddAccountOrder(Order order, double discountedPrice)
        {
            order.UpdatePrice(discountedPrice);
            int addressId = addressDataHandler.AddAddress(order.Address);
            int cardId = cardDataHandler.SaveCard(order.Card);
            int orderId = orderDataHandler.SaveOrder(order.Customer.Id, addressId, cardId, order.DateTime, order.Price, order.Status);

            if(addressId == 0 || cardId == 0 || orderId == 0 || orderDataHandler.SaveOrderItems(orderId, order.Products) == false)
            {
                throw new Exception("There was an error. Please try again.");
            }

           
        }
        public double CheckForDiscounts(double price, int userId)
        {
            foreach (IDiscount discount in discounts)
            {
                if (discount.IsApplicable(price, userId))
                {
                    price = discount.CalculateDiscount(price);
                    return price;
                }
            }
            return price;
        }
        public void AddNoAccountOrder(Order order, double discountedPrice)
        {
            order.UpdatePrice(discountedPrice);
            int customerId = userDataHandler.AddNoAccountCustomer(order.Customer);
            int addressId = addressDataHandler.AddAddress(order.Address);
            int cardId = cardDataHandler.SaveCard(order.Card);
            int orderId = orderDataHandler.SaveOrder(customerId, addressId, cardId, order.DateTime, order.Price, order.Status);

            if (customerId == 0 || addressId == 0 || cardId == 0 || orderId == 0 || orderDataHandler.SaveOrderItems(orderId, order.Products) == false)
            {
                throw new Exception("There was an error. Please try again.");
            }
        }

        public List<OrderDTO> GetAllOrdersForUser(int userId)
        {
            List<OrderDTO> orders = orderDataHandler.GetAllOrdersForUser(userId);
            return orders;
        }
    }
}
