﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UniverstyTMS.Core.Entities;

namespace UniverstyTMS.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string email, string name)
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

        public string GenerateToken(AppUser user, IList<string> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
            };

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList());

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
