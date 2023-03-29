using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models;

/// <summary>
/// Represents a URL to an image.
/// </summary>
public class ImageUrl
{
    /// <summary>
    /// Gets or sets the identifier of the image URL.
    /// </summary>
    /// <value>
    /// The identifier of the image URL.
    /// </value>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the URL of the image.
    /// </summary>
    /// <value>
    /// The URL of the image.
    /// </value>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the collection of projects associated with this image URL.
    /// </summary>
    /// <value>
    /// The collection of projects associated with this image URL.
    /// </value>
    public virtual ICollection<Project>? Projects { get; set; }
}
