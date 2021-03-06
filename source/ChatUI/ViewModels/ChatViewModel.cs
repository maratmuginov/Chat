﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatLib.Models;
using ChatUI.Commands;
using ChatUI.Services;

namespace ChatUI.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        private readonly SignalRChatService _chatService;
        private string _errorMessage = string.Empty;
        private bool _hasError;
        private ObservableCollection<Message> _messages;
        private string _newMessageText;
        public ICommand SendMessageCommand { get; }
        public ICommand StartEditingCommand { get; }

        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set => Set(ref _messages, value);
        }

        public string NewMessageText
        {
            get => _newMessageText;
            set => Set(ref _newMessageText, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            private set
            {
                Set(ref _errorMessage, value);
                HasError = true;
            }
        }

        public bool HasError
        {
            get => _hasError;
            private set => Set(ref _hasError, value);
        }

        public ChatViewModel(SignalRChatService chatService)
        {
            Messages = new ObservableCollection<Message>();

            _chatService = chatService;
            _chatService.MessageReceived += OnMessageReceived;
            SendMessageCommand = new AsyncRelayCmd(SendMessage, OnException);
        }

        public static ChatViewModel ConstructConnectedViewModel(SignalRChatService chatService)
        {
            var viewModel = new ChatViewModel(chatService);

            chatService.Connect().ContinueWith(task =>
            {
                if (task.Exception != null)
                    viewModel.ErrorMessage = task.Exception.Message;
            });

            return viewModel;
        }

        private void OnMessageReceived(Message message) => Messages.Add(message);

        private async Task SendMessage()
        {
            var newMessage = new Message
            {
                Text = NewMessageText,
                Sent = DateTime.Now
            };

            NewMessageText = string.Empty;

            try
            {
                await _chatService.SendMessageAsync(newMessage);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
