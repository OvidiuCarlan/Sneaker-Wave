using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Id { get { return id; } }
        public Customer Customer { get {  return customer; } }
        public DateTime Date { get { return date; } }
        public Address Address { get { return address; } }
        public List<ShoppingCartItem> Products { get {  return products; } }
        public Card Card { get { return card; } }
        public double Price { get { return price; } }

        public Order(Customer customer, DateTime date, Address address, List<ShoppingCartItem> products, Card card, double price)
        {
            this.id = 0;
            this.customer = customer;
            this.date = date;
            this.address = address;
            this.products = products;
            this.card = card;
            this.price = price;
        }
    }
}
