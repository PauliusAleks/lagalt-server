using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
    public class Contributor:User
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the contributer's projects (or projects which a user has contributed to if you will).
        /// </summary>
        /// <value>
        /// The contributer's projects.
        /// </value>
        public virtual ICollection<Project> Projects { get; set; }
    }
}
