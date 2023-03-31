    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public abstract class User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string salt;
        private string password;        

        public int Id { get { return id; } }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string Email { get { return email; } }
        public string Salt { get { return salt; } }
        public string Password { get { return password; } }

        public User(string firstName, string lastName, string email, string salt,  string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.salt = salt;
            this.password = password;
        }
        public User(int id,string firstName, string lastName, string email, string salt, string password)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.salt = salt;
            this.password = password;
        }
        public User(int id, string firstName, string lastName, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.salt = "";
            this.password = "";
        }
    }
}
