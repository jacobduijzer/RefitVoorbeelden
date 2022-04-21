using System.IdentityModel.Tokens.Jwt;
using RefitVoorbeelden.Core;

namespace RefitVoorbeelden.RockstarsApi;

public interface ITokenService
{
    JwtSecurityToken BuildToken(UserDto userDto);
}