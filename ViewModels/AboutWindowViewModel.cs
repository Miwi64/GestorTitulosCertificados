using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ProtoApp.ViewModels
{
    public class AboutWindowViewModel : ViewModelBase
    {
        public AboutWindowViewModel()
        {
            CloseWindowCommand = ReactiveCommand.Create(CloseWindow);
        }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; }
        public void CloseWindow()
        {
            OnRequestClose?.Invoke(this, new EventArgs());
        }
        public event EventHandler? OnRequestClose;
    }
}
