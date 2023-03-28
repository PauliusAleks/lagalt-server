using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models.DTO.UserMessageDTO
{
    public class UserMessageUserWithMessageDTO
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; } 
        public string Message { get; set; }
    }
}
