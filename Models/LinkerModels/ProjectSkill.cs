using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.LinkerModels
{
    public class ProjectSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public virtual Project Project { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        [NotMapped]
        public virtual Skill Skill { get; set; }
        [ForeignKey("SkillId")]
        public int SkillId { get; set; }
    }
}
