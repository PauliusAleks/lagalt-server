using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.LinkerModels
{
    public class UserSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public virtual User User { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [NotMapped]
        public virtual Skill Skill { get; set; }
        [ForeignKey("SkillId")]
        public int SkillId { get; set; }
    }
}
