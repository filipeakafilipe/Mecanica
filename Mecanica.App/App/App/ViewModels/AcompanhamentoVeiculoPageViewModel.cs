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
    public class AcompanhamentoVeiculoPageViewModel : ViewModelBase
    {
        public AcompanhamentoVeiculoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Veículos";

            try
            {
                Veiculos = VeiculoService.GetVeiculos().Result;
            }
            catch
            {
                navigationService.NavigateAsync("MenuPage");
            }

            SelectedVeiculoChangeCommand = new Command(async () =>
            {
                var veiculoVM = SelectedVeiculo;

                var dados = new NavigationParameters();
                dados.Add("id", veiculoVM.Id);
                dados.Add("perfil", veiculoVM.Perfil);
                dados.Add("perfilId", veiculoVM.PerfilId);
                dados.Add("marca", veiculoVM.Marca);
                dados.Add("nome", veiculoVM.Nome);
                dados.Add("especificacao", veiculoVM.Especificacao);
                dados.Add("ano", veiculoVM.Ano);
                dados.Add("modelo", veiculoVM.Modelo);
                dados.Add("kilometragem", veiculoVM.Kilometragem);
                dados.Add("placa", veiculoVM.Placa);

                await navigationService.NavigateAsync("AlterarVeiculoPage", dados);
            });
        }

        public List<Veiculo> Veiculos { get; set; }

        public Veiculo SelectedVeiculo { get; set; }

        public Command SelectedVeiculoChangeCommand { get; }
    }
}
