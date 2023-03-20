using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using Microsoft.AspNetCore.Mvc;

namespace lagalt_web_api.Repositories.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AssignmentThree.Repositories.Database.IRepository&lt;AssignmentThree.Models.Project&gt;" />
    public interface IProjectRepository : IRepository<Project>
    {
        public Task PutProjectSettings(int id, ProjectEditDTO projectEditDTO);
        public Task PutProjectContributor(int id, int contributorId);
        public Task PutProjectAdmin(int id, int adminId);
        public Task PutProjectImageUrl(int id, string imageUrl);
        public Task PostProject(ProjectCreateDTO projectCreateDTO);
    }
}