using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.DB;
using TestApp.Models;

namespace TestApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand RegisterCommand { get; set; }

        IPageDialogService _pageDialog;
        public LoginPageViewModel(INavigationService navigationService,IDialogService dialogService,IPageDialogService pageDialog ): base(navigationService)
        {
            _pageDialog = pageDialog;
            RegisterCommand = new DelegateCommand(() =>
            {
                dialogService.ShowDialog("RegisterDialog", CloseDialogCallback);
            });
        }

        internal async Task Login()
        {
            var userslist = DBHelper.sqlConnection.Table<UserInfo>();
            var user = userslist.Where(x => x.username.ToLower() == Username.ToLower() && x.password.Equals(Password)).FirstOrDefault();
            if (user !=null)
            {



                await NavigationService.NavigateAsync("app:///NavigationPage/MainPage", new NavigationParameters { {"user", user } });
            }
            else
            {
               await _pageDialog.DisplayAlertAsync("Error!!", "Inavlid username or password", "OK");
            }
        }

        void CloseDialogCallback(IDialogResult dialogResult)
        {
            Username = Password = string.Empty;
        }
    }
}
