using Blogger1.Services;
using Blogger1.views;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Blogger1.ViewModels
{
    public class LoginPageViewModel
    {
        public string _username { get; set; }
        public string _password { get; set; }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public ICommand LoginBtn { get; set; }
        public APIServices _services;
        public LoginPageViewModel()
        {
            LoginBtn = new RelayCommand(LoginAsync);
            _services = new APIServices();
        }
        private async void LoginAsync()
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                var user = await _services.GetUser(Username, Password);
                if (user.Email != null)
                {
                    var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                    nav.NavigateTo(App.MainPage);
                }
                else
                {
                    LoginErrorWarningContentDialog a = new LoginErrorWarningContentDialog();
                    _ = a.ShowAsync();
                }
            }
        }






    }
}
