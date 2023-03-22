using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserDataHandler
    {
        public bool Add();
        public bool Remove();
        public bool Edit();
        public List<User> GetAll();
    }
}
