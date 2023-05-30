using Logic.Interfaces;
using System.Data.SqlClient;

namespace DAL.DBs
{
    public class BonusCardDataHandler : IBonusCardDataHandler
    {
        public void AddPointsToCard(int userId, int points)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "UPDATE [BonusCards] SET Points = @points WHERE(Customer_Id = @customerId)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("customerId", userId);
                cmd.Parameters.AddWithValue("points", points);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public bool HasBonusCard(int userId)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT COUNT(*) FROM [BonusCards] WHERE Customer_Id = @customerId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@customerId", userId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        public bool CreateCard(int userId, int points)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [BonusCards] (Customer_Id, Points) VALUES(@customerId, @points)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("customerId", userId);
                cmd.Parameters.AddWithValue("points", points);
                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected == 1;
            }
        }

        public int GetCardPoints(int userId)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT Points FROM [BonusCards] WHERE Customer_Id = @customerId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("customerId", userId);
                conn.Open();

                int points = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    points = reader.GetInt32(0);
                }
                return points;
            }
        }
    }
}
