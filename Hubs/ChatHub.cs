using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace lagalt_web_api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(/*string user,*/ string message)
        {
            Debug.Write("Message received: " + message);
            await Clients.All.SendAsync("ReceiveMessage", /*user,*/ "Server says: " + message);
        }
    }
}
