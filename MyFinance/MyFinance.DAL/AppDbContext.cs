using Microsoft.EntityFrameworkCore;
using MyFinance.DAL.Models;
using MyFinance.DAL.TypeConfigurations;

namespace MyFinance.DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dbConnectionString = "server=localhost,49994;database=devdb;user id=sa;password=1234;";
                optionsBuilder.UseSqlServer(dbConnectionString);
            }

            optionsBuilder.LogTo(System.Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        }
    }
}
