using Microsoft.AspNetCore.Mvc;
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories;
using lagalt_web_api.Models.DTO.UserDTO;

namespace lagalt_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
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

        // GET: api/Users
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/hidden")]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsersWithHidden()
        {
            var users = _repositories.Users.GetAll();
            var usersDTO = users.Select(user => user.IsHidden ? new UserReadDTO { FirstName = user.FirstName } : _mapper.Map<UserReadDTO>(user));
            return Ok(usersDTO);
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
        [HttpPut("editUser/{id}")]
        public IActionResult PutUser(int id, UserCreateDTO user)
        {
            if (UserExists(id) == null)
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
        [HttpPost("createUser")]
        public ActionResult<UserCreateDTO> PostUser(UserCreateDTO user)
        {
            if (user is null)
            {
                return BadRequest("user is null.");
            }
            var createdUser = _repositories.Users.Create(_mapper.Map<User>(user));

            return Ok(createdUser);
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
            try
            {
                var user = _repositories.Users.Delete(new Models.User { Id = id });
                return Ok(_mapper.Map<UserReadDTO>(user));
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Project existence check.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Wether project exists or not.</returns>
        private User UserExists(int id)
        {
            return _repositories.Users.Get(id);
        }
    }
}
