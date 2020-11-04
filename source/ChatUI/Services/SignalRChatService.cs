using System;
using System.Threading.Tasks;
using ChatLib.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatUI.Services
{
    public class SignalRChatService
    {
        private readonly HubConnection _hubConnection;
        public event Action<Message> MessageReceived;

        public SignalRChatService(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
            _hubConnection.On<Message>("ReceiveMessage", 
                message => MessageReceived?.Invoke(message));
        }

        public async Task Connect() => 
            await _hubConnection.StartAsync();

        public async Task SendMessageAsync(Message message) => 
            await _hubConnection.InvokeAsync("SendMessage", message);
    }
}
