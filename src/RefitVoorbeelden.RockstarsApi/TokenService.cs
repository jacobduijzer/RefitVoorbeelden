using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RefitVoorbeelden.Core;

namespace RefitVoorbeelden.RockstarsApi;

public class TokenService : ITokenService
{
    private readonly string _key;
    private readonly string _issuer;
    private TimeSpan ExpiryDuration = new TimeSpan(0, 30, 0);
    
    public TokenService(string key, string issuer)
    {
        _key = key;
        _issuer = issuer;
    }

    public JwtSecurityToken BuildToken(UserDto user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier,
                Guid.NewGuid().ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(_issuer, _issuer, claims, expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
        return tokenDescriptor;
    }
}
