using DPM.Applications.Services;
using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using DPM.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void AuthorizeMilitary<T>(params Role[] roles) where T : BaseEntity, IBelongToMilitary
        {
            var user = _requestContextService.UserId;

        }

        public void AuthorizePortAuthority<T>(long resourceId, params Role[] roles) where T : BaseEntity, IBelongToPortAuthority
        {
            throw new NotImplementedException();
        }

        public void AuthorizePortAuthority<T>(params Role[] roles) where T : BaseEntity, IBelongToPortAuthority
        {
            throw new NotImplementedException();
        }
    }
}
