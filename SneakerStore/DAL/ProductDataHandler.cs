using DAL.DTOs;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDataHandler : IProductDataHandler
    {
        public bool AddProductToDataBase(ProductDTO product)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [Products](Brand, Name, Price, Size, Category, Quantity, Image) VALUES(@brand, @name, @price, @size, @category, @quantity, @image)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("brand", product.Brand);
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("size", product.Size);
                cmd.Parameters.AddWithValue("category", product.Category);
                cmd.Parameters.AddWithValue("quantity", product.Quantity);
                cmd.Parameters.AddWithValue("image", product.Image);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected == 1;
            }
        }
        public bool DeleteProduct(int id)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "DELETE FROM [Products] WHERE(Id = @id)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected == 1;
            }
        }
        public bool EditProduct(ProductDTO product)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "UPDATE [Products] SET Brand = @brand, Name = @name, Price = @price, Size = @size, Category = @category, Quantity = @quantity, Image = @image WHERE(Id = @id)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", product.Id);
                cmd.Parameters.AddWithValue("brand", product.Brand);
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("size", product.Size);
                cmd.Parameters.AddWithValue("category", product.Category);
                cmd.Parameters.AddWithValue("quantity", product.Quantity);
                cmd.Parameters.AddWithValue("image", product.Image);


                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected == 1;
            }
        }
        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT * FROM [Products] ORDER BY Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                ProductDTO product = null;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    product = new ProductDTO();

                    product.Id = reader.GetInt32("Id");
                    product.Brand = reader.GetString("Brand");
                    product.Name = reader.GetString("Name");
                    product.Price = reader.GetDouble("Price");
                    product.Size = reader.GetString("Size");
                    product.Category = reader.GetString("Category");
                    product.Quantity = reader.GetInt32("Quantity");
                    product.Image = reader.GetString("Image");
                                        
                    products.Add(product);
                }
                return products;
            }
        }
    }
}
