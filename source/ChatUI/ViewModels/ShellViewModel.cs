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
            ChatViewModel viewModel = services.GetRequiredService<ChatViewModel>();
            Navigator.TryRegisterViewModel(ViewType.ChatView, viewModel);
            Navigator.NavigateTo(ViewType.ChatView);
        }
    }
}
