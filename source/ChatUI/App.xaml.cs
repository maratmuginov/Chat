using System;
using System.Windows;
using ChatUI.Helpers;
using ChatUI.Services;
using ChatUI.ViewModels;
using ChatUI.Views;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace ChatUI
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = ConfigureServices();
            var shellWindow = new ShellView
            {
                DataContext = services.GetRequiredService<ShellViewModel>()
            };
            shellWindow.Show();
        }

        private static ChatViewModel GetConnectedChatViewModel(IServiceProvider provider) => 
            ChatViewModel.ConstructConnectedViewModel(provider.GetRequiredService<SignalRChatService>());

        private static HubConnection GetHubConnection() =>
            new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chat")
                .Build();

        private static IServiceProvider ConfigureServices() => 
            new ServiceCollection()
                .AddSingleton<Navigator>()
                .AddSingleton<ShellViewModel>()
                .AddSingleton<AboutViewModel>()
                .AddSingleton(GetHubConnection())
                .AddSingleton<SignalRChatService>()
                .AddScoped(GetConnectedChatViewModel)
                    .BuildServiceProvider();
    }
}
