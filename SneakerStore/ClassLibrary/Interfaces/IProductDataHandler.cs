using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IProductDataHandler
    {
        public bool Add(ProductDTO product);
        public bool Remove(int id);
        public bool Edit(ProductDTO product);
        public List<ProductDTO> GetAll();
    }
}
