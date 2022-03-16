using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.Web.Controllers;
using UnitTest.Web.Models;
using Xunit;

namespace UnitTestWeb.Test
{
    public class ProductControllerTestWithSQLite : ProductControllerTest
    {
        public ProductControllerTestWithSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            connection.Open();

            SetContextOptions(new DbContextOptionsBuilder<UnitTestDbContext>().UseSqlite(connection).Options);
        }

        [Fact]
        public async Task Create_ModelValidProduct_ReturnRedirectToActionWithProduct()
        {

            var newProduct = new Product { Name = "Pen 30", Price = 90, Stock = 100, Color = "Red" };

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

                Assert.NotNull(category);

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
