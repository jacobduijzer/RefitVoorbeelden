using Refit;

namespace RefitVoorbeelden.Core;

public interface IProfessionalsApi
{
    [Get("/requestforsubject/{subject}")]
    Task<Professional> FindProfessionalForQuestion(string subject);

    [Post("/requestforproject")]
    Task SendRequestForProject([Body] ProjectDescription projectDescription);

    [Post("/login")]
    Task<string> Login(UserDto userDto);

    [Post("/addprofessional")]
    Task AddProfessional([Body] Professional professional, [Authorize("Bearer")] string bearerToken);

    [Post("/kortebroeknaarkantoor")]
    Task<string> CanIWearShortsToTheOffice();
}