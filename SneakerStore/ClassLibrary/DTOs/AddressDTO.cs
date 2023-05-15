using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string StreetNumberAddOn { get; set; }
        public string Zipcode { get; set; }
    }
}
