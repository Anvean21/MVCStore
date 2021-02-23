using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCStore.Controllers;
using MVCStore.Domain.Core;
using MVCStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCStore.Tests.Controllers
{
    [TestClass]
    public class CartControllerUnitTesting
    {
        
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Организация - создание нескольких тестовых игр
            Product product = new Product { Name = "TestProduct 1", Description="Somethin about product", CategoryId = 7, Price = 1 }; 


            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(product, 1);
            List<CartLine> results = cart.Lines.ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 1);
            Assert.AreEqual(results[0].Product, product);
        }
        [TestMethod]
        public void Can_Clear_Contents()
        {
            // Организация - создание нескольких тестовых игр
            Product product = new Product { Name = "TestProduct 1", Description = "Somethin about product", CategoryId = 7, Price = 1 };
            Product product2 = new Product { Name = "TestProduct 2", Description = "Somethin about product", CategoryId = 7, Price = 4 };


            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(product, 1);
            cart.AddItem(product2, 1);
            cart.AddItem(product, 5);
            cart.Clear();

            // Утверждение
            Assert.AreEqual(cart.Lines.Count(), 0);
        }

      
    }
}
