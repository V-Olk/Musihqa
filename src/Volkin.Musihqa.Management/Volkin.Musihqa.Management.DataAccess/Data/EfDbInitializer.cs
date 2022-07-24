using Microsoft.Extensions.Logging;
using Volkin.Musihqa.Management.DataAccess.Common;

namespace Volkin.Musihqa.Management.DataAccess.Data
{
    public class EfDbInitializer
        : IDbInitializer
    {
        private readonly DataContext _dataContext;
        private readonly ILogger _logger;

        public EfDbInitializer(DataContext dataContext, ILogger<EfDbInitializer> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public void InitializeDb()
        {
            _dataContext.Database.EnsureDeleted();
            _dataContext.Database.EnsureCreated();

            _dataContext.AddRange(FakeDataFactory.Albums);
            _dataContext.SaveChanges();

            _logger.LogInformation("Database initialized");
        }
    }
}
