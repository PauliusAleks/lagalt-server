using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using lagalt_web_api.Models.DTO.UserDTO;

namespace lagalt_web_api.Repositories.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AssignmentThree.Repositories.Database.IRepository&lt;AssignmentThree.Models.Project&gt;" />
    public interface IUserRepository : IRepository<User>
    {
        public Task PutUserSettingsId(int id, UserEditDTO userEditDTO);
        public Task PutUserSettingsUsername(string username, UserEditDTO userEditDTO);
    }
}