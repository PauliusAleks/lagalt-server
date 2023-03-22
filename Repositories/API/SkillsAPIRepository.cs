using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.API;

class SkillsAPIRepository : ISkillsAPIRepository
{
    public IHttpClientFactory HttpClientFactory { get; }
    private string SkillsAPIBaseURL = "http://api.dataatwork.org/v1/";
    private string SkillsAPINormalizeJobTitleEndpoint = "jobs/normalize?job_title=";
    public SkillsAPIRepository(IHttpClientFactory httpClientFactory) {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<string> GetNormalizedJobTitle(string jobTitle="trouble maker")
    {
        var httpClient = HttpClientFactory.CreateClient();
        var skillsApiUri = new Uri( SkillsAPIBaseURL + SkillsAPINormalizeJobTitleEndpoint + jobTitle);
        var response = await httpClient.GetAsync(skillsApiUri);
        return response.Content.ToString() ?? ""; // Coalescing to quiet the linter.
    }
}