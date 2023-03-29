using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lagalt_web_api.Data;
using lagalt_web_api.Models;
using lagalt_web_api.Models.DTO.UserDTO;
using lagalt_web_api.Models.DTO.ApplicationDTO;
using AutoMapper;
using lagalt_web_api.Repositories;

namespace lagalt_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class ApplicationsController : ControllerBase
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

        public ApplicationsController(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        //GET: api/Applications
        /// <summary>
        /// Get all applications in project.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllApplicationsInProject/{id}")]
        public ActionResult<IEnumerable<ApplicationReadDTO>> GetApplicationsInProject(int id)
        {
            return _mapper.Map<List<ApplicationReadDTO>>(_repositories.Applications.GetAll()
                .Where(us => us.ProjectId == _repositories.Projects.Get(id).Id));
        }
        /// <summary>
        /// Creates an application
        /// </summary>
        /// <param name="applicationDTO"></param>
        /// <returns></returns>
        [HttpPost("createApplication")]
        public ActionResult<ApplicationCreateDTO> PostApplication(ApplicationCreateDTO applicationDTO)
        {
            if (applicationDTO is null)
            {
                return BadRequest("application is null.");
            }
            var createdApplication = _repositories.Applications.Create(_mapper.Map<Application>(applicationDTO));

            return Ok(createdApplication);
        }
        /// <summary>
        /// Deletes an application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteApplication(int id)
        {
            var application = _repositories.Applications.Get(id);
            if (ApplicationExists(id) == null)
            {
                return NotFound();
            }
            _repositories.Applications.Delete(application);
            return NoContent();
        }
        /// <summary>
        /// Accepts an application and sets its state to accepted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("accept/{id}")]
        public IActionResult ChangeApplicationStateToAccepted(int id)
        {
            var application = _repositories.Applications.Get(id);
            if (ApplicationExists(id) == null)
            {
                return NotFound();
            }
            application.State = ApplicationState.Akseptert;
            _repositories.Projects.PutProjectContributor(application.ProjectId, application.UserId);
            _repositories.Applications.Update(application);
            return NoContent();
        }
        /// <summary>
        /// Rejects an application and sets its state to rejected
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("reject/{id}")]
        public IActionResult ChangeApplicationStateToRejected(int id)
        {
            var application = _repositories.Applications.Get(id);
            if (ApplicationExists(id) == null)
            {
                return NotFound();
            }
            application.State = ApplicationState.Avvist;
            _repositories.Applications.Update(application);
            return NoContent();
        }
        /// <summary>
        /// Application existence check.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Wether application exists or not.</returns>
        private Application ApplicationExists(int id)
        {
            return _repositories.Applications.Get(id);
        }
    }
}

