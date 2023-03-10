using lagalt_web_api.Models.History;
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
    //[ForeignKey("SkillId")]
    public ICollection<Skill>? Skills { get; set; }
    //[ForeignKey("ApplicationId")]
    public virtual ICollection<Application>? Applications { get; set; }

    //public virtual Record Record { get; set; }
}
