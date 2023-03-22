namespace lagalt_web_api.Repositories.API
{
    public interface ISkillsAPIRepository
    {
        Task<List<string>> GetSkillTitles(string jobTitle);
    }
}
