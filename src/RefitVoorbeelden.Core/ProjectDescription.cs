namespace RefitVoorbeelden.Core;

public class ProjectDescription
{
    public string Location { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public Title JobTitle { get; set; }
    public string Description { get; set; } = string.Empty;
}