using Microsoft.AspNetCore.Mvc;
using lagalt_web_api.Models;
using AutoMapper;
using lagalt_web_api.Repositories;
using lagalt_web_api.Models.DTO.UserDTO;
using lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO;
using Microsoft.EntityFrameworkCore;

namespace lagalt_web_api.Controllers
{
    /// <summary>
    /// Controller for handling User-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")]
    [Consumes("Application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IRepositories _repositories;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="repositories">The repositories instance.</param>
        /// <param name="mapper">The IMapper instance.</param>
        public UsersController(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of UserReadDTO objects.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsers()
        {
            var users = _repositories.Users.GetAll().Include(u => u.Skills)
               .Include(u => u.AdminProjects)
               .Include(u => u.ContributorProjects);
            var usersDTO = users.Select(user => _mapper.Map<UserReadDTO>(user));
            return Ok(usersDTO);
        }

        /// <summary>
        /// Retrieves all projects that a user has contributed to.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>A list of ProjectBannerDTO objects.</returns>
        [HttpGet("{id}/contributorProjects")]
        public ActionResult<IEnumerable<ProjectBannerDTO>> GetContributorProjects(int id)
        {
            return _mapper.Map<List<ProjectBannerDTO>>(_repositories.Projects.GetAll().Include(pr => pr.ImageURLs).Include(pr => pr.NeededSkills)
                .Where(pr => pr.Contributors.Contains(_repositories.Users.Get(id))));
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


        /// <summary>
        /// Retrieves a user by id.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>An UserReadDTO object.</returns>
        [HttpGet("id/{id}")]
        public ActionResult<UserReadDTO> GetUser(int id)
        {
            var userDTO = _mapper.Map<UserReadDTO>(_repositories.Users.GetAll()
               .Include(u => u.Skills)
               .Include(u => u.AdminProjects)
               .Include(u => u.ContributorProjects)
               .Where(u => u.Id == id)
               .FirstOrDefault());

            if (userDTO is null)
            {
                return NotFound();
            }

            return userDTO;
        }

        /// <summary>
        /// Retrieves a user by username.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>An UserReadDTO object.</returns>
        [HttpGet("username/{username}")]
        public ActionResult<UserReadDTO> GetUser(string username)
        {
            var userDTO = _mapper.Map<UserReadDTO>(_repositories.Users.GetAll()
               .Include(u => u.Skills)
               .Include(u => u.AdminProjects)
               .Include(u => u.ContributorProjects)
               .Where(u => u.Username == username)
               .FirstOrDefault());

            if (userDTO is null)
            {
                return NotFound();
            }

            return userDTO;
        }

        /// <summary>
        /// Checks if a user exists.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>True if the user exists, false otherwise.</returns>
        [HttpGet("userExists/{username}")]
        public ActionResult<bool> UserExists(string username)
        {
            var userDTO = _mapper.Map<UserReadDTO>(_repositories.Users.GetAll()
               .Where(u => u.Username == username)
               .FirstOrDefault());

            if (userDTO is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Updates a user by ID using HTTP PUT with the user's ID provided in the URL.
        /// </summary>
        /// <param name="id">The ID of the user to be updated.</param>
        /// <param name="userDTO">The user DTO containing the new user information.</param>
        /// <returns>An HTTP action result indicating the success or failure of the operation.</returns>
        [HttpPut("editWithId/{id}")]
        public async Task<IActionResult> PutUserById(int id, UserEditDTO userDTO) // TODO: fix
        {
            if (UserExists(userDTO.Id) == null)
            {
                return NotFound();
            }
            if (userDTO is null)
            {
                return BadRequest();
            }
            await _repositories.Users.PutUserSettingsId(id, userDTO);

            return NoContent();
        }

        /// <summary>
        /// Updates a user by username using HTTP PUT with the user's username provided in the URL.
        /// </summary>
        /// <param name="username">The username of the user to be updated.</param>
        /// <param name="userDTO">The user DTO containing the new user information.</param>
        /// <returns>An HTTP action result indicating the success or failure of the operation.</returns>
        [HttpPut("editWithUsername/{username}")]
        public async Task<IActionResult> PutUserByUsername(string username, UserEditDTO userDTO)
        {
            if (UserExists(userDTO.Id) == null)
            {
                return NotFound();
            }
            if (userDTO is null)
            {
                return BadRequest();
            }
            await _repositories.Users.PutUserSettingsUsername(username, userDTO);

            return NoContent();
        }



        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new user using HTTP POST.
        /// </summary>
        /// <param name="user">The user DTO containing the new user information.</param>
        /// <returns>An HTTP action result containing the newly created user DTO.</returns>
        [HttpPost("CreateUser")]
        public ActionResult<UserCreateDTO> PostUser(UserCreateDTO user)
        {
            if (user is null)
            {
                return BadRequest("user is null.");
            }
            var createdUser = _repositories.Users.Create(_mapper.Map<User>(user));

            return Ok(createdUser);
        }

        /// <summary>
        /// Deletes the user with the specified ID using HTTP DELETE.
        /// </summary>
        /// <param name="id">The ID of the user to be deleted.</param>
        /// <returns>An HTTP action result indicating the success or failure of the operation.</returns>
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
        /// Checks whether a user with the specified ID exists.
        /// </summary>
        /// <param name="id">The ID of the user to check for existence.</param>
        /// <returns>The user if they exist.</returns>
        private User UserExists(int id)
        {
            return _repositories.Users.Get(id);
        }
    }
}
