using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NexusERP.Application.Common.Authentication;
using NexusERP.Application.Common.Interfaces;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NexusERP.Persistence.Authentication
{
    public sealed class JwtTokenProvider : IJwtTokenProvider
    {
        private readonly JwtSettings _jwtSettings;
        public JwtTokenProvider(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("EmployeeId", user.EmployeeId.ToString())
            };
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
