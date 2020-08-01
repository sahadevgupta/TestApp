using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Dailogs
{
    public class AddLocationDialogViewModel : BindableBase, IDialogAware
    {
        private string _address;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        public DelegateCommand AddCommand { get; set; }
        public AddLocationDialogViewModel()
        {
           
            AddCommand = new DelegateCommand(() => AddPin()) ;
        }

        private void AddPin()
        {
            var param = new DialogParameters();
            param.Add("pin", Address);
            RequestClose.Invoke(param);
        }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
          
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
           
        }
    }
}
