using lagalt_web_api.Models.LinkerModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models;


public class Skill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    [NotMapped]
    public virtual ICollection<Project>? Projects { get; set; }
    [NotMapped]
    public virtual ICollection<User>? Users { get; set; }

    public virtual ICollection<ProjectSkill> ProjectSkills { get; set; }
    public virtual ICollection<UserSkill> UserSkills { get; set; }
}