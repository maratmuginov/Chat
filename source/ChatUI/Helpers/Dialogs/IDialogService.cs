using ChatUI.ViewModels;

namespace ChatUI.Helpers
{
    public interface IDialogService
    {
        public T OpenDialog<T>(DialogViewModel<T> viewModel);
    }
}
