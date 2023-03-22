using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public abstract class User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string password;

        public int Id { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
        public string? Email { get; }
        public string? Password { get; }

    }
}
