using Microsoft.AspNetCore.Mvc;
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories;
using Microsoft.EntityFrameworkCore;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO;

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
        [HttpGet]
        public ActionResult<IEnumerable<ProjectBannerDTO>> GetProjectBanners()
        {
            return _mapper.Map<List<ProjectBannerDTO>>(_repositories.Projects.GetAll()
                .Include(pr => pr.NeededSkills));
        }

        // GET: api/Projects
        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        [HttpGet("project/admin/{id}")]
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

        [HttpGet("project/{id}")]
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
        /// Puts the project.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="project">The project.</param>
        /// <returns>Action result.</returns>
        [HttpPut("{id}")]
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
            await _repositories.Projects.PutProjectSettings(id, projectDTO.NeededSkillsName.ToList(), projectDTO.ImageUrls.ToList());

            return NoContent();
        }

        // POST: api/projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posts the projects.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The ProjectCreateDTO.</returns>
        [HttpPost]
        public ActionResult<ProjectCreateDTO> PostProject(ProjectCreateDTO project)
        {
            if (project is null)
            {
                return BadRequest("project is null.");
            }
            _repositories.Projects.Create(_mapper.Map<Project>(project));

            return CreatedAtAction("GetProject", project);
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
