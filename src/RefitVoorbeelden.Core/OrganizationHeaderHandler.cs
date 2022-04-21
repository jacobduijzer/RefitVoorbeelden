namespace RefitVoorbeelden.Core;

public class OrganizationHeaderHandler : DelegatingHandler
{
    public OrganizationHeaderHandler() => InnerHandler = new HttpClientHandler();
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("X-Employer", "Team Rockstars IT, Happy Developers, High Impact!");
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    } 
}