using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ProtoApp.ViewModels;

namespace ProtoApp.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
