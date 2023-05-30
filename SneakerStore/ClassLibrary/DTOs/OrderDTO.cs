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
        public CustomerDTO Customer { get; set; }
        public DateTime DateTime { get; set; }
        public AddressDTO Address { get; set; }
        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }
        public CardDTO Card { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }
}
