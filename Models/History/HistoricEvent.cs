using lagalt_web_api.Models;
using lagalt_web_api.Models.History;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
 
    /// <summary>
    /// Model for the History table
    /// </summary>
    [Table("History")]
    public class HistoricEvent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the project event.
        /// </summary>
        /// <value>
        /// The project event.
        /// </value>
        //public virtual ProjectEvent ProjectEvent { get; set; }
    }
}
