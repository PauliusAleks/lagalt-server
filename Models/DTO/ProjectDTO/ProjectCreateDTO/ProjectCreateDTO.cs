using NuGet.Protocol.Plugins;

namespace lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO
{
    public class ProjectCreateDTO
    {
        /// <summary>
        /// Properties to create a project dto
        /// </summary>
        public string Name { get; set; }
        public string Category { get; set; }
        public string Progress { get; set; }
        public string Description { get; set; }
        public string? GitURL { get; set; }
        public virtual List<string>? ImageUrls { get; set; }
        public virtual List<string>? NeededSkills { get; set; } //AddUserToProject(int projectId, int userId)
        public int adminId { get; set; }
    }
}
