using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticateService.Models;
using AuthenticateService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(TokenController));
        ITokenRepository tokenRepository;
        public TokenController(ITokenRepository _tokenRepository)
        {
            tokenRepository = _tokenRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] Authenticate login)
        {

            //_log4net.Info("Authentication initiated");
            IActionResult response = BadRequest("error");
            var user = tokenRepository.AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = tokenRepository.GenerateJSONWebToken(user);
                //_log4net.Info("Token Generated");
                response = Ok(tokenString);
            }
            return response;
        }
    }
}
