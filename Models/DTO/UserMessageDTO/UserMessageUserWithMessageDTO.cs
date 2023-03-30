using System.ComponentModel.DataAnnotations.Schema;

namespace lagalt_web_api.Models.DTO.UserMessageDTO
{
    /// <summary>
    /// A DTO representing a user message with the associated user and project IDs.
    /// </summary>
    public class UserMessageUserWithMessageDTO
    {
        /// <summary>
        /// The ID of the project associated with the user message.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The ID of the user who sent the message.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The content of the user message.
        /// </summary>
        public string Message { get; set; }
    }
}
