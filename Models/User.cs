using lagalt_web_api.Models.History;
using lagalt_web_api.Models.LinkerModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models;


public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }

    public bool UserStatus { get; set; }
    public string? Portofolio { get; set; }

    [NotMapped]
    public virtual ICollection<Skill>? Skills { get; set; }

    public virtual ICollection<Application>? Applications { get; set; }

    public virtual ICollection<Admin>? Admins { get; set; }
    public virtual ICollection<Contributor>? Contributors { get; set; }
    public virtual ICollection<UserSkill> UserSkills { get; set; }

    //public virtual Record Record { get; set; }
}
