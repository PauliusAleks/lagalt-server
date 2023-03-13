using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories
{

    public interface IRepositories 
    {
        IProjectRepository Projects { get; }
        IUserRepository Users { get; }
        IApplicationRepository Applications { get; }
        ISkillRepository Skills { get; }
        IImageURLRepository ImageURLs { get; } 
    }
}
