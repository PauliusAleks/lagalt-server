using Microsoft.AspNetCore.Mvc;
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

        // GET: api/Projects
        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("getProjectBanners")]
        public ActionResult<IEnumerable<ProjectBannerDTO>> GetProjectBanners()
        {
            var projects = _repositories.Projects.GetAll();
            var withSkills = projects.Include(pr => pr.NeededSkills);
            var withImageUrls = withSkills.Include(pr => pr.ImageURLs);
            return _mapper.Map<List<ProjectBannerDTO>>(withImageUrls);
        }

        /// <summary>
        /// Gets all contributors in a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getContributorsInProject/{id}")]
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
        [HttpGet("getAdminsInProject/{id}")]
        public ActionResult<IEnumerable<UserReadDTO>> GetProjectAdmins(int id)
        {
            return _mapper.Map<List<UserReadDTO>>(_repositories.Users.GetAll()
                .Where(us => us.AdminProjects.Contains(_repositories.Projects.Get(id))));
        }

        // GET: api/Projects
        /// <summary>
        /// Gets the admin project.
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
        /// Get project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
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

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        [HttpPut("addContributor/{projectId}")]
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
        [HttpPut("addAdmin/{projectId}")]
        public async Task<IActionResult> AddAdminToProject(int projectId, int userId)
        {
            if (ProjectExists(projectId) == null)
            {
                return NotFound();
            }

            await _repositories.Projects.PutProjectAdmin(projectId, userId);

            return NoContent();
        }

        // POST: api/projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posts the projects.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The ProjectCreateDTO.</returns>
        [HttpPost("createProject")]
        public ActionResult<ProjectCreateDTO> PostProject(ProjectCreateDTO projectDTO)
        {
            if (projectDTO is null)
            {
                return BadRequest("project is null.");
            }
            var createdProject = _repositories.Projects.Create(_mapper.Map<Project>(projectDTO));

            return Ok(createdProject);
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
