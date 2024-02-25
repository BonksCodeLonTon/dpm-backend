using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Services
{
    public interface IJwtService
    {
        string Encode(IEnumerable<Claim> claims, int ttl = 24 * 60);
        IEnumerable<Claim> Decode(string token);
    }
}
