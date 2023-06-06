using Logic.DTOs;

namespace Logic.Models
{
    public class Order
    {
        private int id;
        private Customer customer;
        private DateTime date;
        private Address address;
        private List<ShoppingCartItem> products;
        private Card card;
        private double price;
        private string status;

        public int Id { get { return id; } }
        public Customer Customer { get { return customer; } private set { customer = value; } }
        public DateTime DateTime { get { return date; } }
        public Address Address { get { return address; } }
        public List<ShoppingCartItem> Products { get { return products; } }
        public Card Card { get { return card; } }
        public double Price { get { return price; } private set { price = value; } }
        public string Status { get { return status; } }

        public Order(Customer customer, DateTime date, Address address, List<ShoppingCartItem> products, Card card, double price, string status)
        {
            this.id = 0;
            this.customer = customer;
            this.date = date;
            this.address = address;
            this.products = products;
            this.card = card;
            this.price = price;
            this.status = status;
        }
        public OrderDTO OrderToOrderDTO()
        {
            OrderDTO order = new OrderDTO();
            foreach (ShoppingCartItem item in products)
            {
                
                order.ShoppingCartItems.Add(item.ToDTO());
            }
            order.Id = id;
            order.Customer = customer.CustomerToCustomerDTO();
            order.DateTime = date;
            order.Address = address.ToDTO();
            order.Card = card.ToDTO();
            order.Price = price; 
            order.Status = status;

           return order;
        }    
        public void UpdatePrice(double newPrice)
        {
            this.Price = newPrice;
        }
        public void SetCustomer(Customer customer)
        {
            this.customer = customer;
        }
    }

}

