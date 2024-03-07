using DPM.Applications.Services;
using DPM.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Auth.Policies
{
    internal class IsPortAuthorityRequirement: IAuthorizationRequirement
    {

    }
}
