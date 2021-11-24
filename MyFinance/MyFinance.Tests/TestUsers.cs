using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using MyFinance.DAL;
using MyFinance.DAL.Entities;

namespace MyFinance.Tests
{
    [TestFixture]
    public class TestUsers
    {
        private UnitOfWork _db;
        private readonly string _dbConnectionString = "server=localhost,49994;database=testdb;user id=sa;password=1234;";

        [SetUp]
        public void SetUp()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_dbConnectionString);

            var context = new AppDbContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            _db = new(context);
        }

        [Test]
        public void Add_UserEntity_return_id()
        {
            var result = _db.Users.Create(new UserEntity 
            {
                FirstName = "Test", 
                LastName = "Testovich",
                Email = "test@test.com",
                Phone = "+375-xx-xxx-xx-xx",
                Login = "test_user",
                Password = "qwerty"
            }).Result;

            Assert.IsFalse(result.Id == 0, "User Id should be created");
        }
    }
}
