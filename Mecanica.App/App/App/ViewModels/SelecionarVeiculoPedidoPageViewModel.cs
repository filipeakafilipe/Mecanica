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
    public class SelecionarVeiculoPedidoPageViewModel : ViewModelBase
    {
        public SelecionarVeiculoPedidoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Selecionar veículo";

            SelectedVeiculoPedidoChangeCommand = new Command(async () =>
            {
                var veiculoVM = SelectedVeiculo;

                var dados = new NavigationParameters();
                dados.Add("veiculoId", veiculoVM.Id);

                await navigationService.NavigateAsync("CriarPedidoPage", dados);
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            PerfilId = parameters.GetValue<int>("perfilId");

            try
            {

                Veiculos = VeiculoService.GetVeiculosCliente(PerfilId).Result;
            }
            catch
            {
                NavigationService.NavigateAsync("MenuPage");
            }
        }

        private int _PerfilId;

        public int PerfilId
        {
            get { return _PerfilId; }
            set { SetProperty(ref _PerfilId, value); }
        }

        private List<Veiculo> _Veiculos;

        public List<Veiculo> Veiculos
        {
            get { return _Veiculos; }
            set { SetProperty(ref _Veiculos, value); }
        }

        public Veiculo SelectedVeiculo { get; set; }

        public Command SelectedVeiculoPedidoChangeCommand { get; }
    }
}
