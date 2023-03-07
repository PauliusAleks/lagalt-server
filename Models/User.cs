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
        public List<string>? Skills { get; set; }
        public History? history { get; set; }
        public ICollection<Project>? ProjectsWhereAdmin { get; set; }
        public ICollection<Project>? ProjectsWhereMember { get; set; }
        public ICollection<Application>? Applications { get; set; }

    }
}
