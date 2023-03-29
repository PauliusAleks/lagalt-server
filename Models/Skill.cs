using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models;

/// <summary>
/// Represents a skill that can be associated with both projects and users.
/// </summary>
public class Skill
{
    /// <summary>
    /// Gets or sets the skill identifier.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the skill.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the collection of projects associated with this skill.
    /// </summary>
    public virtual ICollection<Project>? Projects { get; set; }

    /// <summary>
    /// Gets or sets the collection of users associated with this skill.
    /// </summary>
    public virtual ICollection<User>? Users { get; set; }

    /// <summary>
    /// Returns a string representation of the skill.
    /// </summary>
    /// <returns>The name of the skill.</returns>
    public override string ToString()
    {
        return Name;
    }
}
