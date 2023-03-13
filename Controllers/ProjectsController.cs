using Microsoft.AspNetCore.Mvc; 
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories; 
using lagalt_web_api.Models.DTO.ProjectDTO;

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
        public ActionResult<IEnumerable<ProjectBannerDTO>> GetProjects()
        {
            var projects = _repositories.Projects.GetAll();
            var projectsDTO = projects.Select(project => _mapper.Map<ProjectBannerDTO>(projects));
            return Ok(projects);
        }


        // GET: api/projects/5
        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An ProjectBannerDTO.</returns>
        [HttpGet("{id}")]
        public ActionResult<ProjectBannerDTO> GetProject(int id)
        {
            var project = _repositories.Projects.Get(id);

            if (project is null)
            {
                return NotFound();
            }

            return _mapper.Map<ProjectBannerDTO>(project);
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
        public IActionResult PutProject(int id, ProjectCreateDTO project)
        {
            if (!ProjectExists(id))
            {
                return NotFound();
            }
            if (project is null)
            {
                return BadRequest();
            }
            _repositories.Projects.Update(_mapper.Map<Project>(project));

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
            if (!ProjectExists(id))
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
        private bool ProjectExists(int id)
        {
            return _repositories.Projects.Get(id) is not null;
        }
    }
}
