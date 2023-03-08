using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lagalt_back_end.Models;
using lagalt_back_end.Data;
using lagalt_back_end.Repositories;
using AutoMapper;
using lagalt_back_end.Models.DTO;
using System.Net.Mime;

namespace lagalt_back_end.Controllers
{
    /// <summary>
    /// Web API endpoint for Projetcs.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProjectsController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly IRepositoryWrapper _context;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public ProjectsController(IRepositoryWrapper context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Projetcs
        /// <summary>
        /// Gets the projects.
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public ActionResult<IEnumerable<ProjectDTO>> GetProject()
        {
            var projects = _context.Projects.GetAll();
            var projectsDTO = projects.Select(project => _mapper.Map<ProjectDTO>(projects));
            return projectsDTO.ToList();
        }

        // GET: api/projects/5
        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A ProjectDTO.</returns>
        [HttpGet("{id}")] 
        public ActionResult<ProjectDTO> GetProject(int id)
        {
            var project = _context.Projects.Get(id);

            if (project is null)
            {
                return NotFound();
            }

            return _mapper.Map<ProjectDTO>(project);
        }

        // PUT: api/projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Puts the project.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="project">The project.</param>
        /// <returns>Action result.</returns>
        [HttpPut("{id}")] 
        public IActionResult PutProject(int id, ProjectDTO project)
        {
            if (!ProjectExists(id))
            {
                return NotFound();
            }
            if ( project is null)
            {
                return BadRequest();
            }
            _context.Projects.Update(_mapper.Map<Project>(project));

            return NoContent();
        }

        // POST: api/projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posts the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>The ProjectDTO.</returns>
        [HttpPost] 
        public ActionResult<ProjectDTO> PostProject(ProjectDTO project)
        {
            if (project is null)
            {
                return BadRequest("project is null.");
            }
            _context.Projects.Create(_mapper.Map<Project>(project));

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
            var projects = _context.Projects.Get(id);
            if (!ProjectExists(id))
            {
                return NotFound();
            }
            _context.Projects.Delete(projects);
            return NoContent();
        }

        /// <summary>
        /// Project existence check.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Wether project exists or not.</returns>
        private bool ProjectExists(int id)
        {
            return _context.Projects.Get(id) is not null;
        }
    }
}
