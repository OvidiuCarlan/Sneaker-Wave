using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class NoDiscount : IDiscount
    {
        public double CalculateDiscount(double price)
        {
            throw new NotImplementedException();
        }

        public bool IsApplicable(double price, int userId)
        {
            return false;
        }
    }
}
