using System.ComponentModel.DataAnnotations;

namespace lagalt_back_end.Models
{
    public enum ProgressState
    {
        Founding, InProgress, Stalled, Completed
    }
    public enum CategoryState
    {
        Music, Film, GameDevelopment, WebDevelopment
    }
    public class Project
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
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
        [EnumDataType(typeof(CategoryState))]
        public CategoryState Category { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        [EnumDataType(typeof(ProgressState))]
        public ProgressState Progress { get; set; }
        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>
        /// The picture.
        /// </value>
        public string? Description { get; set; }
        [Url]
        public string? GitURL { get; set; }
        public ICollection<Url>? ImageURL { get; set; }
        public ICollection<Skill>? NeededSkills { get; set; }

        public ICollection<Admin> Admins { get; set; }
        public ICollection<Contributor> Contributors { get; set; }


    }
}
