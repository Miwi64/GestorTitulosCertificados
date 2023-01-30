using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Parsers.Nodes;
using Avalonia.OpenGL.Angle;
using Microsoft.VisualBasic;
using ProtoApp.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace ProtoApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public event EventHandler? OnRequestClose;
        public MainWindowViewModel() {
            OpenPanelCommand = ReactiveCommand.Create(OpenPanel);
        }
        public ReactiveCommand<Unit, Unit> OpenPanelCommand { get; }
        public void OpenPanel() {
            OnRequestClose?.Invoke(this, new EventArgs());
        }
    }
}
