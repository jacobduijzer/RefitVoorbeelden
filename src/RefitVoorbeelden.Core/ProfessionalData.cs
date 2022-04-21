using Bogus;

namespace RefitVoorbeelden.Core;

public class ProfessionalData
{
    public List<Professional> Professional => new Faker<Professional>(locale: "nl")
        .RuleFor(professional => professional.FirstName, f => f.Person.FirstName)
        .RuleFor(professional => professional.LastName, f => f.Person.LastName)
        .RuleFor(professional => professional.EmailAddress, f => f.Person.Email)
        .RuleFor(professional => professional.Title, f => f.PickRandom<Title>())
        .RuleFor(professional => professional.Technologies, f => f.Random.ListItems(Enum.GetNames(typeof(Subject)), 3))
        .Generate(30);
}