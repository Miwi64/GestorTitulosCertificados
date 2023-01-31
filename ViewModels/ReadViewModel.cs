using ProtoApp.Models;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using Avalonia.Controls;

namespace ProtoApp.ViewModels
{
    public class ReadViewModel : ViewModelBase
    {
        private int _selectedSort;
        private string _busqueda;
        private bool _ascdesc;

        public int SelectedFilter { get; set; }
        public int SelectedSort { 
            get => _selectedSort; 
            set {
                this.RaiseAndSetIfChanged(ref _selectedSort, value);
                loadData();
                AplicarFiltros();
                UpdateSort();
            }
        }
        public bool Ascdesc
        {
            get => _ascdesc;
            set
            {
                this.RaiseAndSetIfChanged(ref _ascdesc, value);
                loadData();
                AplicarFiltros();
                UpdateSort();
            }
        }

        public string Busqueda { 
            get => _busqueda;
            set
            {
                this.RaiseAndSetIfChanged(ref _busqueda, value);
                loadData();
                AplicarFiltros();
                UpdateSort();
            } 
        }

        private ObservableCollection<Certificado> _certificados;
        public ObservableCollection<Certificado> Certificados
        {
            get => _certificados;
            set => this.RaiseAndSetIfChanged(ref _certificados, value);
        }

        public ReadViewModel()
        {
            _ascdesc = false;
            _selectedSort = 0;
            SelectedFilter = 0;
            Busqueda = "";
        }

        public async void AplicarFiltros()
        {
            //predicate<Person> oscarFinder = (Person p) => { return p.Name == "Oscar"; };
            Predicate<Certificado> filtro;
            var CertFiltrados = Certificados.Where(GetPredicate(SelectedFilter));
            Certificados = new ObservableCollection<Certificado> (CertFiltrados);
        }

        private Func<Certificado, bool> GetPredicate(int option) {
            switch (option) {
                case 0:
                    return c => c.NumeroControl.ToUpper().Contains(Busqueda.ToUpper()); ;
                case 1:
                    return c => c.RegistroCertificado.ToString().Contains(Busqueda);
                case 2:
                    return c => c.Folio.ToString().Contains(Busqueda);
                case 3:
                    return c => c.ApellidoPaterno.ToUpper().Contains(Busqueda.ToUpper());
                case 4:
                    return c => c.ApellidoMaterno.ToUpper().Contains(Busqueda.ToUpper());
                case 5:
                    return c => c.Nombre.ToUpper().Contains(Busqueda.ToUpper());
                default:
                    return c => true;
            }
        }

        public ObservableCollection<Certificado> UpdateSort()
        {
            if (Ascdesc)
            {
                switch (SelectedSort)
                {
                    case 0:
                        return Certificados = new ObservableCollection<Certificado>(Certificados.OrderByDescending(s => s.NumeroControl));
                    case 1:
                        return Certificados = new ObservableCollection<Certificado>(Certificados.OrderByDescending(s => s.RegistroCertificado));
                    default:
                        return Certificados = new ObservableCollection<Certificado>(Certificados);
                }
            }
            else {
                switch (SelectedSort)
                {
                    case 0:
                        return Certificados = new ObservableCollection<Certificado>(Certificados.OrderBy(s => s.NumeroControl));
                    case 1:
                        return Certificados = new ObservableCollection<Certificado>(Certificados.OrderBy(s => s.RegistroCertificado));
                    default:
                        return Certificados = new ObservableCollection<Certificado>(Certificados);
                }
            }
        }

        public void loadData() {
            using (var context = new TitulosCertificadosContext())
            {
                Certificados = new ObservableCollection<Certificado>(context.Certificados);
            }
        }

        
        
    }
}
