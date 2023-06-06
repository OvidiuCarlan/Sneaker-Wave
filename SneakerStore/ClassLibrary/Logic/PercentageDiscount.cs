using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class PercentageDiscount : IDiscount
    {
        int discountPercentage = 20;
        //discountPercentage = get discount from db
             

        public bool IsApplicable(double price, int userId)
        {
            if (price > 100)
            {
                return true;
            }
            return false;
        }
        public double CalculateDiscount(double price)
        {
            return price - price / 100 * discountPercentage;
        }
    }
}
