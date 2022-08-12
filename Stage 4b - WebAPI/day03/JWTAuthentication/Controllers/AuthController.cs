using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("gettoken/{userId:int}")]
        public IActionResult GetToken(int userId)
        {
            string userRole = userId == 1 ? "Admin" : "POC";
            string token = GenerateJSONWebToken(userRole);
            return Ok(token);
        }

        private string GenerateJSONWebToken(string userRole)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,userRole)
            };
            var tokenDescriptor = new JwtSecurityToken(
                issuer: "mySystems",
                audience: "myUsers",
                expires: DateTime.Now.AddMinutes(2),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret")), SecurityAlgorithms.HmacSha256)
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return token;
        }
    }
}
