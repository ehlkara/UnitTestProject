using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Web.Models;

namespace UnitTestWeb.Test
{
    public class ProductControllerTest
    {
        protected DbContextOptions<UnitTestDbContext> _contextOptions { get; private set; }

        public void SetContextOptions(DbContextOptions<UnitTestDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
            Seed();
        }

        public void Seed()
        {
            using (UnitTestDbContext context = new UnitTestDbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Categories.Add(new Category { Name = "Pens" });
                context.Categories.Add(new Category { Name = "NoteBooks" });
                context.SaveChanges();

                context.Products.Add(new Product { CategoryId = 1, Name = "Pen 10", Price = 100, Stock = 100, Color = "Red" });
                context.Products.Add(new Product { CategoryId = 1, Name = "Pen 20", Price = 100, Stock = 100, Color = "Blue" });
                context.SaveChanges();
            }
        }
    }
}
