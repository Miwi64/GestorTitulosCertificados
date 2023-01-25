using Avalonia;
using ProtoApp.Models;
using ReactiveUI;
using System;
using System.ComponentModel.DataAnnotations;
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
            if (index == 0)
            {
                int noreg = int.Parse(Registerc);
                int folio = int.Parse(Folc);
                DBcrud.AddCertificado(noreg, folio, Careerc, Controlc);
            }
            else 
            {
                int noreg = int.Parse(Registert);
                DBcrud.AddTitulo(noreg, Titlet, Controlt, Plan); 
            }
        }

        [Required]
        public string Registerc
        {
            get => _registerc;
            set => this.RaiseAndSetIfChanged(ref _registerc, value);
        }
        [Required]
        public string Controlc
        {
            get => _controlc;
            set => this.RaiseAndSetIfChanged(ref _controlc, value);
        }
        [Required]
        public string Folc
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

        [Required]
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
        string _registerc;
        string _controlc;
        string _folc;
        string _namec;
        string _last1;
        string _last2;
        string _careerc;
        string _datec;
        string _obsc;

        [Required]
        public string Registert
        {
            get => _registert;
            set => this.RaiseAndSetIfChanged(ref _registert, value);
        }
        [Required]
        public string Titlet
        {
            get => _titlet;
            set => this.RaiseAndSetIfChanged(ref _titlet, value);
        }
        [Required]
        public string Controlt
        {
            get => _controlt;
            set => this.RaiseAndSetIfChanged(ref _controlt, value);
        }
        [Required]
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

        string _registert;
        string _controlt;
        string _titlet;
        string _plan;
        string _dateta;
        string _datetr;
        string _cedt;
        string _obst;
    }
}
