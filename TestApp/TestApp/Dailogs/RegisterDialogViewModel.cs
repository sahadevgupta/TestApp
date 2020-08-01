using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApp.DB;
using TestApp.Models;

namespace TestApp.Dailogs
{
    public class RegisterDialogViewModel : BindableBase, IDialogAware
    {

        private UserInfo _userInfo;
        public UserInfo UserInfo
        {
            get { return _userInfo; }
            set { SetProperty(ref _userInfo, value); }
        }

        private string _conPassword;
        public string ConfirmPassword
        {
            get { return _conPassword; }
            set { SetProperty(ref _conPassword, value); }
        }

        public event Action<IDialogParameters> RequestClose;

        public DelegateCommand SubmitCommand { get; }

        IPageDialogService _pagedialogService;
        public RegisterDialogViewModel(IPageDialogService pagedialogService)
        {
            _pagedialogService = pagedialogService;
            SubmitCommand = new DelegateCommand(async() => await SaveUserInfoToDB());
        }

        private async Task SaveUserInfoToDB()
        {
            if (ConfirmPassword != UserInfo.password || string.IsNullOrEmpty(UserInfo.username)|| string.IsNullOrEmpty(UserInfo.password))
            {
                if (string.IsNullOrEmpty(UserInfo.username) || string.IsNullOrEmpty(UserInfo.password))
                {
                    await _pagedialogService.DisplayAlertAsync("Error!!", "Username or password cannot be null", "OK");
                }
                else if (ConfirmPassword != UserInfo.password)
                {
                    await _pagedialogService.DisplayAlertAsync("Error!!", "Confirm Password not same", "OK");
                }
            }
            else
            {
                DBHelper.sqlConnection.Insert(UserInfo);
                RequestClose(null);
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
                    
        
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            UserInfo = new UserInfo();
        }
    }
}
