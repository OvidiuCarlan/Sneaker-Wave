using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IBonusCardManager
    {
        public double ApplyBonusPoints(double price, int userId);
        public void SaveBonusPoints(double price, int userId);
        public int GetBonusPoints(int userId);
    }
}
