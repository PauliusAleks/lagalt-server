namespace lagalt_web_api.Models.DTO.SkillDTO
{
    /// <summary>
    /// Data transfer object for reading Skill entities
    /// </summary>
    public class SkillReadDTO
    {
        /// <summary>
        /// The unique identifier of the Skill
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Skill
        /// </summary>
        public string Name { get; set; }
    }
}
