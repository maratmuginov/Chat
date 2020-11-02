using System;
using System.Diagnostics;
using ChatUI.Helpers;

namespace ChatUI.ViewModels
{
    public abstract class BaseViewModel : Observable
    {
        public void OnException(Exception ex) => Debug.Print(ex.Message);
    }
}
