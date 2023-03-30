using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace lagalt_web_api.Repositories.Interface
{
    /// <summary>
    /// The interface for the project repository, responsible for handling all database interaction for projects.
    /// </summary>
    public interface IProjectRepository : IRepository<Project>
    {
        /// <summary>
        /// Updates the settings of a project.
        /// </summary>
        /// <param name="id">The ID of the project to update.</param>
        /// <param name="projectEditDTO">The new project settings to apply.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task PutProjectSettings(int id, ProjectEditDTO projectEditDTO);

        /// <summary>
        /// Adds a contributor to a project.
        /// </summary>
        /// <param name="id">The ID of the project to add the contributor to.</param>
        /// <param name="contributorId">The ID of the contributor to add to the project.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task PutProjectContributor(int id, int contributorId);

        /// <summary>
        /// Adds an admin to a project.
        /// </summary>
        /// <param name="id">The ID of the project to add the admin to.</param>
        /// <param name="adminId">The ID of the admin to add to the project.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task PutProjectAdmin(int id, int adminId);

        /// <summary>
        /// Updates the image URL of a project.
        /// </summary>
        /// <param name="id">The ID of the project to update.</param>
        /// <param name="imageUrl">The new image URL to apply.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task PutProjectImageUrl(int id, string imageUrl);

        /// <summary>
        /// Adds a new project.
        /// </summary>
        /// <param name="projectCreateDTO">The information about the project to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task PostProject(ProjectCreateDTO projectCreateDTO);
    }
}
