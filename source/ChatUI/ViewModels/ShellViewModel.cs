using System;
using ChatUI.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace ChatUI.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public Navigator Navigator { get; }

        public ShellViewModel(IServiceProvider services)
        {
            Navigator = services.GetRequiredService<Navigator>();

            Navigator.TryRegisterViewModel(ViewType.ChatView, 
                services.GetRequiredService<ChatViewModel>());

            Navigator.TryRegisterViewModel(ViewType.AboutView, 
                services.GetRequiredService<AboutViewModel>());

            Navigator.NavigateToCommand.Execute(ViewType.ChatView);
        }
    }
}
