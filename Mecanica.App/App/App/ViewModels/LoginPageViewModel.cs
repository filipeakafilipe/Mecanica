using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Entrar";

            MenuPageCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("MenuPage");
            });
        }

        public Command MenuPageCommand { get; }
    }
}

