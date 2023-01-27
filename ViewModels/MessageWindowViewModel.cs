using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ProtoApp.ViewModels
{
    public class MessageWindowViewModel: ViewModelBase
    {
        public MessageWindowViewModel(string message_title, string content, ISolidColorBrush window_color)
        {
            MessageTitle = message_title;
            Content = content;
            AcceptButtonCommand = ReactiveCommand.Create(AcceptButton);
            WindowColor = window_color;
        }
        public ReactiveCommand<Unit, Unit> AcceptButtonCommand { get; }
        public void AcceptButton()
        {
            if (OnRequestClose != null) OnRequestClose(this, new EventArgs());
        }
        public string MessageTitle
        {
            get; set;
        } = "Title";
        public string Content
        {
            get; set;
        } = "";
        public ISolidColorBrush WindowColor {
            get; set;
        }
        public event EventHandler? OnRequestClose;
    }
}
