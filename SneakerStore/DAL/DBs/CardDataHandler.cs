using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBs
{
    public class CardDataHandler : ICardDataHandler
    {
        public Card GetCard(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveCard(Card card)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [Cards](Name, Number, SecurityNumber, ExpirationDate) VALUES (@name, @number, @securityNumber, @expirationDate);" +
                             "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", card.Name);
                cmd.Parameters.AddWithValue("@number", card.Number);
                cmd.Parameters.AddWithValue("@securityNumber", card.SecurityNumber);
                cmd.Parameters.AddWithValue("@expirationDate", card.ExpirationDate.ToString());

                conn.Open();
                int cardId = 0;
                cardId = Convert.ToInt32(cmd.ExecuteScalar());

                return cardId;
            }
        }
    }
}
