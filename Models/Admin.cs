using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
    /// <summary>
    /// Model for the User - Admin table
    /// </summary>
    [Table("Admin")]
    public class Admin
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User AdminName { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
