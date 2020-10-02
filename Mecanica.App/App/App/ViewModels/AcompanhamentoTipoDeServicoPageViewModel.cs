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
    public class AcompanhamentoTipoDeServicoPageViewModel : ViewModelBase
    {
        public AcompanhamentoTipoDeServicoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Tipo de serviços";

            try
            {
                TipoDeServicos = TipoDeServicoService.GetTipoDeServicos().Result;
            }
            catch
            {
                navigationService.NavigateAsync("MenuPage");
            }

            SelectedTipoDeServicoChangeCommand = new Command(async () =>
            {
                var tipoDeServicoVM = SelectedTipoDeServico;

                var dados = new NavigationParameters();
                dados.Add("id", tipoDeServicoVM.Id);
                dados.Add("nome", tipoDeServicoVM.Nome);
                dados.Add("observacoes", tipoDeServicoVM.Observacoes);

                await navigationService.NavigateAsync("AlterarTipoDeServicoPage", dados);
            });
        }

        public List<TipoDeServico> TipoDeServicos { get; set; }

        public TipoDeServico SelectedTipoDeServico { get; set; }

        public Command SelectedTipoDeServicoChangeCommand { get; }
    }
}


