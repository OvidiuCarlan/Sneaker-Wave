using Logic.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductDataHandler
    {
        public bool AddProductToDataBase(Product product)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
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
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT * FROM [Products] ORDER BY Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                Product product = null;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    product = new Product();

                    product.Id = reader.GetInt32("Id");
                    product.Brand = reader.GetString("Brand");
                    product.Name = reader.GetString("Name");
                    product.Price = reader.GetDouble("Price");
                    product.Size = reader.GetString("Size");
                    product.Category = reader.GetString("Category");

                    product.Quantity = reader.GetInt32("Quantity");

                    products.Add(product);
                }
                return products;
            }
        }

        public bool EditProduct(Product product)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "UPDATE [Products] SET Brand = @brand, Name = @name, Price = @price, Size = @size, Category = @category, Quantity = @quantity WHERE(Id = @id)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", product.Id);
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
        public bool DeleteProduct(int id)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = ("DELETE FROM [Products] WHERE Id = @id");
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected == 1;
            }
        }
    }
}
