using lagalt_web_api.Models;
using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.DTO.ProjectDTO
{
    public class ProjectBannerDTO
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [MaxLength(50)]
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        /// <value>
        /// The progress.
        /// </value>
        public string Progress { get; set; }
        /// <summary>
        /// Gets or sets the NeededSkillsName.
        /// </summary>
        /// <value>
        /// The NeededSkillsName.
        /// </value>
        public List<string>? NeededSkillsName { get; set; }
    }
}
