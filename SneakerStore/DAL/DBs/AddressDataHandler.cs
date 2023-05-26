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
    public class AddressDataHandler : IAddressDataHandler
    {
        public int AddAddress(Address address)
        {
            using (SqlConnection conn = DBConnection.CreateConnection())
            {
                string sql = "INSERT INTO [Addresses](City, Street, HouseNumber, ZipCode) VALUES (@city, @street, @houseNumber, @zipCode);" +
                             "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@city", address.City);
                cmd.Parameters.AddWithValue("@street", address.Sreet);
                cmd.Parameters.AddWithValue("@houseNumber", address.HouseNumber);
                cmd.Parameters.AddWithValue("@zipCode", address.Zipcode);

                conn.Open();
                int addressId = 0;
                addressId = Convert.ToInt32(cmd.ExecuteScalar());

                return addressId;
            }
        }
    }
}
