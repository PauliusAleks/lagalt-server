using lagalt_web_api.Models.LinkerModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models;


public class ImageUrl
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Url { get; set; } 
    public virtual ICollection<ProjectImageUrl> ProjectImageUrls { get; set; }
}