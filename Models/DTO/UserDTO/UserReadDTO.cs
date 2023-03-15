using lagalt_web_api.Models;

namespace lagalt_web_api.Models.DTO.UserDTO
{
    public class UserReadDTO
    {
        public string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Portfolio { get; set; }
        public bool IsHidden { get; set; }
        public List<string>? Skills { get; set; }
        public List<int>? ApplicationIds { get; set; }
    }
}
