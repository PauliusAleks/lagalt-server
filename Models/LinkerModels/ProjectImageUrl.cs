using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.LinkerModels
{
    public class ProjectImageUrl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public Project Project { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        [NotMapped]
        public ImageUrl ImageURL { get; set; }
        [ForeignKey("ImageURLId")]
        public int ImageURLId { get; set; }
    }
}
