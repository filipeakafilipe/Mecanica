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
    public class MenuPageViewModel : ViewModelBase
    {
        public MenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Menu";

            CriarPerfilCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("CriarPerfilPage");
            });

            AcompanhamentoPerfilCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("AcompanhamentoPerfilPage");
            });

            CriarTipoDeServicoCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("CriarTipoDeServicoPage");
            });

            AcompanhamentoTipoDeServicoCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("AcompanhamentoTipoDeServicoPage");
            });

            SelecionarUsuarioPedidoCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("SelecionarUsuarioPedidoPage");
            });

            AcompanhamentoPedidoCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("AcompanhamentoPedidoPage");
            });

            AcompanhamentoPedidosAtuaisCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("AcompanhamentoPedidosAtuaisPage");
            });

            SelecionarUsuarioVeiculoCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("SelecionarUsuarioVeiculoPage");
            });

            AcompanhamentoVeiculoCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("AcompanhamentoVeiculoPage");
            });
        }

        public Command CriarPerfilCommand { get; }

        public Command AcompanhamentoPerfilCommand { get; }

        public Command CriarTipoDeServicoCommand { get; }

        public Command AcompanhamentoTipoDeServicoCommand { get; }

        public Command SelecionarUsuarioPedidoCommand { get; }

        public Command AcompanhamentoPedidoCommand { get; }

        public Command AcompanhamentoPedidosAtuaisCommand { get; }

        public Command SelecionarUsuarioVeiculoCommand { get; }

        public Command AcompanhamentoVeiculoCommand { get; }
    }
}
