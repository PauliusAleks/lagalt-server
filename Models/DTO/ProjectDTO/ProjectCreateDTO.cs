namespace lagalt_web_api.Models.DTO.ProjectDTO
{
    public class ProjectCreateDTO
    {
        /// <summary>
        /// Properties to create a project dto
        /// </summary>
        public string Name { get; set; }
        public CategoryState Category { get; set; }
        public ProgressState Progress { get; set; }
        public string? Description { get; set; }
        public string? GitURL { get; set; }
        //public virtual List<int>? ImageUrlIds { get; set; }
        //public virtual List<int>? NeededSkillIds { get; set; }

        public override string ToString()
        {
            return String.Format("Name: {0}, Category: {1}, Progress: {2}, Description: {3}, GitURL: {4}", Name, Category, Progress, Description, GitURL);
        }
    }
}
