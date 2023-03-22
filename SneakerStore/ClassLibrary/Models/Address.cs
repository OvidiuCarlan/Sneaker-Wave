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
        private string streetNumber;
        private string streetNumberAddOn;
        private string zipCode;

        public int Id { get { return id; } }
        public string City { get { return city; } }
        public string Sreet { get { return street; } }
        public string StreetNumber { get { return streetNumber; } }
        public string StreetNumberAddOn { get { return streetNumberAddOn; } }
        public string Zipcode { get { return zipCode; } }

        public Address()
        {
            id = 0;
            city = "";
            street = "";
            streetNumber = "";
            streetNumberAddOn = "";
            zipCode = "";
        }
        public Address(string city, string street, string streetNumber, string streetNumberAddOn, string zipCode)
        {
            this.city = city;
            this.street = street;
            this.streetNumber = streetNumber;
            this.streetNumberAddOn = streetNumberAddOn;
            this.zipCode = zipCode;
        }
        public Address(int id, string city, string street, string streetNumber, string streetNumberAddOn, string zipCode)
        {
            this.id = id;
            this.city = city;
            this.street = street;
            this.streetNumber = streetNumber;
            this.streetNumberAddOn = streetNumberAddOn;
            this.zipCode = zipCode;
        }
    }
}
