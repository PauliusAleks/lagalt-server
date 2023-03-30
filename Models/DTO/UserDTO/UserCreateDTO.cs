using lagalt_web_api.Models;

namespace lagalt_web_api.Models.DTO.UserDTO
{
    /// <summary>
    /// DTO for creating a new user
    /// </summary>
    public class UserCreateDTO
    {
        /// <summary>
        /// The username of the new user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The first name of the new user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the new user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The email address of the new user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The portfolio URL of the new user
        /// </summary>
        public string? Portfolio { get; set; }

        /// <summary>
        /// Whether the new user is hidden from public view
        /// </summary>
        public bool? isHidden { get; set; }
    }
}
