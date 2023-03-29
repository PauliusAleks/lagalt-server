using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    /// <summary>
    /// Repository for accessing and modifying Skill data in the database.
    /// Inherits from the generic DbRepository and implements the ISkillRepository interface.
    /// </summary>
    public class DbSkillRepository : DbRepository<Skill>, ISkillRepository
    {
        /// <summary>
        /// Constructor that takes an IConfiguration object and passes it to the constructor of the base class.
        /// </summary>
        /// <param name="config">The IConfiguration object to be passed to the constructor of the base class.</param>
        public DbSkillRepository(IConfiguration config) : base(config)
        {

        }
    }
}
