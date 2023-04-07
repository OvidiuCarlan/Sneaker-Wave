using DAL.DTOs;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public class ShoppingCartItemDTO
    {      
        public ProductDTO Product { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }      
        
    }
}
