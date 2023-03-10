using lagalt_web_api.Repositories.Interface;

namespace lagalt_back_end.Repositories
{

    public interface IRepositories 
    {
        IProjectRepository Projects { get; }
        IUserRepository Users { get; }
        IApplicationRepository Applications { get; }
        ISkillRepository Skills { get; }
        IImageURLRepository ImageURLs { get; }
        IAdminRepository Admins { get; }
        IContributorRepository Contributors { get; } 
    }
}
