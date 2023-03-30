using lagalt_web_api.Models;

namespace lagalt_web_api.Repositories.Interface
{
    /// <summary>
    /// Interface for the user message repository. Used for accessing and modifying user messages in the database.
    /// </summary>
    public interface IUserMessageRepository : IRepository<UserMessage>
    {
        // No additional members at the moment.
    }
}
