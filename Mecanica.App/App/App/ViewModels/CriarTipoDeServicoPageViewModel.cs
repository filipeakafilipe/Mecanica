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
    public class CriarTipoDeServicoPageViewModel : ViewModelBase
    {
        public CriarTipoDeServicoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Criar tipo de serviço";

            CadastrarCommand = new Command(async () =>
            {
                var tipoDeServico = new TipoDeServico()
                {
                    Nome = Nome,
                    Observacoes = Observacoes
                };

                try
                {
                    await TipoDeServicoService.Cadastrar(tipoDeServico);
                }
                catch
                {
                    await navigationService.NavigateAsync("MenuPage");
                }
            });
        }

        public string Nome { get; set; }

        public string Observacoes { get; set; }

        public Command CadastrarCommand { get; }
    }
}
