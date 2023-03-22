using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDataHandler
    {
        public bool Add(Type type);
        public bool Remove(Type type);
        public bool Edit(Type type);
        public List<Type> GetAll();
    }
}
