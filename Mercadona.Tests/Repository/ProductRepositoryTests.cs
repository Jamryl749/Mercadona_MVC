using Mercadona.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Mercadona.Tests.Repository
{
    public class ProductRepositoryTests
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }
        [Fact]
        public async void ProductRepository_Add_ReturnsBoolAndCountPlus1()
        {
            //Arrange
            var product = new Product()
            {
                Name = "Foo Product",
                Desc = "Foo Product desc.",
                ImageUrl = "https://example.com/images/red-apples.jpg",
                Price = 99.99m,
                CategoryId = 1,
                DiscountId = null,
                DiscountedPrice = 0m
            };
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            int count = uow.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount").Count();
            //Act& Assert
            uow.Product.Add(product);
            uow.Save();
            int newCount = uow.Product.GetAll().Count();
            if (newCount == count + 1)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
        [Fact]
        public async void ProductRepository_Update_ReturnsBoolAndCountEqual()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            var product = uow.Product.Get(x => x.Id == 5);
            int count = uow.Product.GetAll().Count();

            //Act& Assert
            uow.Product.Update(product);
            uow.Save();
            int newCount = uow.Product.GetAll().Count();
            if (newCount == count)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
        [Fact]
        public async void ProductRepository_Remove_ReturnsBoolAndCountMinus1()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            var product = uow.Product.Get(x => x.Id == 5, includeCategories: "Category", includeDiscounts: "Discount");
            int count = uow.Product.GetAll().Count();

            //Act& Assert
            uow.Product.Remove(product);
            uow.Save();
            int newCount = uow.Product.GetAll().Count();
            if (newCount == count - 1)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
        [Fact]
        public async void ProductRepository_RemoveRange_ReturnsBoolAndCountMinus3()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            var product5 = uow.Product.Get(x => x.Id == 5, includeCategories: "Category", includeDiscounts: "Discount");
            var product6 = uow.Product.Get(x => x.Id == 6, includeCategories: "Category", includeDiscounts: "Discount");
            var product7 = uow.Product.Get(x => x.Id == 7, includeCategories: "Category", includeDiscounts: "Discount");
            var productList = new List<Product>()
            {
                product5,
                product6,
                product7
            };
            int count = uow.Product.GetAll().Count();
            

            //Act& Assert
            uow.Product.RemoveRange(productList);
            uow.Save();
            int newCount = uow.Product.GetAll().Count();
            if (newCount == count - 3)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
    }
}
