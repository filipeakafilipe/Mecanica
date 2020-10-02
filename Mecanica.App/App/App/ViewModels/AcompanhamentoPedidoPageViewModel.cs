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
    public class AcompanhamentoPedidoPageViewModel : ViewModelBase
    {
        public AcompanhamentoPedidoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Pedidos";

            try
            {
                Pedidos = PedidoService.GetPedidos().Result;
            }
            catch
            {
                navigationService.NavigateAsync("MenuPage");
            }

            SelectedPedidoChangeCommand = new Command(async () =>
                {
                    var pedidoVM = SelectedPedido;

                    var dados = new NavigationParameters();
                    dados.Add("id", pedidoVM.Id);
                    dados.Add("tipoDeServicoId", pedidoVM.TipoDeServicoId);
                    dados.Add("veiculoId", pedidoVM.VeiculoId);
                    dados.Add("valorMaoDeObra", pedidoVM.ValorMaoDeObra);
                    dados.Add("valorPecas", pedidoVM.ValorPecas);
                    dados.Add("SLA", pedidoVM.SLA);

                    await navigationService.NavigateAsync("AlterarPedidoPage", dados);
                });
        }

        public List<Pedido> Pedidos { get; set; }

        public Pedido SelectedPedido { get; set; }

        public Command SelectedPedidoChangeCommand { get; }
    }
}
