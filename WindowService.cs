using Avalonia;
using ProtoApp.ViewModels;
using ProtoApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoApp
{
    public class WindowService : IWindowService
    {
        public void CreateAboutWindow()
        {
            var vm = new AboutWindowViewModel();
            AboutWindow win = new AboutWindow() { DataContext = vm};
            vm.OnRequestClose += (s, e) => win.Close();
            win.Show();
        }
    }
}
