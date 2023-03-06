using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class Product
    {
        protected int Id { get; set; }
        protected double Price { get; set; }
        protected string Brand { get; set; }
        protected int Quantity { get; set; }

    }
}
