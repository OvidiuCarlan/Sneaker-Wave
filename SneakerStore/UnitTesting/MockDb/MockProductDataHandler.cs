using DAL.DTOs;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MockDb
{
    public class MockProductDataHandler : IProductDataHandler
    {
        public bool Add(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public bool Edit(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetAll()
        {
            List<ProductDTO> expectedProducts = new List<ProductDTO>();
            expectedProducts.Add(new Product(1, "testBrand", "test", 10, "testCategory", "testImage").ProductToProductDTO());
            expectedProducts.Add(new Product(2, "testBrand2", "test2", 11, "testCategory2", "testImage2").ProductToProductDTO());
            return expectedProducts;
        }

        public ProductDTO GetProductById(int id)
        {
            Product expectedProduct = new Product(1, "testBrand", "test", 10, "testCategory", "testImage");
            return expectedProduct.ProductToProductDTO();
        }

        public List<string> GetSizesById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
