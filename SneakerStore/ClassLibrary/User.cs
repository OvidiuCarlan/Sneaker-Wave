using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class User
    {
        protected int Id { get; set; }
        protected string Email { get; set; } 
        protected string Password { get; set; }

    }
}
