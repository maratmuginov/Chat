using ChatUI.ViewModels;
using ChatUI.Views;

namespace ChatUI.Helpers
{
    public class DialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModel<T> viewModel)
        {
            IDialogWindow window = new DialogView { DataContext = viewModel };
            window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}
