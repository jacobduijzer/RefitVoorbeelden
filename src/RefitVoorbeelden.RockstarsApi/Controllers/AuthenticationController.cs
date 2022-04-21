using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using RefitVoorbeelden.Core;

namespace RefitVoorbeelden.RockstarsApi.Controllers;

[ApiController]
[Produces("application/json")]
public class AuthenticationController : ControllerBase
{
    /// <summary>
    /// Voor een goede beveiliging willen we even checken of je wel echt bent wie je zegt dat je bent.
    /// </summary>
    /// <remarks>Gebruikt de door ons verstrekte gegevens om in te loggen. Geen gegevens ontvangen? Neem dan contact met ons op.</remarks>
    /// <response code="200">Je bent gecontroleerd en mag gebruik maken van deze API!</response>
    /// <response code="400">Helaas, er is iets mis gegaan.</response>
    /// <response code="401">Helaas, je mag geen gebruik maken van deze API.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Produces(typeof(Professional))]
    [HttpPost("login")]
    public IActionResult Login([FromServices] ITokenService tokenService, UserDto userDto)
    {
        try
        {
            if (string.IsNullOrEmpty(userDto.UserName) ||
                string.IsNullOrEmpty(userDto.Password))
                return BadRequest("Username and/or Password not specified");
            if (userDto.UserName.Equals("rock") &&
                userDto.Password.Equals("star123"))
            {
                var token = tokenService.BuildToken(userDto);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
        }
        catch
        {
            return BadRequest("An error occurred in generating the token");
        }

        return Unauthorized();
    }
}