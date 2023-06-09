﻿using Microsoft.AspNetCore.Mvc;
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories;
using Microsoft.EntityFrameworkCore;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO;
using lagalt_web_api.Models.DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;

namespace lagalt_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class ProjectsController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IRepositories _repositories;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsController"/> class.
        /// </summary>
        /// <param name="repositories">The context.</param>
        /// <param name="mapper">The mapper.</param>

        public ProjectsController(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the project banners.
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("banners")]
        public ActionResult<IEnumerable<ProjectBannerDTO>> GetProjectBanners()
        {
            var projects = _repositories.Projects.GetAll()
                    .Include(pr => pr.NeededSkills)
                    .Include(pr => pr.ImageURLs);

            return _mapper.Map<List<ProjectBannerDTO>>(projects);
        }

        /// <summary>
        /// Gets all contributors in a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/contributors")]
        public ActionResult<IEnumerable<UserReadDTO>> GetProjectContributors(int id)
        {
            return _mapper.Map<List<UserReadDTO>>(_repositories.Users.GetAll()
                .Where(us => us.ContributorProjects.Contains(_repositories.Projects.Get(id))));
        }

        /// <summary>
        /// Gets all admins in a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/admins")]
        public ActionResult<IEnumerable<UserReadDTO>> GetProjectAdmins(int id)
        {
            return _mapper.Map<List<UserReadDTO>>(_repositories.Users.GetAll()
                .Where(us => us.AdminProjects.Contains(_repositories.Projects.Get(id))));
        }

        // GET: api/Projects
        /// <summary>
        /// Gets the admin project - ProjectAdminDTO.
        /// </summary>
        /// <returns></returns>
        [HttpGet("admin/{id}")]
        public ActionResult<ProjectAdminDTO> GetAdminProject(int id)
        {
            var projectDTO = _mapper.Map<ProjectAdminDTO>(_repositories.Projects.GetAll()
                .Include(pr => pr.NeededSkills)
                .Include(pr => pr.ImageURLs)
                .Include(pr => pr.Admins)
                .Include(pr => pr.Contributors)
                .Where(pr => pr.Id == id)
                .FirstOrDefault());

            if (projectDTO is null)
            {
                return NotFound();
            }

            return projectDTO;
        }

        /// <summary>
        /// Get project by id - response is set to ProjectPageDTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("contributor/{id}")]
        public ActionResult<ProjectPageDTO> GetProjectPage(int id)
        {
            var projectDTO = _mapper.Map<ProjectPageDTO>(_repositories.Projects.GetAll()
               .Include(pr => pr.NeededSkills)
               .Include(pr => pr.ImageURLs)
               .Include(pr => pr.Contributors)
               .Where(pr => pr.Id == id)
               .FirstOrDefault());

            if (projectDTO is null)
            {
                return NotFound();
            }

            return projectDTO;
        }

        /// <summary>
        /// Update project by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="project">The project.</param>
        /// <returns>Action result.</returns>
        [HttpPut("updateProject/{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectEditDTO projectDTO)
        {
            if (ProjectExists(projectDTO.Id) == null)
            {
                return NotFound();
            }
            if (projectDTO is null)
            {
                return BadRequest();
            }
            await _repositories.Projects.PutProjectSettings(id, projectDTO);

            return NoContent();
        }

        /// <summary>
        /// Update contributors in project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut("{projectId}/addContributor")]
        public async Task<IActionResult> AddContributorToProject(int projectId, int userId)
        {
            if (ProjectExists(projectId) == null)
            {
                return NotFound();
            }

            await _repositories.Projects.PutProjectContributor(projectId, userId);

            return NoContent();
        }

        /// <summary>
        /// Update admins in project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut("{projectId}/addAdmin")]
        public async Task<IActionResult> AddAdminToProject(int projectId, int userId)
        {
            if (ProjectExists(projectId) == null)
            {
                return NotFound();
            }

            await _repositories.Projects.PutProjectAdmin(projectId, userId);

            return NoContent();
        }

        /// <summary>
        /// Posts the projects.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The ProjectCreateDTO.</returns>
        [HttpPost("createProject")]
        public async Task<ActionResult<ProjectAdminDTO>> PostProject(ProjectCreateDTO projectDTO)
        {
            if (projectDTO is null)
            {
                return BadRequest("project is null.");
            }
            await _repositories.Projects.PostProject(projectDTO);

            return _mapper.Map<ProjectAdminDTO>(await _repositories.Projects.GetAll().Where(pr => pr.Name == projectDTO.Name).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Update image in a project with given id
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        [HttpPut("{projectId}/addImageUrl")]
        public async Task<IActionResult> PutImageInProject(int projectId, string imageUrl)
        {
            if (ProjectExists(projectId) is null)
            {
                return BadRequest("project is null.");
            }
            await _repositories.Projects.PutProjectImageUrl(projectId, imageUrl);

            return Ok();
        }
        // DELETE: api/projects/5
        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The action result.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var projects = _repositories.Projects.Get(id);
            if (ProjectExists(id) == null)
            {
                return NotFound();
            }
            _repositories.Projects.Delete(projects);
            return NoContent();
        }


        /// <summary>
        /// Project existence check.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Wether project exists or not.</returns>
        private Project ProjectExists(int id)
        {
            return _repositories.Projects.Get(id);
        }
    }
}
