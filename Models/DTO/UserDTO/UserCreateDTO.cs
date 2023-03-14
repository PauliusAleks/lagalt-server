using lagalt_web_api.Models;

namespace lagalt_web_api.Models.DTO.UserDTO
{
    public class UserCreateDTO
    {
        /// <summary>
        /// Properties for creating a user dto
        /// </summary>
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Portofolio { get; set; }
        public bool? UserStatus { get; set; }
    }
}
