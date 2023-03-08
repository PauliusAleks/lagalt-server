using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_back_end.Models
{
 
    public class ImageUrl
    {
 
        public int Id { get; set; }
        public string Url { get; set; } 
    }
}