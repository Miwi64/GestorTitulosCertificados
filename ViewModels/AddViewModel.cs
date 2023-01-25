using Avalonia;
using ProtoApp.Models;
using ReactiveUI;
using System;
using System.Reactive;

namespace ProtoApp.ViewModels
{
    public class AddViewModel : ViewModelBase
    {
        public AddViewModel() 
        {
            AddDataCommand = ReactiveCommand.Create<int>(AddData);
        }
        public ReactiveCommand<int, Unit> AddDataCommand { get; }
        public void AddData(int index)
        {
            if (index == 0) DBcrud.AddCertificado(Registerc, Folc, Controlc);
            if (index == 1) DBcrud.AddTitulo(Registert, Titlet, Controlt);
        }

        public int Registerc
        {
            get => _registerc;
            set => this.RaiseAndSetIfChanged(ref _registerc, value);
        }
        public string Controlc
        {
            get => _controlc;
            set => this.RaiseAndSetIfChanged(ref _controlc, value);
        }
        public int Folc
        {
            get => _folc;
            set => this.RaiseAndSetIfChanged(ref _folc, value);
        }
        public string Namec
        {
            get => _namec;
            set => this.RaiseAndSetIfChanged(ref _namec, value);
        }
        public string Last1
        {
            get => _last1;
            set => this.RaiseAndSetIfChanged(ref _last1, value);
        }
        public string Last2
        {
            get => _last2;
            set => this.RaiseAndSetIfChanged(ref _last2, value);
        }
        public string Careerc
        {
            get => _careerc;
            set => this.RaiseAndSetIfChanged(ref _careerc, value);
        }
        public string Datec
        {
            get => _datec;
            set => this.RaiseAndSetIfChanged(ref _datec, value);
        }
        public string Obsc
        {
            get => _obsc;
            set => this.RaiseAndSetIfChanged(ref _obsc, value);
        }
        int _registerc;
        string _controlc;
        int _folc;
        string _namec;
        string _last1;
        string _last2;
        string _careerc;
        string _datec;
        string _obsc;


        public int Registert
        {
            get => _registert;
            set => this.RaiseAndSetIfChanged(ref _registert, value);
        }
        public int Titlet
        {
            get => _titlet;
            set => this.RaiseAndSetIfChanged(ref _titlet, value);
        }
        public string Controlt
        {
            get => _controlt;
            set => this.RaiseAndSetIfChanged(ref _controlt, value);
        }
        public string Plan
        {
            get => _plan;
            set => this.RaiseAndSetIfChanged(ref _plan, value);
        }
        public string DatetA
        {
            get => _dateta;
            set => this.RaiseAndSetIfChanged(ref _dateta, value);
        }
        public string DatetR
        {
            get => _datetr;
            set => this.RaiseAndSetIfChanged(ref _datetr, value);
        }
        public string Cedt
        {
            get => _cedt;
            set => this.RaiseAndSetIfChanged(ref _cedt, value);
        }
        public string Obst
        {
            get => _obst;
            set => this.RaiseAndSetIfChanged(ref _obst, value);
        }

        int _registert;
        string _controlt;
        int _titlet;
        string _plan;
        string _dateta;
        string _datetr;
        string _cedt;
        string _obst;
    }
}
