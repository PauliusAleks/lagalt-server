using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models;

/// <summary>
/// Enum indicating the project's progress.
/// </summary>
public enum ProgressState
{
    Oppstart, UnderUtvikling, Utsatt, Ferdig
}
/// <summary>
/// Enum indicating which category a project belongs to.
/// </summary>
public enum CategoryState
{
    Musikk, Film, SpillUtvikling, NettUtvikling
}
public class Project
{
    //CategoryState.Music.ToString(); // => "Music" 
    /// <summary>
    /// Gets or sets the project's identifier.
    /// </summary>
    /// <value>
    /// The project's identifier.
    /// </value>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the project's name.
    /// </summary>
    /// <value>
    /// The project's name.
    /// </value>
    [MaxLength(50)]
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the project's category.
    /// </summary>
    /// <value>
    /// The alias.
    /// </value>
    [EnumDataType(typeof(CategoryState))]
    public CategoryState Category { get; set; }
    /// <summary>
    /// Gets or sets the project's progress.
    /// </summary>
    /// <value>
    /// The project's progress.
    /// </value>
    [EnumDataType(typeof(ProgressState))]
    public ProgressState Progress { get; set; }
    /// <summary>
    /// Gets or sets the project's description.
    /// </summary>
    /// <value>
    /// The project's description.
    /// </value>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets the project's git URL.
    /// </summary>
    /// <value>
    /// The git URL.
    /// </value>
    [Url]
    public string? GitURL { get; set; }
    /// <summary>
    /// Gets or sets the project's image URL.
    /// </summary>
    /// <value>
    /// The project's image URL.
    /// </value
    ///Navigation Property
    public virtual ICollection<ImageUrl>? ImageURLs { get; set; }
    /// <summary>
    /// Gets or sets the project's needed skills.
    /// </summary>
    /// <value>
    /// The project's needed skills.
    /// </value
    ///Navigation Property
    public virtual ICollection<Skill>? NeededSkills { get; set; }
    /// <summary>
    /// Gets or sets the project's admins.
    /// </summary>
    /// <value>
    /// The admins.
    /// </value>
    ///Navigation Property
    public virtual ICollection<User>? Admins { get; set; }
    /// <summary>
    /// Gets or sets the project's contributors.
    /// </summary>
    /// <value>
    /// The project's contributors.
    /// </value>
    ///Navigation Property
    public virtual ICollection<User>? Contributors { get; set; }


}
