using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using lagalt_web_api.Models.DTO.UserDTO;

namespace lagalt_web_api.Repositories.Interface
{
    /// <summary>
    /// Interface for the user repository. Used for accessing and modifying user data in the database.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Updates the user settings for the user with the specified id.
        /// </summary>
        /// <param name="id">The user id.</param>
        /// <param name="userEditDTO">The user data to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task PutUserSettingsId(int id, UserEditDTO userEditDTO);

        /// <summary>
        /// Updates the user settings for the user with the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="userEditDTO">The user data to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task PutUserSettingsUsername(string username, UserEditDTO userEditDTO);
    }
}
