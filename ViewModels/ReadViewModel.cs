using Microsoft.Win32;
using ProtoApp.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Concurrency;

namespace ProtoApp.ViewModels
{
    public class ReadViewModel : ViewModelBase
    {
        public string SelectedFilter { get; set; }
        public String NoControl { get; set; }

        private ObservableCollection<Certificado> _certificados;
        public ObservableCollection<Certificado> Certificados
        {
            get => _certificados;
            set => this.RaiseAndSetIfChanged(ref _certificados, value);
        }

        public ReadViewModel()
        {
            loadCertificados();
        }

        public void AplicarFiltros()
        {
            loadCertificados();
            var CertFiltrados = Certificados.Where(c =>
            (c.NumeroControl.Equals(NoControl)));
            Certificados = new ObservableCollection<Certificado>(CertFiltrados.ToList().OrderBy(s => s.RegistroCertificado));
        }

        public ObservableCollection<Certificado> loadCertificados()
        {
            using (var context = new TitulosCertificadosContext())
            {
                return Certificados = new ObservableCollection<Certificado>(context.Certificados.ToList().OrderBy(s => s.RegistroCertificado));
            }
        }
    }
}
