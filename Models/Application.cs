using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models
{
    /// <summary>
    /// Represents an application to join a project.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Gets or sets the unique identifier for the application.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the state of the application (e.g. pending/ventende, accepted/akseptert, rejected/avvist).
        /// </summary>
        public ApplicationState State { get; set; }

        /// <summary>
        /// Gets or sets the motivation letter for the application.
        /// </summary>
        public string MotivationLetter { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who submitted the application.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user who submitted the application.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the ID of the project the application is for.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project the application is for.
        /// </summary>
        public virtual Project Project { get; set; }
    }

    /// <summary>
    /// Represents the possible states an application can be in.
    /// </summary>
    public enum ApplicationState
    {
        Ventende,
        Akseptert,
        Avvist
    }
}
