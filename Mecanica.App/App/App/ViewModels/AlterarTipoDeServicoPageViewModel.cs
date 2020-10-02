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
    public class AlterarTipoDeServicoPageViewModel : ViewModelBase
    {
        public AlterarTipoDeServicoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Alterar tipo de serviço";

            AlterarCommand = new Command(async () =>
            {

                var tipoDeServico = new TipoDeServico()
                {
                    Id = Id,
                    Nome = Nome,
                    Observacoes = Observacoes
                };

                try
                {
                    await TipoDeServicoService.Alterar(tipoDeServico);
                }
                catch
                {
                    await navigationService.NavigateAsync("MenuPage");
                }
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Id = int.Parse(parameters.GetValue<string>("id"));
            Nome = parameters.GetValue<string>("nome");
            Observacoes = parameters.GetValue<string>("observacoes");
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private string _Nome;

        public string Nome
        {
            get { return _Nome; }
            set { SetProperty(ref _Nome, value); }
        }

        private string _Observacoes;

        public string Observacoes
        {
            get { return _Observacoes; }
            set { SetProperty(ref _Observacoes, value); }
        }

        public Command AlterarCommand { get; }
    }
}
