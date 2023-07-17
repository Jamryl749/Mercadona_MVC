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
        public async void DiscountRepository_Add_ReturnsBoolAndCountPlus1()
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

            //Act& Assert
            uow.Discount.Add(discount);
            uow.Save();
            int newCount = uow.Discount.GetAll().Count();
            if (newCount == count + 1)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
        [Fact]
        public async void DiscountRepository_Update_ReturnsBoolAndCountEqual()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            var discount = uow.Discount.Get(x => x.Id == 2);
            int count = uow.Discount.GetAll().Count();

            //Act& Assert
            uow.Discount.Update(discount);
            uow.Save();
            int newCount = uow.Discount.GetAll().Count();
            if (newCount == count)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
        [Fact]
        public async void DiscountRepository_Remove_ReturnsBoolAndCountMinus1()
        {
            //Arrange
            var dbContext = await GetDbContext();
            var uow = new UnitOfWork(dbContext);
            var discount = uow.Discount.Get(x => x.Id == 2);
            int count = uow.Discount.GetAll().Count();

            //Act& Assert
            uow.Discount.Remove(discount);
            uow.Save();
            int newCount = uow.Discount.GetAll().Count();
            if (newCount == count - 1)
            {
                Assert.True(true);
            }
            else
                Assert.True(false);
        }
    }
}
