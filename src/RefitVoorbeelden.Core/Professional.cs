namespace RefitVoorbeelden.Core;

public class Professional
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public Title Title { get; set; } 
    public List<string> Technologies { get; set; } = new();
}