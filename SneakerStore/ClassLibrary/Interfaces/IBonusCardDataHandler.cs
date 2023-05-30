using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IBonusCardDataHandler
    {
        public void CreateCard(int userId, int points);
        public bool CheckIfUserHasCard(int userId);
        public void AddPointsToCard(int userId, int points);
        public int GetCardPoints(int userId, int points);
    }
}
