
using AMS.Application.Common.Interfaces;
using AMS.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AMS.Infrastructure.Authentication
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JWTSettings _jWTSettings;
        public JWTTokenGenerator(IDateTimeProvider dateTimeProvider,
                                 IOptions<JWTSettings> jWTOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jWTSettings = jWTOptions.Value;
        }

        public string GenerateToken(Guid userId, string firstName, string lastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jWTSettings.SecretKey)),
                    SecurityAlgorithms.HmacSha256);


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jWTSettings.Issuer,
                audience: _jWTSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddDays(_jWTSettings.ExpireInHours),
                claims: claims,
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
