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
        ReadViewModel() 
        {
            LoadCertificados();
        }
        private ObservableCollection<Certificado> _certificados;
        public ObservableCollection<Certificado> Certificados
        {
            get => _certificados;
            set => this.RaiseAndSetIfChanged(ref _certificados, value);
        }

        public void LoadCertificados()
        {
            using (var context = new TitulosCertificadosContext())
            {
                Certificados = new ObservableCollection<Certificado>(context.Certificados.ToList());
            }
        }

    }
}
