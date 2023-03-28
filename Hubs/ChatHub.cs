using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace lagalt_web_api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage( string projectId, string message)
        {
            Debug.WriteLine("From sendmessage: Id: " + projectId + ", " + message);
            await Clients.All.SendAsync("ReceiveMessage", projectId, message);
        }
    }
}
