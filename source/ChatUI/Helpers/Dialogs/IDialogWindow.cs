namespace ChatUI.Helpers
{
    public interface IDialogWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }
        public bool? ShowDialog();
    }
}
