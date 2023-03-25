using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
