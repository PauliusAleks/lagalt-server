using lagalt_web_api.Models;
using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.DTO.ProjectDTO
{
    public class ProjectBannerDTO
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
        [MaxLength(50)]
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Progress { get; set; }
        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>
        /// The picture.
        /// </value>
        public List<int>? NeededSkillsId { get; set; }
    }
}
