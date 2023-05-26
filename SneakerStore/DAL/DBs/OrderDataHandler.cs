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

        public int SaveOrder(int customerId, int addressId, int cardId, DateTime dateTime, double price)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [Orders](Customer_Id, Address_Id, Card_Id, DateTime, Price) VALUES (@customerId, @addressId, @cardId, @dateTime, @price);" +
                             "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand (sql, conn);

                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@addressId", addressId);
                cmd.Parameters.AddWithValue("@cardId", cardId);
                cmd.Parameters.AddWithValue("@dateTime", dateTime);
                cmd.Parameters.AddWithValue("@price", price);

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
                        dataTable.Rows.Add(orderId, item.Product.Id, item.Size, item.Size);
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
