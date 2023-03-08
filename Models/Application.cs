namespace lagalt_back_end.Models
{
    /// <summary>
    ///   <see cref="Id" />
    ///   <br />
    ///   <see cref="State" />
    ///   <br />
    ///   <see cref="MotivationLetter" />
    ///   <br />
    ///   <see cref="User" />
    ///   <br />    
    ///   <see cref="Project" />
    ///   <br />
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public ApplicationState State { get; set; }
        /// <summary>
        /// Gets or sets the motivation letter.
        /// </summary>
        /// <value>
        /// The motivation letter.
        /// </value>
        public string MotivationLetter { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public virtual User User { get; set; }
        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        /// <value>
        /// The project.
        /// </value>
        public virtual Project Project { get; set; }
    }
    /// <summary>
    /// Application state.
    /// </summary>
    public enum ApplicationState
    {
        Pending,
        Accepted,
        Rejected
    }
}
