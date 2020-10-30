using App.Enum;
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
    public class AcompanhamentoPedidosAtuaisPageViewModel : ViewModelBase
    {
        public AcompanhamentoPedidosAtuaisPageViewModel(INavigationService navigationService, UsuarioLogadoService usuarioLogadoService) : base(navigationService)
        {
            Title = "Pedidos Atuais";

            try
            {
                Pedidos = PedidoService.GetPedidosNaoFinalizados().Result;
            }
            catch
            {
                Usuario = usuarioLogadoService.GetUsuarioLogado();

                if (Usuario.RoleId == (int)RolesEnum.Administrador)
                {
                    navigationService.NavigateAsync("MenuPage");
                }
                else
                {
                    navigationService.NavigateAsync("MenuMecanicoPage");
                }
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

        public Perfil Usuario { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public Pedido SelectedPedido { get; set; }

        public Command SelectedPedidoChangeCommand { get; }
    }
}
