using System.Collections.Generic;
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

        private readonly Dictionary<ViewType, BaseViewModel> _viewModels;

        public Navigator()
        {
            _viewModels = new Dictionary<ViewType, BaseViewModel>();
        }

        public bool TryRegisterViewModel(ViewType viewType, BaseViewModel viewModel)
        {
            return _viewModels.TryAdd(viewType, viewModel);
        }

        public void NavigateTo(ViewType viewType)
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
