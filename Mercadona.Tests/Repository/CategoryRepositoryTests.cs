using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async void CategoryRepository_Add_ReturnsBool()
        {
            //Arrange
            var category = new Category()
            {
                Name = "Foo",
            };
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            int count = uow.Category.GetAll().Count();
            int newCount = 0;

            //Act& Assert
            try
            {
                uow.Category.Add(category);
                uow.Save();
                newCount = uow.Category.GetAll().Count();
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
            var category = uow.Category.Get(x => x.Id == 5);
            int count = uow.Category.GetAll().Count();
            int newCount = 0;

            //Act& Assert
            try
            {
                uow.Category.Remove(category);
                uow.Save();
                newCount = uow.Category.GetAll().Count();
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
