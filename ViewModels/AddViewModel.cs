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
            AddDataCommand = ReactiveCommand.Create(AddData);
        }
        public ReactiveCommand<Unit, Unit> AddDataCommand { get; }
        public void AddData()
        {
            
            DBcrud.AddCertificado(10202, 20313, "M15761201");
        }
    }
}
