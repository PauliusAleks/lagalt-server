using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
 
    public class User
    {
 
        public int Id { get; set; }
 
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        public string Email { get; set; }
    
        public bool UserStatus { get; set; }
        public string? MotivationLetter { get; set; }
        public virtual ICollection<Skill>? Skills { get; set; }
        public virtual ICollection<Application>? Applications { get; set; }
        public virtual ICollection<HistoricEvent> HistoricEvents { get; set; } 
    }
}
