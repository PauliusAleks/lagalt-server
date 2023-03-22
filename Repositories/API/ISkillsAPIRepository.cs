namespace lagalt_web_api.Repositories.API
{
    public interface ISkillsAPIRepository
    {
        Task<string> GetNormalizedJobTitle(string jobTitle);
    }
}
