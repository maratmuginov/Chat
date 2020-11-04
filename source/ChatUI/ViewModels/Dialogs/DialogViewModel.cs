using ChatUI.Helpers;

namespace ChatUI.ViewModels
{
    public abstract class DialogViewModel<T> : BaseViewModel
    {
        public string WindowTitle { get; set; }
        public string Message { get; set; }
        public T DialogResult { get; set; }

        protected DialogViewModel(string windowTitle, string message)
        {
            WindowTitle = windowTitle;
            Message = message;
        }

        protected DialogViewModel(string windowTitle) : this(windowTitle, string.Empty) { }
        protected DialogViewModel() : this(string.Empty, string.Empty) { }

        public void CloseDialogWithResult(IDialogWindow window, T result)
        {
            DialogResult = result;
            if (window != null)
                window.DialogResult = true;
        }
    }
}
