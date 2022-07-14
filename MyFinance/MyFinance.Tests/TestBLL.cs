using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using MyFinance.DAL;
using MyFinance.DAL.Entities;
using System.Linq;
using System.Collections.Generic;

namespace MyFinance.Tests
{
    [TestFixture]
    class TestBLL
    {
        //private UnitOfWork _db;
        //private readonly string _dbConnectionString = "server=localhost,49994;database=testdb;user id=sa;password=1234;";

        [OneTimeSetUp]
        public void FixtureSetUp()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<FinanceDbContext>();
            //optionsBuilder.UseSqlServer(_dbConnectionString);

            //var context = new FinanceDbContext(optionsBuilder.Options);

            //Seed(context);

            //_db = new(context);
        }

        [SetUp]
        public void TestSetUp()
        {
            
        }

        [Test, Order(1)]
        public void Add_user_return_entity()
        {
            //var user = NewUserEntity(
            //    1, 
            //    firstName: "First", 
            //    lastName: "Last",
            //    email: null,
            //    phone: null,
            //    login: null,
            //    password: null,
            //    isActive: null
            //   );

            //var result = _db.Users.Create(user).Result;

            //Assert.IsFalse(result.Id == 0, "User Id should be created");
        }

        [Test, Order(2)]
        public void Get_all_users_return_entities()
        {
            //var users = new List<BudgetEntity>();


            //for (var i=1; i<3; i++)
            //{
            //    users.Add( NewUserEntity(
            //            i,
            //            firstName: "First",
            //            lastName: "Last",
            //            email: null,
            //            phone: null,
            //            login: null,
            //            password: null,
            //            isActive: null
            //   ))
                    
            //        )
            //};

            //var result = _db.Users.GetAll().Result;

            //Assert.IsTrue(Enumerable.Count(result) == 4, "4 Users should be getted");
        }


        [TearDown]
        public void TestTearDown()
        {
            //_db.Users.Clear();
        }

        [OneTimeTearDown]
        public void FixtureTearDown()
        {
            //_db.Dispose();
        }

        //private void Seed(FinanceDbContext context)
        //{
        //    context.Database.EnsureDeleted();
        //    context.Database.Migrate();

        //    //context.AddRange(user1, user2);
        //    //context.SaveChanges();
        //}

        private BudgetEntity NewUserEntity(
                //int number, 
                //string firstName = null, 
                //string lastName = null,
                //string email = null,
                //string phone = null,
                //string login = null,
                //string password = null,
                //bool? isActive = null
            )
        {
            return new BudgetEntity
            {
                //FirstName = firstName is null ? null : $"{firstName}{number}",
                //LastName = lastName,
                //Email = email is null ? null : $"{number}{email}",
                //Phone = phone,
                //Login = login is null ? null : $"{login}{number}",
                //Password = password is null ? null : $"{password}{number}",
                //IsActive = isActive?? false 
            };
        }
    }
}
