using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BattleFaceCodeChallenge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BattleFaceCodeChallenge.Controllers
{
    [ApiController]
    [Route("registration")]
    public class RegistrationController : ControllerBase
    {
        /// <summary>
        /// For the sake of simplicity, we are not doing much here.
        /// </summary>
        /// <returns>jwt</returns>
        [HttpGet]
        [Route("login")]
        public JsonResult Login()
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var token = new JwtSecurityToken("YOUR_ISSUER_VALUE", "YOUR_AUDIENCE_VALUE", claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new JsonResult(new { token = tokenString });
        }
    }
}
