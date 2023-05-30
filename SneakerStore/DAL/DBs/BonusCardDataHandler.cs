using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBs
{
    public class BonusCardDataHandler : IBonusCardDataHandler
    {
        public void AddPointsToCard(int userId, int points)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "";
            }
        }

        public bool CheckIfUserHasCard(int userId)
        {
            throw new NotImplementedException();
        }

        public void CreateCard(int userId, int points)
        {
            throw new NotImplementedException();
        }

        public int GetCardPoints(int userId, int points)
        {
            throw new NotImplementedException();
        }
    }
}
