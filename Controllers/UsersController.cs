using Microsoft.AspNetCore.Mvc;
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories;
using lagalt_web_api.Models.DTO.UserDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO;
using Microsoft.EntityFrameworkCore;

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
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsers()
        {
            var users = _repositories.Users.GetAll().Include(u => u.Skills);
            var usersDTO = users.Select(user => _mapper.Map<UserReadDTO>(user));
            return Ok(usersDTO);
        }

        //// GET: api/Users
        ///// <summary>
        ///// Get hidden users.
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("/hidden")]
        //public ActionResult<IEnumerable<UserReadDTO>> GetUsersWithHidden()
        //{
        //    var users = _repositories.Users.GetAll();
        //    var usersDTO = users.Select(user => user.IsHidden ? new UserReadDTO { FirstName = user.FirstName } : _mapper.Map<UserReadDTO>(user));
        //    return Ok(usersDTO);
        //}


        // GET: api/users/5
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An UserReadDTO.</returns>
        [HttpGet("{id}")]
        public ActionResult<UserReadDTO> GetUser(int id)
        {
            var userDTO = _mapper.Map<UserReadDTO>(_repositories.Users.GetAll()
               .Include(u => u.Skills)
               .Where(u => u.Id == id)
               .FirstOrDefault());

            if (userDTO is null)
            {
                return NotFound();
            }

            return userDTO;
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("get/{username}")]
        public ActionResult<UserReadDTO> GetUser(string username)
        {
            var userDTO = _mapper.Map<UserReadDTO>(_repositories.Users.GetAll()
               .Include(u => u.Skills)
               .Where(u => u.Username == username)
               .FirstOrDefault());

            if (userDTO is null)
            {
                return NotFound();
            }

            return userDTO;
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
        public IActionResult PutUser(int id, UserEditDTO userDTO) // TODO: fix
        {
            if (UserExists(id) == null)
            {
                return NotFound();
            }
            if (userDTO is null)
            {
                return BadRequest();
            }
            var mapped = _mapper.Map<User>(userDTO);
            _repositories.Users.Update(mapped);

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
