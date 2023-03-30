using lagalt_web_api.Models;
using lagalt_web_api.Repositories.Interface;

namespace lagalt_web_api.Repositories.Database
{
    /// <summary>
    /// A repository class for accessing and modifying UserMessage data in the database.
    /// </summary>
    public class DbUserMessageRepository : DbRepository<UserMessage>, IUserMessageRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbUserMessageRepository"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public DbUserMessageRepository(IConfiguration config) : base(config)
        {
            // Empty constructor
        }
    }
}
