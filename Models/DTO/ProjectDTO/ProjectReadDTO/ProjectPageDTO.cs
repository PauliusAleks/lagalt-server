﻿namespace lagalt_web_api.Models.DTO.ProjectDTO.ProjectReadDTO
{
    public class ProjectPageDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Progress { get; set; }
        public string? Description { get; set; }
        public string? GitURL { get; set; }
        public List<string>? ImageUrls { get; set; }
        public List<string>? NeededSkillsName { get; set; }
        public List<string>? Contributors { get; set; }

    }
}