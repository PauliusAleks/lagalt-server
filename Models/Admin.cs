using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
    public class Admin:User
    {
        /// <summary>
        /// Gets or sets the admin's project (the projects where the user is an administrator).
        /// </summary>
        /// <value>
        /// The administrator's projects.
        /// </value>
        public virtual ICollection<Project> Projects { get; set; }
    }
}
