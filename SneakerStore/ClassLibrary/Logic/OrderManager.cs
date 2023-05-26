using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;

namespace Logic.Logic
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDataHandler orderDataHandler;
        private readonly IAddressDataHandler addressDataHandler;
        public OrderManager(IOrderDataHandler orderDb, IAddressDataHandler addressDb)
        {
            orderDataHandler = orderDb;
            addressDataHandler = addressDb;
        }
        
        public void AddAccountOrder(Order order)
        {
            int addressId = addressDataHandler.AddAddress(order.Address);
            int cardId = orderDataHandler.SaveCard(order.Card);
            int orderId = orderDataHandler.SaveOrder(order.Customer.Id, addressId, cardId, order.Date, order.Price);

            if(addressId == 0 || cardId == 0 || orderId == 0 || orderDataHandler.SaveOrderItems(orderId, order.Products) == false)
            {
                throw new Exception("There was an error. Please try again.");
            }
        }
    }
}
