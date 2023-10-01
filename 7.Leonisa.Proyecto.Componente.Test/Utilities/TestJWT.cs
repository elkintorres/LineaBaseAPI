using _1.Leonisa.Proyecto.Componente.API.Utilities;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _7.Leonisa.Proyecto.Componente.Test.Utilities
{
    internal class TestJWT
    {
        private Microsoft.Extensions.Configuration.IConfiguration Configuration { get; set; }

        public TestJWT(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        internal string GenerateTokenJWT(int Timeout)
        {
            var jwtTokenConfig = Configuration.GetSection("JwtConfig").Get<JwtTokenConfig>();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
           {
                new Claim(ClaimTypes.Name, "UserTest"),
                new Claim("Module", "Products"),
                new Claim("Products", "Create"),
                new Claim("Products", "Update"),
                new Claim("Products", "Read"),
                new Claim("Products", "Delete")
            };
            var token = new JwtSecurityToken(
                issuer: jwtTokenConfig.Issuer,
                audience: jwtTokenConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Timeout),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
