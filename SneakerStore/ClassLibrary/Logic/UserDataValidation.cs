using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public static class UserDataValidation
    {
        public static bool RegisterValidation(CustomerDTO customer)
        {
            if (!IsValidEmail(customer.email))
            {
                throw new ArgumentException("Invalid email address.");
            }

            if (!IsValidName(customer.firstName))
            {
                throw new ArgumentException("Invalid first name.");
            }

            if (!IsValidName(customer.lastName))
            {
                throw new ArgumentException("Invalid last name.");
            }

            if (!IsValidPhoneNumber(customer.phone))
            {
                throw new ArgumentException("Invalid phone number.");
            }

            return true; // All validations passed
        }
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        public static bool IsValidName(string name)
        {
            string namePattern = @"^[A-Za-z\s]+$";
            return Regex.IsMatch(name, namePattern);
        }
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string phoneNumberPattern = @"^\d{10}$";
            return Regex.IsMatch(phoneNumber, phoneNumberPattern);
        }
    }
}
