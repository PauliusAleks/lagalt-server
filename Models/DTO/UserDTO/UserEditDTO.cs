using lagalt_web_api.Models;
namespace lagalt_web_api.Models.DTO.UserDTO
{
    /// <summary>
    /// Data Transfer Object for editing a user
    /// </summary>
    public class UserEditDTO
    {
        /// <summary>
        /// The user's ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user's portfolio URL
        /// </summary>
        public string? Portfolio { get; set; }

        /// <summary>
        /// Whether the user's profile is hidden or not
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// The list of skills associated with the user
        /// </summary>
        public virtual List<string>? Skills { get; set; }
    }
}
