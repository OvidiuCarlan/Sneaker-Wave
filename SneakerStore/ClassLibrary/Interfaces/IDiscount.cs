using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDiscount
    {
        public bool IsApplicable(double price, int userId);
        public double CalculateDiscount(double price);
    }
}
