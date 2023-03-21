using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class Customer : User
    {      
        public string ? Phone { get; set; }
        public Address ? Address { get; set; }
    }
}
