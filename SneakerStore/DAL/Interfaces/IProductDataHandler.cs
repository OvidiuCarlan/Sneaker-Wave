using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductDataHandler
    {
        public bool AddProductToDataBase(ProductDTO product);
        public bool DeleteProduct(int id);
        public bool EditProduct(ProductDTO product);
        public List<ProductDTO> GetAllProducts();

    }
}
