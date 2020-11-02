using System.Threading.Tasks;
using ChatLib.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatSignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) => 
            await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
