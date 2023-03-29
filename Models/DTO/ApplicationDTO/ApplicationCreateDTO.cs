namespace lagalt_web_api.Models.DTO.ApplicationDTO;

public class ApplicationCreateDTO
{
    /// <summary>
    /// DTO Properties for creating an application.
    /// </summary>
    public string MotivationLetter { get; set; }
    public int UserId { get; set; }
    public int ProjectId { get; set; }
}
