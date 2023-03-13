using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models;


public class Skill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    
    //public int ProjectId { get; set; }
    //[ForeignKey("ProjectId")]
    public virtual ICollection<Project>? Projects { get; set; }

    //public int UserId { get; set; }
    //[ForeignKey("UserId")]
    public virtual ICollection<User>? Users { get; set; }
}