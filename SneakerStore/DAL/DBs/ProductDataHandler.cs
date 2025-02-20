﻿using DAL.DTOs;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using IProductDataHandler = Logic.Interfaces.IProductDataHandler;

namespace DAL.DBs
{
    public class ProductDataHandler : IProductDataHandler
    {
        
        public bool Add(ProductDTO product)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [Products](Brand, Name, Price, Category, Image) VALUES(@brand, @name, @price, @category, @image)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("brand", product.Brand);
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("category", product.Category);
                cmd.Parameters.AddWithValue("image", product.Image);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected == 1;
            }
        }
        
        public bool Remove(int id)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "DELETE FROM [Products] WHERE(Id = @id)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected == 1;
            }
        }
        
        public bool Edit(ProductDTO product)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "UPDATE [Products] SET Brand = @brand, Name = @name, Price = @price, Size = @size, Category = @category, Quantity = @quantity, Image = @image WHERE(Id = @id)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", product.Id);
                cmd.Parameters.AddWithValue("brand", product.Brand);
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                //cmd.Parameters.AddWithValue("size", product.Size);
                cmd.Parameters.AddWithValue("category", product.Category);
                //cmd.Parameters.AddWithValue("quantity", product.Quantity);
                cmd.Parameters.AddWithValue("image", product.Image);


                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
                return rowsAffected == 1;
            }
        }
        public List<ProductDTO> GetAll()
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
                    //product.Size = reader.GetString("Size");
                    product.Category = reader.GetString("Category");
                    //product.Quantity = reader.GetInt32("Quantity");
                    product.Image = reader.GetString("Image");

                    products.Add(product);
                }
                conn.Close();
                return products;
            }
        }
        public ProductDTO GetProductById(int id)
        {
            ProductDTO dto = new ProductDTO();

            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT * FROM [Products] WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {                        
                            dto.Id = reader.GetInt32(0);
                            dto.Brand = reader.GetString(1);
                            dto.Name = reader.GetString(2);
                            dto.Price = reader.GetDouble(3);
                            dto.Category = reader.GetString(4);
                            dto.Image = reader.GetString(5);                        
                    }
                }
                conn.Close();
            }
            return dto;
        }
        public List<string> GetSizesById(int id)
        {
            List<string> sizes = new List<string>();

            using(SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT Size FROM [ProductSizes] WHERE Product_id = @id ORDER BY Size";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);
                conn.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {                        
                        sizes.Add(reader.GetString(0));                       
                    }
                }
                conn.Close();
            }
            return sizes;
        }
    }
}
