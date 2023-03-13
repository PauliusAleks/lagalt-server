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
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>
        /// The alias.
        /// </value>
        public CategoryState Category { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public ProgressState Progress { get; set; }
        ///// <summary>
        ///// Gets or sets the picture.
        ///// </summary>
        ///// <value>
        ///// The picture.
        ///// </value>
        //public virtual ICollection<Skill>? SkillsNav { get; set; }
    }
}
