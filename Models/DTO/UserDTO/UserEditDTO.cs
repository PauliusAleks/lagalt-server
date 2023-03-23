using lagalt_web_api.Models;
namespace lagalt_web_api.Models.DTO.UserDTO
{
    public class UserEditDTO
    {
        /// <summary>
        /// Properties for editing a user dto
        /// </summary>
        public int Id { get; set; }
        public string? Portfolio { get; set; }
        public bool IsHidden { get; set; }
        public virtual List<string>? Skills { get; set; }
    }
}
