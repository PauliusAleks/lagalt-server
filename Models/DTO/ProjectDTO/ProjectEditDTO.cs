namespace lagalt_web_api.Models.DTO.ProjectDTO
{
    public class ProjectEditDTO
    {
        /// <summary>
        /// Properties to edit a project dto
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public CategoryState Category { get; set; }
        public ProgressState Progress { get; set; }
        public string? GitURL { get; set; }
        public virtual List<int> ContributorsIds { get; set; }
        public virtual List<int>? ImageUrlIds { get; set; }
        public virtual List<int>? NeededSkillIds { get; set; }

    }
}
