using lagalt_web_api.Models;

namespace lagalt_web_api.Models.DTO.UserDTO
{
    /// <summary>
    /// Data transfer object representing a user with read-only access.
    /// </summary>
    public class UserReadDTO
    {
        /// <summary>
        /// The user's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The user's portfolio URL.
        /// </summary>
        public string? Portfolio { get; set; }

        /// <summary>
        /// Whether the user's profile is hidden.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// The user's list of skills.
        /// </summary>
        public List<string>? Skills { get; set; }

        /// <summary>
        /// The IDs of the projects the user is a contributor to.
        /// </summary>
        public List<int> ContributorProjects { get; set; }

        /// <summary>
        /// The IDs of the projects the user is an admin of.
        /// </summary>
        public List<int> AdminProjects { get; set; }
    }
}
