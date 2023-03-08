using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool UserStatus { get; set; }
        public string? MotivationLetter { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        [ForeignKey("HistoryId")]
        public History History { get; set; }
        public ICollection<Admin>? ProjectsWhereAdmin { get; set; }
        public ICollection<Contributor>? ProjectsWhereContributor { get; set; }
        public ICollection<Application>? Applications { get; set; }

    }
}
