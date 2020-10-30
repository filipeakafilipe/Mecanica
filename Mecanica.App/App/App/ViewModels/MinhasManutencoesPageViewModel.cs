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
    public class MinhasManutencoesPageViewModel : ViewModelBase
    {
        public MinhasManutencoesPageViewModel(INavigationService navigationService, IUsuarioLogado usuarioLogadoService) : base(navigationService)
        {
            Title = "Minhas Manutenções";

            try
            {
                Usuario = usuarioLogadoService.GetUsuarioLogado();

                Manutencoes = ManutencaoService.GetManutencoesCliente(Usuario);

                Quantidade = Manutencoes.Count;
            }
            catch
            {
                navigationService.NavigateAsync("MenuClientePage");
            }
        }

        public Perfil Usuario { get; set; }

        public List<Manutencao> Manutencoes { get; set; }

        public Manutencao SelectedManutencao { get; set; }

        public Command SelectedManutencaoChangeCommand { get; }

        public int Quantidade { get; set; }
    }
}
