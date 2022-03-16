using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.Web.Controllers;
using UnitTest.Web.Models;
using Xunit;

namespace UnitTestWeb.Test
{
    public class ProductControllerTestWithInMemoryTest : ProductControllerTest
    {
        public ProductControllerTestWithInMemoryTest()
        {
            SetContextOptions(new DbContextOptionsBuilder<UnitTestDbContext>().UseInMemoryDatabase("UnitTestDbInMemoryDb").Options);
        }

        [Fact]
        public async Task Create_ModelValidProduct_ReturnRedirectToActionWithProduct()
        {

            var newProduct = new Product { Name = "Pen 30", Price = 90, Stock = 100 };

            using (var context = new UnitTestDbContext(_contextOptions))
            {
                var category = context.Categories.First();

                newProduct.CategoryId= category.Id;

                //var repository = new Repository<Product>(context);
                var controller = new ProductsController(context);

                var result = await controller.Create(newProduct);

                var redirect = Assert.IsType<RedirectToActionResult>(result);

                Assert.Equal("Index", redirect.ActionName);
            }

            using (var context = new UnitTestDbContext(_contextOptions))
            {
                var product = context.Products.FirstOrDefault(x => x.Name == newProduct.Name);

                Assert.Equal(newProduct.Name,product.Name);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteCategory_ExistCategoryId_DeletedAllProducts(int categoryId)
        {
            using (var context = new UnitTestDbContext(_contextOptions))
            {
                var category = await context.Categories.FindAsync(categoryId);

                context.Categories.Remove(category);

                context.SaveChanges();
            }

            using (var context = new UnitTestDbContext(_contextOptions))
            {
                var products = await context.Products.Where(x=>x.CategoryId==categoryId).ToListAsync();
                
                Assert.Empty(products);
            }
        }
    }
}
