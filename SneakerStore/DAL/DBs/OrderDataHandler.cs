using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBs
{
    public class OrderDataHandler : IOrderDataHandler
    {
        public List<OrderDTO> GetAllOrdersForUser(int userId)
        {
            List<OrderDTO> orders = new List<OrderDTO>();
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "SELECT * FROM [Orders] WHERE Customer_Id = @id ORDER BY Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", userId);
                conn.Open();

                OrderDTO order = null;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    order = new OrderDTO();
                    CustomerDTO customer = new CustomerDTO();
                    CardDTO card = new CardDTO();

                    order.Id = reader.GetInt32("Id");
                    customer.Id = reader.GetInt32("Customer_Id");
                    card.Id = reader.GetInt32("Card_Id");
                    order.DateTime = reader.GetDateTime("DateTime");
                    order.Price = reader.GetDouble("Price");
                    order.Status = reader.GetString("Status");

                    order.Customer = customer;
                    order.Card = card;
                    orders.Add(order);
                }
                conn.Close();
                return orders;
            }
        }

        public int SaveOrder(int customerId, int addressId, int cardId, DateTime dateTime, double price, string status)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [Orders](Customer_Id, Address_Id, Card_Id, DateTime, Price, Status) VALUES (@customerId, @addressId, @cardId, @dateTime, @price, @status);" +
                             "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand (sql, conn);

                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@addressId", addressId);
                cmd.Parameters.AddWithValue("@cardId", cardId);
                cmd.Parameters.AddWithValue("@dateTime", dateTime);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue ("status", status);

                conn.Open();
                int orderId = 0;
                orderId = Convert.ToInt32(cmd.ExecuteScalar()); 
                
                return orderId;
            }
        }

        public bool SaveOrderItems(int orderId, List<ShoppingCartItem> items)
        {
            try
            {
                using (SqlConnection conn = DBConnection.CreateConnection())
                {
                    conn.Open();

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Order_Id", typeof(int));
                    dataTable.Columns.Add("Product_Id", typeof(int));
                    dataTable.Columns.Add("Size", typeof(string));
                    dataTable.Columns.Add("Quantity", typeof(int));

                    foreach (ShoppingCartItem item in items)
                    {
                        dataTable.Rows.Add(orderId, item.Product.Id, item.Size, item.Quantity);
                    }

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                    {
                        bulkCopy.DestinationTableName = "ShoppingCartItems";

                        bulkCopy.ColumnMappings.Add("Order_Id", "Order_Id");
                        bulkCopy.ColumnMappings.Add("Product_Id", "Product_Id");
                        bulkCopy.ColumnMappings.Add("Size", "Size");
                        bulkCopy.ColumnMappings.Add("Quantity", "Quantity");

                        bulkCopy.WriteToServer(dataTable);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }                     
        }
        
    }
}
