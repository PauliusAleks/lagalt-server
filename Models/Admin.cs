using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace lagalt_web_api.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        [NotMapped]
        public virtual ICollection<Project> Project { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [NotMapped]
        public virtual ICollection<User> User { get; set; }

    }
}
