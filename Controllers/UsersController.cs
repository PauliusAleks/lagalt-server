using Microsoft.AspNetCore.Mvc;
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories;
using lagalt_web_api.Models.DTO.UserDTO;
using System.Net.Mime;

namespace lagalt_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UsersController : ControllerBase
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

        public UsersController(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        // GET: api/Users
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsers()
        {
            var users = _repositories.Users.GetAll();
            var usersDTO = users.Select(user => _mapper.Map<UserReadDTO>(users));
            return Ok(users);
        }


        // GET: api/users/5
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An UserReadDTO.</returns>
        [HttpGet("{id}")]
        public ActionResult<UserReadDTO> GetUser(int id)
        {
            var user = _repositories.Users.Get(id);

            if (user is null)
            {
                return NotFound();
            }

            return _mapper.Map<UserReadDTO>(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>Action result.</returns>
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserCreateDTO user)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            if (user is null)
            {
                return BadRequest();
            }
            _repositories.Users.Update(_mapper.Map<User>(user));

            return NoContent();
        }

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Posts the users.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The UserCreateDTO.</returns>
        [HttpPost]
        public ActionResult<UserCreateDTO> PostUser(UserCreateDTO user)
        {
            if (user is null)
            {
                return BadRequest("user is null.");
            }
            _repositories.Users.Create(_mapper.Map<User>(user));

            return CreatedAtAction("GetUser", user);
        }

        // DELETE: api/users/5
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The action result.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var users = _repositories.Users.Get(id);
            if (!UserExists(id))
            {
                return NotFound();
            }
            _repositories.Users.Delete(users);
            return NoContent();
        }

        /// <summary>
        /// Project existence check.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Wether project exists or not.</returns>
        private bool UserExists(int id)
        {
            return _repositories.Users.Get(id) is not null;
        }
    }
}
