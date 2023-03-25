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
    public bool IsHidden { get; set; }
    public string? Portfolio { get; set; }
    public virtual ICollection<Skill>? Skills { get; set; }
    public virtual ICollection<Application>? Applications { get; set; }
    public virtual ICollection<Project> AdminProjects { get; set; }
    public virtual ICollection<Project> ContributorProjects { get; set; }
    public virtual ICollection<UserMessage>? Messages { get; set; }


    //public virtual Record Record { get; set; }
}
