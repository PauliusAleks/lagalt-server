using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models
{
    /// <summary>
    /// Represents a user message.
    /// </summary>
    public class UserMessage
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user who sent the message.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project associated with the message.
        /// </summary>
        public Project Project { get; set; }
    }
}
