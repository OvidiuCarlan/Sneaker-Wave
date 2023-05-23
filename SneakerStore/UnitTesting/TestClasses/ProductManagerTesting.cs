using DAL.DTOs;
using Logic.Interfaces;
using Logic.Logic;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.MockDb;

namespace UnitTesting.TestClasses
{
    [TestClass]
    public class ProductManagerTesting
    {
        //ProductManager productManager = new ProductManager(new MockProductDataHandler());


        [TestMethod]
        public void GetProductById_AddOneProduct_CompareProductNamesAndBrand()
        {
            //Arrange
            ProductManager productManager = new ProductManager(new MockProductDataHandler());
            Product ExpectedProduct = new Product(1, "testBrand", "test", 10, "testCategory", "testImage");
            ProductDTO ExpectedProductDto = ExpectedProduct.ProductToProductDTO();
            //Act
            ProductDTO ActualProductDTO = productManager.GetProductById(1);
            //Assert
            Assert.AreEqual(ExpectedProductDto.Name, ActualProductDTO.Name);
            Assert.AreEqual(ExpectedProductDto.Brand, ActualProductDTO.Brand);
        }
        [TestMethod]
        public void GetAll_AddingTwoProduct_TwoProductsAreReturned()
        {
            //Arrange
            ProductManager productManager = new ProductManager(new MockProductDataHandler());
            List<Product> expectedProducts = new List<Product>();
            expectedProducts.Add(new Product(1, "testBrand", "test", 10, "testCategory", "testImage"));
            expectedProducts.Add(new Product(2, "testBrand2", "test2", 11, "testCategory2", "testImage2"));
            //Act
            List<Product> actualProducts = productManager.GetAll();
            //Assert
            Assert.AreEqual(expectedProducts.Count, actualProducts.Count);

        }
        [TestMethod]
        public void GetSizesById_TwoSizesAreAdded_CompareNumberOfSizes()
        {
            //Arrange
            ProductManager productManager = new ProductManager(new MockProductDataHandler());
            List<string> expectedSizes = new List<string>
            {
                "44",
                "45"
            };
            //Act
            List<string> actualSizes = productManager.GetSizesById(1);
            //Assert
            CollectionAssert.AreEqual(expectedSizes, actualSizes);
        }
    }
}
