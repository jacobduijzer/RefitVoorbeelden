using Refit;
using RefitVoorbeelden.Core;

// var api = Refit.RestService.For<IProfessionalsApi>("http://localhost:5128");

// var httpClient = new HttpClient(new OrganizationHeaderHandler()) {BaseAddress = new Uri("http://localhost:5128")};
// var api = RestService.For<IProfessionalsApi>(httpClient);

// Create an API based on the interface
var api = RestService.For<IProfessionalsApi>("http://localhost:5128");

// Example 1: simple get 
var professional = await api.FindProfessionalForQuestion(Subject.Agile.ToString());
Console.WriteLine($"Je kunt met je vragen over {Subject.Agile} terecht bij de deze professional: {professional.FirstName} {professional.LastName}, {professional.Title} <{professional.EmailAddress}>.");

// Example 2: simple post
ProjectDescription projectDescription = new()
{
    CompanyName = "Some Awesome Company",
    Location = "Eindhoven",
    JobTitle = Title.TeamLead,
    Description = "Voor een zelfstandig Agile team van 4 developers en een scrum master zijn we op zoek naar een Team Lead die kan helpen het niveau van het team op een hoger niveau te brengen. De tech-stack is .NET, het niveau van de developers is wisselend"
};
await api.SendRequestForProject(projectDescription);

// Example 3: login, using bearer token
Professional newProfessional = new()
{
    FirstName = "Dirk",
    LastName = "Alma",
    EmailAddress = "dirk.alma@gmail.com",
    Title = Title.ProductOwner,
    Technologies = new List<string> { Subject.Agile.ToString(), Subject.AzureDevOps.ToString()}
};

var bearerToken = await api.Login(new UserDto("rock", "star123"));
await api.AddProfessional(newProfessional, bearerToken);