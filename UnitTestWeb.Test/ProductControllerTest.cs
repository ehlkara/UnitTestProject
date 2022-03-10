using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Web.Controllers;
using UnitTest.Web.Models;
using UnitTest.Web.Repository;
using Xunit;

namespace UnitTestWeb.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _mockRepo;

        private readonly ProductsController _controller;

        private List<Product> products;

        public ProductControllerTest()
        {
            _mockRepo = new Mock<IRepository<Product>>();
            _controller = new ProductsController(_mockRepo.Object);

            products = new List<Product>() { new Product { Id = 1, Name = "Pen", Price = 100, Stock = 50, Color = "Red" }, new Product { Id = 2, Name = "Notebook", Price = 200, Stock = 500, Color = "Blue" } };
        }

        [Fact]
        public async void Index_ActionExecute_ReturnView()
        {
            var result = await _controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
