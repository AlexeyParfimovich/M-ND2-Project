using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace MyFinance.DAL
{
    internal class ContextFactory : IDesignTimeDbContextFactory<FinanceDbContext>
    {
        private readonly ILogger<FinanceDbContext> _logger;

        public ContextFactory()
        {
        }

        public ContextFactory(ILogger<FinanceDbContext> logger)
        {
            _logger = logger;
        }

        public FinanceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinanceDbContext>();

            // получить конфигурацию из файла MyFinance\DAL\appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // получить строку подключения из файла конфигурации
            var connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
#if DEBUG
            optionsBuilder.LogTo(message => _logger.LogDebug(message));
#endif
            return new FinanceDbContext(optionsBuilder.Options);
        }
    }
}
