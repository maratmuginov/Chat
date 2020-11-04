using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using ChatUI.Commands;
using ChatUI.ViewModels;

namespace ChatUI.Helpers
{
    public class Navigator : Observable
    {
        private BaseViewModel _activeViewModel;
        public BaseViewModel ActiveViewModel
        {
            get => _activeViewModel;
            set => Set(ref _activeViewModel, value);
        }

        public ICommand NavigateToCommand { get; }

        private readonly Dictionary<ViewType, BaseViewModel> _viewModels;

        public Navigator()
        {
            _viewModels = new Dictionary<ViewType, BaseViewModel>();
            NavigateToCommand = new RelayCmd<ViewType>(NavigateTo, ex => Debug.Print(ex.Message));
        }

        public bool TryRegisterViewModel(ViewType viewType, BaseViewModel viewModel) => 
            _viewModels.TryAdd(viewType, viewModel);

        private void NavigateTo(ViewType viewType)
        {
            if (_viewModels.ContainsKey(viewType))
                ActiveViewModel = _viewModels[viewType];
        }
    }

    public enum ViewType
    {
        ChatView,
        AboutView
    }
}
