using lagalt_web_api.Models.History;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is hidden.
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// Gets or sets the portfolio.
        /// </summary>
        public string? Portfolio { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        public virtual ICollection<Skill>? Skills { get; set; }

        /// <summary>
        /// Gets or sets the applications.
        /// </summary>
        public virtual ICollection<Application>? Applications { get; set; }

        /// <summary>
        /// Gets or sets the admin projects.
        /// </summary>
        public virtual ICollection<Project> AdminProjects { get; set; }

        /// <summary>
        /// Gets or sets the contributor projects.
        /// </summary>
        public virtual ICollection<Project> ContributorProjects { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public virtual ICollection<UserMessage>? Messages { get; set; }
    }
}
