using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace lagalt_web_api.Hubs
{
    /// <summary>
    /// SignalR hub for handling chat messages.
    /// </summary>
    public class ChatHub : Hub
    {
        /// <summary>
        /// Sends a message to all connected clients.
        /// </summary>
        /// <param name="projectId">The ID of the project the message is related to.</param>
        /// <param name="message">The content of the message.</param>
        public async Task SendMessage(string projectId, string message)
        {
            Debug.WriteLine("From sendmessage: Id: " + projectId + ", " + message);
            await Clients.All.SendAsync("ReceiveMessage", projectId, message);
        }
    }
}
