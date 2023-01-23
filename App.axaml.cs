using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ProtoApp.ViewModels;
using ProtoApp.Views;

namespace ProtoApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var vm = new MainWindowViewModel();
                var mainWindow = new MainWindow { DataContext = vm };
                desktop.MainWindow = mainWindow;
                vm.OnRequestClose += (s, e) =>
                {
                    var userWindow = new UserWindow() { DataContext = new UserWindowViewModel(new WindowService())};
                    userWindow.Closed += (s, e) =>
                    {
                        mainWindow.Show();
                    };
                    userWindow.Show();
                    mainWindow.Hide();
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
