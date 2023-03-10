using lagalt_web_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models.History;


public abstract class Record
{ 

    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the name of the event.
    /// </summary>
    /// <value>
    /// The event name.
    /// </value>
    public virtual string Name { get; set; }
    /// <summary>
    /// Gets or sets the description of the event.
    /// </summary>
    /// <value>
    /// The event description.
    /// </value>
    public virtual string Description { get; set; }
    /// <summary>
    /// Gets the user who triggered the project event.
    /// </summary>
    /// <value>
    /// The user.
    /// </value>
    [ForeignKey("FK_RecordUser")]
    public User User { get; set; }
    /// <summary>
    /// Gets or sets the project (gotta set project's on-delete to a default value, which should be the projects name, then the user will still have access to his logs regardless of the project's existence and still have access to its name).
    /// </summary>
    /// <value>
    /// The project which the event emitted from.
    /// </value>
    [ForeignKey("FK_RecordProject")]
    public Project Project { get; set; }
    /// <summary>
    /// Gets or sets the project event's time.
    /// </summary>
    /// <value>
    /// The project event's date time.
    /// </value>
    public DateTime DateTime { get; set; }
}
