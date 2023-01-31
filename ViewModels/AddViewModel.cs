using Avalonia.Media;
using ProtoApp.Models;
using ReactiveUI;
using System.ComponentModel.DataAnnotations;
using System.Reactive;

namespace ProtoApp.ViewModels
{
    public class AddViewModel : ViewModelBase
    {

        public AddViewModel(IWindowService windowService)
        {
            IsButtonEnabled = true;
            Index = 0;
            AddDataCommand = ReactiveCommand.Create(AddData);
            _windowService = windowService;
        }
        public ReactiveCommand<Unit, Unit> AddDataCommand { get; }
        public void AddData()
        {
            if (RegValidation)
            {
                if (Index == 0)
                {
                    int noreg = int.Parse(Registerc);
                    int folio = int.Parse(Folc);
                    DBcrud.AddCertificado(noreg, folio, Careerc, Controlc, Namec, Last1, Last2, obs: Obsc);
                    Registerc = Careerc = Folc = Controlc = Namec = Last1 = Last2 = Obsc = "";
                }
                else
                {
                    int noreg = int.Parse(Registert);
                    int cd = int.Parse(Cedt);
                    DBcrud.AddTitulo(noreg, Titlet, Controlt, Plan, ced: cd, obs: Obst);
                    Registert = Titlet = Controlt = Plan = Cedt = Obst = "";
                }
            }
            else
            {
                _windowService.CreateMessageWindow("Error", "Error en la alta del registro. " +
                        "Verifique la correctitud de los campos y vuelva a intentarlo", Brushes.PaleVioletRed);
            }
        }


        [Required(ErrorMessage = "Campo Obligatorio"),
            Range(0, int.MaxValue, ErrorMessage = "Introducir solo numeros")]
        public string Registerc
        {
            get => _registerc;
            set
            {
                this.RaiseAndSetIfChanged(ref _registerc, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [Required(ErrorMessage = "Campo Obligatorio"),
            StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Controlc
        {
            get => _controlc;
            set {this.RaiseAndSetIfChanged(ref _controlc, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [Required(ErrorMessage = "Campo Obligatorio"),
            Range(0, int.MaxValue, ErrorMessage = "Introducir solo numeros")]
        public string Folc
        {
            get => _folc;
            set {this.RaiseAndSetIfChanged(ref _folc, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Namec
        {
            get => _namec;
            set {this.RaiseAndSetIfChanged(ref _namec, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Last1
        {
            get => _last1;
            set {this.RaiseAndSetIfChanged(ref _last1, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Last2
        {
            get => _last2;
            set {this.RaiseAndSetIfChanged(ref _last2, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [Required(ErrorMessage = "Campo Obligatorio"),
            StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Careerc
        {
            get => _careerc;
            set {this.RaiseAndSetIfChanged(ref _careerc, value);
                IsButtonEnabled = RegValidation;
            }
        }
        public string Datec
        {
            get => _datec;
            set {this.RaiseAndSetIfChanged(ref _datec, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Obsc
        {
            get => _obsc;
            set {this.RaiseAndSetIfChanged(ref _obsc, value);
                IsButtonEnabled = RegValidation;
            }
        }
        string _registerc = "";
        string _controlc = "";
        string _folc = "";
        string _namec = "";
        string _last1 = "";
        string _last2 = "";
        string _careerc = "";
        string _datec = "";
        string _obsc = "";

        [Required(ErrorMessage = "Campo Obligatorio"),
            Range(0, int.MaxValue, ErrorMessage = "Introducir solo numeros")]
        public string Registert
        {
            get => _registert;
            set {this.RaiseAndSetIfChanged(ref _registert, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [Required(ErrorMessage = "Campo Obligatorio"),
            StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Titlet
        {
            get => _titlet;
            set{this.RaiseAndSetIfChanged(ref _titlet, value);
                IsButtonEnabled = RegValidation;
            }
        }

        [Required(ErrorMessage = "Campo Obligatorio"),
            StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Controlt
        {
            get => _controlt;
            set {this.RaiseAndSetIfChanged(ref _controlt, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [Required(ErrorMessage = "Campo Obligatorio"),
            StringLength(15, ErrorMessage = "Maximo 15 caracteres")]
        public string Plan
        {
            get => _plan;
            set {this.RaiseAndSetIfChanged(ref _plan, value);
                IsButtonEnabled = RegValidation;
            }
        }
        public string DatetA
        {
            get => _dateta;
            set {this.RaiseAndSetIfChanged(ref _dateta, value);
                IsButtonEnabled = RegValidation;
            }
        }
        public string DatetR
        {
            get => _datetr;
            set {this.RaiseAndSetIfChanged(ref _datetr, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [Required(ErrorMessage = "Campo Obligatorio"),
            Range(0, long.MaxValue, ErrorMessage = "Introducir solo numeros")]
        public string Cedt
        {
            get => _cedt;
            set{
                this.RaiseAndSetIfChanged(ref _cedt, value);
                IsButtonEnabled = RegValidation;
            }
        }
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Obst
        {
            get => _obst;
            set {this.RaiseAndSetIfChanged(ref _obst, value);
                IsButtonEnabled = RegValidation;
            }
        }
        public int Index
        {
            get => _index;
            set {this.RaiseAndSetIfChanged(ref _index, value);
                IsButtonEnabled = RegValidation;
            }
        }

        public bool IsButtonEnabled
        {
            get => _isButtonEnabled;
            set => this.RaiseAndSetIfChanged(ref _isButtonEnabled, value);
        }
        private bool RegValidation
        { get => Index == 0 ?
                !string.IsNullOrWhiteSpace(Registerc) &&
                            !string.IsNullOrWhiteSpace(Folc) &&
                            !string.IsNullOrWhiteSpace(Controlc) &&
                            !string.IsNullOrWhiteSpace(Careerc) &&
                            (string.IsNullOrWhiteSpace(Controlc) || Controlc.Length < 11) &&
                            (string.IsNullOrWhiteSpace(Namec) || Namec.Length < 31) &&
                            (string.IsNullOrWhiteSpace(Careerc) || Careerc.Length < 51) &&
                            (string.IsNullOrWhiteSpace(Last1) || Last1.Length < 31) &&
                            (string.IsNullOrWhiteSpace(Last2) || Last2.Length < 31) &&
                            (string.IsNullOrWhiteSpace(Obsc) || Obsc.Length < 51) &&
                            int.TryParse(Registerc, out int _) &&
                            int.TryParse(Folc, out _) 
            : !string.IsNullOrWhiteSpace(Registert) &&
                            !string.IsNullOrWhiteSpace(Titlet) &&
                            !string.IsNullOrWhiteSpace(Controlt) &&
                            !string.IsNullOrWhiteSpace(Plan) &&
                            !string.IsNullOrWhiteSpace(Cedt) &&
                            (string.IsNullOrWhiteSpace(Titlet) || Titlet.Length < 11) &&
                            (string.IsNullOrWhiteSpace(Controlt) || Controlt.Length < 11) &&
                            (string.IsNullOrWhiteSpace(Plan) || Plan.Length < 16) &&
                            (string.IsNullOrWhiteSpace(Obst) || Obst.Length < 51) &&
                            int.TryParse(Registert, out int _) &&
                            int.TryParse(Cedt, out int _);
        }
        private bool _isButtonEnabled;
        private string _registert = "";
        private string _controlt = "";
        private string _titlet = "";
        private string _plan = "";
        private string _dateta = "" ;
        private string _datetr = "";
        private string _cedt = "";
        private string _obst = "";
        private int _index = 0;
        private readonly IWindowService _windowService;
    }
}