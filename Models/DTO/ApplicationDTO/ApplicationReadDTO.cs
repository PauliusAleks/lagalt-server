namespace lagalt_web_api.Models.DTO.ApplicationDTO;

public class ApplicationReadDTO
{
    /// <summary>
    /// DTO Properties for reading an application.
    /// </summary>
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    public string MotivationLetter { get; set; }
    public string State { get; set; }
}
