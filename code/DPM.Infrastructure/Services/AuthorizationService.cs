using DPM.Applications.Services;
using DPM.Infrastructure.Database;

namespace DPM.Infrastructure.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRequestContextService _requestContextService;
        private readonly ReadOnlyAppDbContext _dbContext;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(10);

        public AuthorizationService(IRequestContextService requestContextService, ReadOnlyAppDbContext dbContext)
        {
            _requestContextService = requestContextService;
            _dbContext = dbContext;
        }
    }
}