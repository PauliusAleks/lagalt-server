namespace lagalt_web_api.Models.DTO.ProjectDTO.ProjectEditDTO
{
    public class ProjectEditDTO
    {
        /// <summary>
        /// DTO Properties for editing a project
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public string Progress { get; set; }
        public string? GitURL { get; set; }
        public virtual List<string>? ImageUrls { get; set; }
        public virtual List<string>? NeededSkills { get; set; }

    }
}
