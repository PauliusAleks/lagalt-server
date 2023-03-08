using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
    
    [Table("Contributor")]
    public class Contributor
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User ContributorName { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
