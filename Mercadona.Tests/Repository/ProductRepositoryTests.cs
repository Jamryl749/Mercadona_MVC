﻿using Mercadona.DataAccess.Data;
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
        public async void CategoryRepository_Add_ReturnsBool()
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
            int count = uow.Product.GetAll().Count();
            int newCount = 0;

            //Act& Assert
            try
            {
                uow.Product.Add(product);
                uow.Save();
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
            newCount.Equals(count + 1);
        }
        [Fact]
        public async void CategoryRepository_Remove_ReturnsBool()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            var product = uow.Product.Get(x => x.Id == 5);
            int count = uow.Product.GetAll().Count();
            int newCount = 0;

            //Act& Assert
            try
            {
                uow.Product.Remove(product);
                uow.Save();
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
            newCount.Equals(count - 1);
        }
    }
}
