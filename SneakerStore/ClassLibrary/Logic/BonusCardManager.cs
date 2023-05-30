using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class BonusCardManager : IBonusCardManager
    {
        private readonly IBonusCardDataHandler bonusCardDataHandler;
        public BonusCardManager(IBonusCardDataHandler bonusCardDb)
        {
            bonusCardDataHandler = bonusCardDb;
        }

        //return the updated price
        public double ApplyBonusPoints(double price, int userId)
        {
            throw new NotImplementedException();
        }

        public void SaveBonusPoints(double price, int userId)
        {
            int points = CalculatePoints(price);

            bool hasBonusCard = bonusCardDataHandler.HasBonusCard(userId);
            if(hasBonusCard == true)
            {
                bonusCardDataHandler.AddPointsToCard(userId, points);
            }
            else
            {
                bonusCardDataHandler.CreateCard(userId, points);
            }
        }
        public int CalculatePoints(double price)
        {
            int points = (int)(price * 0.3);
            return points;
        }
        public int GetBonusPoints(int userId)
        {
            return bonusCardDataHandler.GetCardPoints(userId);
        }
    }
}
