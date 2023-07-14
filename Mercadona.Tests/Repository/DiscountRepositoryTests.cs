using Mercadona.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Mercadona.Tests.Repository
{
    public class DiscountRepositoryTests
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
            var discount = new Discount()
            {
                Name = "Foo Discount",
                DiscountValue = 40,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1)
            };
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            int count = uow.Discount.GetAll().Count();
            int newCount = 0;

            //Act& Assert
            try
            {
                uow.Discount.Add(discount);
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
            var discount = uow.Discount.Get(x => x.Id == 2);
            int count = uow.Discount.GetAll().Count();
            int newCount = 0;

            //Act& Assert
            try
            {
                uow.Discount.Remove(discount);
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
