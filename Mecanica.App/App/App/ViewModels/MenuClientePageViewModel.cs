using App.Modelos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class MenuClientePageViewModel : ViewModelBase
    {
        public MenuClientePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Menu";

            PerfilCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("PerfilPage");
            });

            MeusVeiculosCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("MeusVeiculosPage");
            });

            MinhasManutencoesCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("MinhasManutencoesPage");
            });
        }

        public Command PerfilCommand { get; }

        public Command MeusVeiculosCommand { get; }

        public Command MinhasManutencoesCommand { get; }
    }
}
