using NuGet.Protocol.Plugins;

namespace lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO
{
    public class ProjectCreateDTO
    {
        /// <summary>
        /// DTO Properties for creating a project
        /// </summary>
        public string Name { get; set; }
        public string Category { get; set; }
        public string Progress { get; set; }
        public string Description { get; set; }
        public string? GitURL { get; set; }
        public virtual List<string>? ImageUrls { get; set; }
        public virtual List<string>? NeededSkills { get; set; }
        public int adminId { get; set; }
    }
}
