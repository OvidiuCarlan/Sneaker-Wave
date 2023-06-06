using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MockDb
{
    public class MockUserDataHandler : IUserDataHandler
    {
        public bool Add(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public int AddNoAccountCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Edit(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public (string password, string salt) GetPasswordAndSaltByEmail(string email)
        {
            if(email == "test@mail.com")
            {
                string password = "7f0e2cb26b1c8b0a77d2a6f41f19b3a9a2672aee7c5c13a7c15fbb1ea82eb297f425c6a1b1d38a9f2f8ff695a8d9c9b5378c5768c5cc2d73d2b93d82df19fbc";
                string salt = "1234";

                return (password, salt);
            }
            return ("", "");
        }

        public bool IsEmailUsed(string email)
        {
            throw new NotImplementedException();
        }

        public bool Remove()
        {
            throw new NotImplementedException();
        }
    }
}
