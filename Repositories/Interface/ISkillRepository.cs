using lagalt_web_api.Models;

namespace lagalt_web_api.Repositories.Interface
{
    /// <summary>
    /// Interface for the skill repository. Used for accessing and modifying skill data in the database.
    /// </summary>
    public interface ISkillRepository : IRepository<Skill>
    {
        // No additional members at the moment.
    }
}