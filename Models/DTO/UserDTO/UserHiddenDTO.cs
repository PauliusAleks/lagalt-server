using lagalt_back_end.Models;
using System.ComponentModel.DataAnnotations;

namespace lagalt_back_end.Models.DTO
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
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        //[MaxLength(50)]


    }
}
