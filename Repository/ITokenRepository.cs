using AuthenticateService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticateService.Repository
{
    public interface ITokenRepository
    {
        public Authenticate AuthenticateUser(Authenticate login);
        public string GenerateJSONWebToken(Authenticate userInfo);
    }
}
