using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        //public string Size { get; set; }
        public string Category { get; set; }
        //public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
