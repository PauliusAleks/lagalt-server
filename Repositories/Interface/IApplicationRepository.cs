using lagalt_web_api.Models;

namespace lagalt_web_api.Repositories.Interface
{
    /// <summary>
    /// Interface for the application repository. Used for accessing and modifying application data in the database.
    /// </summary>
    public interface IApplicationRepository : IRepository<Application>
    {
        // No additional members at the moment
    }
}