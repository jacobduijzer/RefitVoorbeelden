using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RefitVoorbeelden.Core;

namespace RefitVoorbeelden.RockstarsApi.Controllers;

[ApiController]
[Produces("application/json")]
public class ProfessionalController : ControllerBase
{
    /// <summary>
    /// Zoek een IT Professional die je kan helpen met de vraag over een speficiek onderwerp. 
    /// </summary>
    /// <remarks>Zit jouw specifieke onderwerp er niet bij? Neem dan contact met ons op!</remarks>
    /// <response code="200">Professional gevonden!</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Produces(typeof(Professional))]
    [HttpGet("requestforsubject/{subject}")]
    public IActionResult GetProfessionalForSubject([FromServices] ProfessionalData professionalData, Subject subject)
    {
        var professional = professionalData.Professional.FirstOrDefault(x => x.Technologies.Contains(subject.ToString()));
        return Ok(professional);
    }

    /// <summary>
    /// Zoek je een IT Professional die impact komt maken binnen jouw organisatie? Vul je gegevens in en wij matchen de juiste persoon! 
    /// </summary>
    /// <remarks></remarks>
    /// <response code="201">We hebben de projectbeschrijving is onvangen en gaan ermee aan de slag.</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost("requestforproject")]
    public IActionResult RequestForProfessional([FromBody] ProjectDescription projectDescription)
    {
        return Created(string.Empty, projectDescription);
    }

    /// <summary>
    /// Voeg een nieuwe IT Professional toe aan ons systeem.
    /// </summary>
    /// <remarks></remarks>
    /// <response code="201">De nieuwe professional is nu bekend in ons systeem en kan aan de slag met vragen of projecten.</response>
    /// <response code="401">Helaas, je hebt niet de juiste rechten om nieuwe professionals aan ons systeem toe te voegen.</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("addprofessional"), Authorize]
    public IActionResult AddProfessional([FromBody] Professional professional)
    {
        return Created(string.Empty, professional);
    }

    /// <summary>
    /// Op onze 'main stage' mag je dragen waar jij je lekker in voelt. Maar is het op dit moment wel weer voor een korte broek op ons hoofdkwartier? 
    /// </summary>
    /// <remarks></remarks>
    /// <response code="200">De voorspelling komt jouw kant op.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("kortebroeknaarkantoor")]
    public async Task<IActionResult> KorteBroekNaarKantoor(
        [FromServices] WeatherService weatherService,
        [FromServices] WeatherServiceSettings weatherServiceSettings)
    {
        var weatherData = await weatherService.GetWeatherForLocation(weatherServiceSettings.Latitude, weatherServiceSettings.Longitude, weatherServiceSettings.ApiKey).ConfigureAwait(false);
        return Ok(weatherData.Temperatures.Maximum >= 15f ? 
            $"Prima weer om in je korte broek te gaan, het wordt vandaag {Math.Round(weatherData.Temperatures.Maximum, 0)} graden!" :
            $"Ik zou het niet doen vandaag, het wordt maar {Math.Round(weatherData.Temperatures.Maximum, 0)} graden!");
    }
}