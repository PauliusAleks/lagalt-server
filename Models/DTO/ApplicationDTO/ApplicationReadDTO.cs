namespace lagalt_web_api.Models.DTO.ApplicationDTO;

public class ApplicationReadDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    public string MotivationLetter { get; set; }
    public string State { get; set; }
}
