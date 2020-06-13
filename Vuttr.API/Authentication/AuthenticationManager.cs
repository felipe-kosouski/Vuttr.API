using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Vuttr.API.Domain.DTO.User;
using Vuttr.API.Domain.Models;

namespace Vuttr.API.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;

        private User _user;

        public AuthenticationManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, _user.UserName) 
            };
            var roles = await _userManager.GetRolesAsync(_user); 
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); 
            }
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);   
        }
        
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var validIssuer = Environment.GetEnvironmentVariable("VALID_ISSUER");
            var validAudience = Environment.GetEnvironmentVariable("VALID_AUDIENCE");
            var jwtExpires = Environment.GetEnvironmentVariable("JWT_EXPIRES");
            var tokenOptions = new JwtSecurityToken 
            (
                issuer: validIssuer, 
                audience: validAudience, 
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtExpires)), signingCredentials: signingCredentials
            );
            return tokenOptions; }
        
    }
}