using Mercadona.DataAccess.Data;
using Mercadona.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercadona.Tests.Repository
{
    public class CategoryRepositoryTests
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
        public async void CategoryRepository_Add_ReturnsBoolAndCountPlus1()
        {
            //Arrange
            var category = new Category()
            {
                Name = "Foo",
            };
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            int count = uow.Category.GetAll().Count();

            //Act& Assert
            uow.Category.Add(category);
            uow.Save();
            int newCount = uow.Category.GetAll().Count();
            if (newCount == count + 1)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
        [Fact]
        public async void CategoryRepository_Update_ReturnsBoolAndCountEqual()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            var category = uow.Category.Get(x => x.Id == 2);
            int count = uow.Category.GetAll().Count();

            //Act& Assert
            uow.Category.Update(category);
            uow.Save();
            int newCount = uow.Category.GetAll().Count();
            if (newCount == count)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
        [Fact]
        public async void CategoryRepository_Remove_ReturnsBoolAndCountMinus1()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            var category = uow.Category.Get(x => x.Id == 5);
            int count = uow.Category.GetAll().Count();

            //Act& Assert
            uow.Category.Remove(category);
            uow.Save();
            int newCount = uow.Category.GetAll().Count();
            if (newCount == count - 1)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
    }
}
