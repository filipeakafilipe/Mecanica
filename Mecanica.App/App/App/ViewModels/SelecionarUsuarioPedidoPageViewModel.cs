using App.Modelos;
using App.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class SelecionarUsuarioPedidoPageViewModel : ViewModelBase
    {
        public SelecionarUsuarioPedidoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Usuários";

            try
            {
                Perfis = PerfilService.GetPerfis().Result;
            }
            catch
            {
                navigationService.NavigateAsync("MenuPage");
            }

            SelectedUsuarioPedidoChangeCommand = new Command(async () =>
            {
                var perfilVM = SelectedPerfil;

                var dados = new NavigationParameters();
                dados.Add("perfilId", perfilVM.Id);

                await navigationService.NavigateAsync("SelecionarVeiculoPedidoPage", dados);
            });
        }

        public List<Perfil> Perfis { get; set; }

        public Perfil SelectedPerfil { get; set; }

        public Command SelectedUsuarioPedidoChangeCommand { get; }
    }
}
