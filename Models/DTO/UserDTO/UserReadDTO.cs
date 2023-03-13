using lagalt_web_api.Models;

namespace lagalt_web_api.Models.DTO.UserDTO
{
    public class UserReadDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Portfolio { get; set; }
        public bool UserStatus { get; set; }
        public List<string>? SkillNames { get; set; }
        public List<int>? ApplicationIds { get; set; }
    }
}
