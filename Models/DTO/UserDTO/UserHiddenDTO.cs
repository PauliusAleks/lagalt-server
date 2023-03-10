using lagalt_web_api.Models;
using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.DTO.UserDTO
{
    public class UserHiddenDTO
    {
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [MaxLength(50)]
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        //[MaxLength(50)]


    }
}
