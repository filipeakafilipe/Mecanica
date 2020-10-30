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
    public class SelecionarUsuarioVeiculoPageViewModel : ViewModelBase
    {
        public SelecionarUsuarioVeiculoPageViewModel(INavigationService navigationService) : base(navigationService)
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

            SelectedUsuarioVeiculoChangeCommand = new Command(async () =>
            {
                var perfilVM = SelectedPerfil;

                var dados = new NavigationParameters();
                dados.Add("id", perfilVM.Id);

                await navigationService.NavigateAsync("CadastrarVeiculoPage", dados);
            });
        }

        public List<Perfil> Perfis { get; set; }

        public Perfil SelectedPerfil { get; set; }

        public Command SelectedUsuarioVeiculoChangeCommand { get; }
    }
}
