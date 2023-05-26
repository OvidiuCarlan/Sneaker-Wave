using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateTime { get; set; }
        public Address Address { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public Card Card { get; set; }
        public double Price { get; set; }
    }
}
