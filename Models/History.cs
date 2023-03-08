using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
    /// <summary>
    /// Model for the History table
    /// </summary>
    [Table("History")]
    public class History
    {
        [Key]
        [Required]
        public int Id { get; set; }
        //FK
        public ICollection<Project>? ContributedProject { get; set; }
        public ICollection<Project>? ViewedProject { get; set; }
        public ICollection<Project>? AppliedToProject { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
