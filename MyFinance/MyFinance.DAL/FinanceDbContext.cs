using Microsoft.EntityFrameworkCore;
using MyFinance.DAL.Entities;
using MyFinance.DAL.EntityTypeConfigs;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyFinance.DAL
{
    public class FinanceDbContext: DbContext, IFinanceDbContext
    {
        /// <summary>
        /// The default database schema.
        /// </summary>
        public const string DefaultSchema = "finance";

        public FinanceDbContext Context { get => this; }

        public DbSet<CurrencyEntity> Currencies { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<BudgetEntity> Budgets { get; set; }
        public DbSet<CardEntity> Cards { get; set; }

        public FinanceDbContext(
            DbContextOptions<FinanceDbContext> options) : base(options)
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchema);
            modelBuilder.ApplyConfiguration(new CurrencyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BudgetTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CardTypeConfiguration());
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Set current datetime to CreatedAt/UpdatedAt properties if exist
        /// </summary>
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
