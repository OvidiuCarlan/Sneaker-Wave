using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Customer : User
    {
        private string phone;
        private string Phone { get { return phone; } }

        public Customer(string firstName, string lastName, string email, string phone, string salt, string password) : base(firstName, lastName, email, salt, password)
        {
            this.phone = phone;
        }
        public Customer(int id, string firstName, string lastName, string email, string salt, string password) : base(id, firstName, lastName, email, salt,  password)
        {
            this.phone = phone;
        }
        public Customer(CustomerDTO dto) : base(dto.Id, dto.firstName, dto.lastName, dto.email)
        {
            this.phone = dto.phone;
        }
        public Customer() : base(0,"", "", "")
        {
            this.phone = "";
        }
        public CustomerDTO CustomerToCustomerDTO()
        {
            return new CustomerDTO()
            {
                Id = base.Id,
                firstName = base.FirstName,
                lastName = base.LastName,
                email = base.Email,
                salt = base.Salt,
                password = base.Password,
                phone = phone
            };
        }
    }
}
