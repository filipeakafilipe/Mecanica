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
    public class MeusVeiculosPageViewModel : ViewModelBase
    {
        public MeusVeiculosPageViewModel(INavigationService navigationService, IUsuarioLogado usuarioLogadoService) : base(navigationService)
        {
            Title = "Meus Veículos";

            Usuario = usuarioLogadoService.GetUsuarioLogado();

            try
            {
                Veiculos = VeiculoService.GetVeiculosCliente(Usuario.Id).Result;

                Quantidade = Veiculos.Count;
            }
            catch
            {
                navigationService.NavigateAsync("MenuClientePage");
            }
        }

        public Perfil Usuario { get; set; }

        public int Quantidade { get; set; }

        public List<Veiculo> Veiculos { get; set; }

        public Veiculo SelectedVeiculo { get; set; }

        public Command SelectedVeiculoChangeCommand { get; }
    }
}
