using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
    [Table("Skill")]
    public class Skill
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string SkillName { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<User> Users { get; set; }
    }
}