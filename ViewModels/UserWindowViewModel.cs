using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProtoApp.ViewModels
{
    public class UserWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        private bool _visibleBack;
        private readonly IWindowService _windowservice;

        public UserWindowViewModel(IWindowService windowservice)
        {
            _windowservice = windowservice;
            OpenAboutWindowCommand = ReactiveCommand.Create(OpenAboutWindow);
            _visibleBack = false;
            _currentView = new UserPanelViewModel();
            OpenAddCommand = ReactiveCommand.Create(OpenAdd);
            OpenEditCommand = ReactiveCommand.Create(OpenEdit);
            OpenReadCommand = ReactiveCommand.Create(OpenRead);
            OpenManagementCommand = ReactiveCommand.Create(OpenManagement);
            BackButtonCommand = ReactiveCommand.Create(BackButton);

        }
        public void OpenAboutWindow()
        {
            _windowservice.CreateAboutWindow();
        }
        public ReactiveCommand<Unit, Unit> OpenAboutWindowCommand { get ;}
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => this.RaiseAndSetIfChanged(ref _currentView, value);
        }

        public ReactiveCommand<Unit, Unit> OpenEditCommand { get; }
        public void OpenEdit()
        {
            VisibleBack = true;
            CurrentView = new EditViewModel();
        }
        public ReactiveCommand<Unit, Unit> OpenAddCommand { get; }
        public void OpenAdd()
        {
            VisibleBack = true;
            CurrentView = new AddViewModel(new WindowService());
        }
        public ReactiveCommand<Unit, Unit> OpenReadCommand { get; }
        public void OpenRead()
        {
            VisibleBack = true;
            CurrentView = new ReadViewModel();
        }
        public ReactiveCommand<Unit, Unit> OpenManagementCommand { get; }
        public void OpenManagement()
        {
            VisibleBack = true;
            CurrentView = new UserManagementViewModel();
        }
        public ReactiveCommand<Unit, Unit> BackButtonCommand { get; }
        public void BackButton()
        {
            CurrentView = new UserPanelViewModel();
            VisibleBack = false;
        }
        public bool VisibleBack {
            get => _visibleBack;
            set => this.RaiseAndSetIfChanged(ref _visibleBack, value);
        }
    }
}
