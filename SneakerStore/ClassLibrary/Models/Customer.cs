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
        public string Phone { get { return phone; } }

        public Customer(string firstName, string lastName, string email, string password, string phone) : base(firstName, lastName, email, password)
        {
            this.phone = phone;
        }
        public Customer(int id, string firstName, string lastName, string email, string password, string phone) : base(id, firstName, lastName, email, password)
        {
            this.phone = phone;
        }
    }
}
