using Logic.Interfaces;
using Logic.Logic;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.MockDb;

namespace UnitTesting.TestClasses
{
    [TestClass]
    public class FirstOrderDiscountTests
    {
        [TestMethod]
        public void IsApplicable_ReturnsTrue_ForFirstOrder()
        {
            // Arrange
            var discount = new FirstOrderDiscount(new MockOrderDataHandler());
            double price = 100;
            int userId = 1;
            // Act

            bool isApplicable = discount.IsApplicable(price, userId);
            // Assert
            Assert.IsTrue(isApplicable);
        }
        [TestMethod]
        public void IsApplicable_ReturnsFalse_ForNonFirstOrder()
        {
            // Arrange
            var discount = new FirstOrderDiscount(new MockOrderDataHandler());
            double price = 100;
            int userId = 0;
            // Act
            bool isApplicable = discount.IsApplicable(price, userId);

            // Assert
            Assert.IsFalse(isApplicable);
        }
        [TestMethod]
        public void CalculateDiscount_ReturnsCorrectDiscountAmount()
        {
            // Arrange
            var discount = new FirstOrderDiscount(new MockOrderDataHandler());
            double price = 100;
            // Act
            double calculatedDiscount = discount.CalculateDiscount(price);

            // Assert
            Assert.AreEqual(85, calculatedDiscount);
        }
    }
}
