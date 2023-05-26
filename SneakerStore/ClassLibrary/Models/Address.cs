using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Address
    {
        private int id;
        private string city;
        private string street;
        private string houseNumber;
        private string zipCode;

        public int Id { get { return id; } }
        public string City { get { return city; } }
        public string Sreet { get { return street; } }
        public string HouseNumber { get { return houseNumber; } }
        public string Zipcode { get { return zipCode; } }

        public Address()
        {
            id = 0;
            city = "";
            street = "";
            houseNumber = "";
            zipCode = "";
        }
        public Address(string city, string street, string houseNumber, string zipCode)
        {
            this.id = 0;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.zipCode = zipCode;
        }
        public Address(int id, string city, string street, string houseNumber, string zipCode)
        {
            this.id = id;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.zipCode = zipCode;
        }
        public Address(AddressDTO dto)
        {
            this.id = 0;
            this.city = dto.City;
            this.street = dto.Street;
            this.houseNumber = dto.StreetNumber;
            this.zipCode = dto.Zipcode;
        }
    }
}
