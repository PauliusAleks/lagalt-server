using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
    [Table("Url")]
    public class Url
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}