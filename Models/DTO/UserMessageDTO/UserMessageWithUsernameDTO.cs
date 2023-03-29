namespace lagalt_web_api.Models.DTO.UserMessageDTO
{
    /// <summary>
    /// Data transfer object for UserMessage model, containing message and the username of the user who sent it.
    /// </summary>
    public class UserMessageWithUsernameDTO
    {
        /// <summary>
        /// Gets or sets the username of the user who sent the message.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        public string Message { get; set; }
    }
}
