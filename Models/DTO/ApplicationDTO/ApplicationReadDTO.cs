﻿namespace lagalt_web_api.Models.DTO.ApplicationDTO;

public class ApplicationReadDTO
{
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    public string motivationLetter { get; set; }
    public ApplicationState State { get; set; }
}
