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
    public class CadastrarVeiculoPageViewModel : ViewModelBase
    {
        public CadastrarVeiculoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Cadastrar veículo";

            CadastrarCommand = new Command(async () =>
                {
                    var veiculo = new Veiculo()
                    {
                        PerfilId = Id,
                        Marca = Marca,
                        Nome = Nome,
                        Especificacao = Especificacao,
                        Ano = int.Parse(Ano),
                        Modelo = Modelo,
                        Kilometragem = int.Parse(Kilometragem),
                        Placa = Placa
                    };

                    try
                    {
                        await VeiculoService.Cadastrar(veiculo);
                    }
                    catch
                    {
                        await navigationService.NavigateAsync("MenuPage");
                    }
                });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Id = parameters.GetValue<int>("id");
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        public Command CadastrarCommand { get; }

        public string Marca { get; set; }

        public string Nome { get; set; }

        public string Especificacao { get; set; }

        public string Ano { get; set; }

        public string Modelo { get; set; }

        public string Kilometragem { get; set; }

        public string Placa { get; set; }
    }
}
