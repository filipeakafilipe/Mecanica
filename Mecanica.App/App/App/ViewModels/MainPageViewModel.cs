using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Página inicial";

            CriarPerfilCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("CriarPerfilPage");
            });
        }

        public Command CriarPerfilCommand { get; }
    }
}
