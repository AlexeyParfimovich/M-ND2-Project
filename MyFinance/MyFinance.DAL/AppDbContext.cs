using Microsoft.EntityFrameworkCore;
using MyFinance.DAL.Entities;
using MyFinance.DAL.TypeConfigurations;

namespace MyFinance.DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connect DevDB by default if ContextOption was not configured
            if (!optionsBuilder.IsConfigured)
            {
                string dbConnectionString = "server=localhost,49994;database=devdb;user id=sa;password=1234;";
                optionsBuilder.UseSqlServer(dbConnectionString);
            }
#if DEBUG
            optionsBuilder.LogTo(System.Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());

            //modelBuilder.Entity<UserEntity>().HasData(
            //new UserEntity[]
            //{
            //    new UserEntity { Id=1, FirstName="Administrator", Email="test@test.com", Login="admin", Password="1234", IsActive=true}
            //});
        }
    }
}
