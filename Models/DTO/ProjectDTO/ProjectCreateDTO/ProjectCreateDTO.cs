namespace lagalt_web_api.Models.DTO.ProjectDTO.ProjectCreateDTO
{
    public class ProjectCreateDTO
    {
        /// <summary>
        /// Properties to create a project dto
        /// </summary>
        public string Name { get; set; }
        public CategoryState Category { get; set; }
        public ProgressState Progress { get; set; }
        public string Description { get; set; }
        public string? GitURL { get; set; }
        public virtual List<string>? ImageUrls { get; set; }
        public virtual List<int>? NeededSkills { get; set; } //AddUserToProject(int projectId, int userId)
    }
}
