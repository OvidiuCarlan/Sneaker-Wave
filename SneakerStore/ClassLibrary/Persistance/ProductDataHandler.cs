using Logic.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Persistance
{
    public class ProductDataHandler
    {
        public bool AddProductToDataBase(Product product)
        {
            using(SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [Products](Brand, Name, Price, Size, Category, Quantity) VALUES(@brand, @name, @price, @size, @category, @quantity)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("brand", product.Brand);
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("size", product.Size);
                cmd.Parameters.AddWithValue("category", product.Category);
                cmd.Parameters.AddWithValue("quantity", product.Quantity);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected == 1;
            }
        }
    }
}
