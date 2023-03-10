using lagalt_web_api.Models;
namespace lagalt_web_api.Models.DTO.UserDTO
{
    public class UserEditDTO
    {
        /// <summary>
        /// Properties for editing a user dto
        /// </summary>
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MotivationLetter { get; set; }
        public virtual List<int>? SkillIds { get; set; }
    }
}
