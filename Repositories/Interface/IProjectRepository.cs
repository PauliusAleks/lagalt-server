using lagalt_web_api.Models;
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
        public Task PutProjectSettings(int id, List<string> neededSkills, List<string> imageUrls);
    }
}