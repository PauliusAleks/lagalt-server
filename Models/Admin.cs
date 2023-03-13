using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models;

public class Admin:User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the admin's project (the projects where the user is an administrator).
    /// </summary>
    /// <value>
    /// The administrator's projects.
    /// </value>
    public virtual ICollection<Project> Projects { get; set; }
}
