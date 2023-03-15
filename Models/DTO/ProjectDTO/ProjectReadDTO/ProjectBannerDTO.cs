using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO
{
    public class ProjectBannerDTO
    {

        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        public string Progress { get; set; }

        public List<string>? NeededSkillsName { get; set; }

        public string? BannerImage { get; set; }
    }
}
