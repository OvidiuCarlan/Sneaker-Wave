using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    internal class Manager : User
    {
        public Manager(string firstName, string lastName, string email, string password) : base(firstName, lastName, email, password)
        {
        }
    }
}
