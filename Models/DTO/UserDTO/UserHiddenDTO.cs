using lagalt_web_api.Models;
using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.DTO.UserDTO
{
    public class UserHiddenDTO
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [MaxLength(30)]
        public string Username { get; set; }
    }
}
