using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using MyFinance.DAL;
using MyFinance.DAL.Entities;
using System.Linq;

namespace MyFinance.Tests
{
    [TestFixture]
    class TestUsers
    {
        private UnitOfWork _db;
        private readonly string _dbConnectionString = "server=localhost,49994;database=testdb;user id=sa;password=1234;";

        [OneTimeSetUp]
        public void SetUp()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(_dbConnectionString);

            var context = new AppDbContext(optionsBuilder.Options);

            Seed(context);

            _db = new(context);
        }

        private void Seed(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var users = new UserEntity[]
            {
                new UserEntity { FirstName="Test user1", Email="test1@test.com", Login="user1", Password="1234", IsActive=true},
                new UserEntity { FirstName="Test user2", Email="test2@test.com", Login="user2", Password="1234", IsActive=true},
                new UserEntity { FirstName="Test user3", Email="test3@test.com", Login="user3", Password="1234", IsActive=true},
            };

            context.AddRange(users);
            context.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _db.Dispose();
        }

        [Test, Order(1)]
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

        [Test, Order(2)]
        public void Get_UserEntity_return_id()
        {
            var result = _db.Users.GetAll().Result;

            Assert.IsTrue(Enumerable.Count(result) == 4, "4 Users should be getted");
        }
    }
}
