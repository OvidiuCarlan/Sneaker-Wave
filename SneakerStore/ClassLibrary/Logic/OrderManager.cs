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
        IUserDataHandler userDataHandler;
        public OrderManager(IOrderDataHandler orderDb, IAddressDataHandler addressDb, ICardDataHandler cardDb, IUserDataHandler userDb)
        {
            orderDataHandler = orderDb;
            addressDataHandler = addressDb;
            cardDataHandler = cardDb;
            userDataHandler = userDb;
        }
        
        public void AddAccountOrder(Order order)
        {            
            int addressId = addressDataHandler.AddAddress(order.Address);
            int cardId = cardDataHandler.SaveCard(order.Card);
            int orderId = orderDataHandler.SaveOrder(order.Customer.Id, addressId, cardId, order.Date, order.Price, order.Status);

            if(addressId == 0 || cardId == 0 || orderId == 0 || orderDataHandler.SaveOrderItems(orderId, order.Products) == false)
            {
                throw new Exception("There was an error. Please try again.");
            }
        }

        public void AddNoAccountOrder(Order order)
        {
            int customerId = userDataHandler.AddNoAccountCustomer(order.Customer);
            int addressId = addressDataHandler.AddAddress(order.Address);
            int cardId = cardDataHandler.SaveCard(order.Card);
            int orderId = orderDataHandler.SaveOrder(customerId, addressId, cardId, order.Date, order.Price, order.Status);

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
