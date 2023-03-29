using System.ComponentModel.DataAnnotations;

namespace lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO
{
    public class ProjectBannerDTO
    {
        /// <summary>
        /// DTO Properties for reading a project that will be displayed on the main page.
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Progress { get; set; }
        public List<string>? NeededSkills { get; set; }
        public string? BannerImage { get; set; }
    }
}
