using Logic.DTOs;
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
    public class UserManagerTesting
    {
        //UserManager userManager = new UserManager(new MockUserDataHandler());

        [TestMethod]
        public void Login_HappyFlow()
        {
            //Arrange
            UserManager userManager = new UserManager(new MockUserDataHandler());
            Customer customer = new Customer("000", "000", "test@mail.com", "000", "1234", "test");
            CustomerDTO customerDTO = customer.CustomerToCustomerDTO();
            //Act
            bool expectedResult = userManager.Login(customerDTO);
            //Assert
            Assert.IsTrue(expectedResult);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Email is not correct")]
        public void Login_EmailIsNotCorrect()
        {
            //Arrange
            UserManager userManager = new UserManager(new MockUserDataHandler());
            Customer customer = new Customer("test", "test", "test@mail.com", "1234567890", "", "test");
            CustomerDTO customerDTO = customer.CustomerToCustomerDTO();
            //Act
            bool expectedResult = userManager.Login(customerDTO);
            //Assert
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Password is not correct")]
        public void Login_PasswordIsNotCorrect()
        {
            //Arrange
            UserManager userManager = new UserManager(new MockUserDataHandler());
            Customer customer = new Customer("test", "test", "test@mail.com", "1234567890", "test", "test1");
            CustomerDTO customerDTO = customer.CustomerToCustomerDTO();
            //Act
            bool expectedResult = userManager.Login(customerDTO);
            //Assert
        }
    }
}
