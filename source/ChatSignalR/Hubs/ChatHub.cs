using ChatLib.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace ChatSignalR.Hubs
{
    public class ChatHub : Hub
    {
        //[Authorize]
        public async Task SendMessage(Message message) => 
            await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
