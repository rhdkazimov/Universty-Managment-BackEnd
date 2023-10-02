using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace UniverstyTMS.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(int id, string email, string name)
        {
            List<Claim> claims = new List<Claim>
            {
                //new Claim("Id",id.ToString()),
                new Claim("Email",email),
                new Claim("Name",name),
            };



            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Security:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddDays(3),
                issuer: _configuration["Security:Issuer"],
                audience: _configuration["Security:Audience"]);

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
           
            return tokenStr;
        }
    }
}
