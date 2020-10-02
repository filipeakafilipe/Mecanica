using App.Modelos;
using App.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class AlterarVeiculoPageViewModel : ViewModelBase
    {
        public AlterarVeiculoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Alterar veículo";

            AlterarCommand = new Command(async () =>
            {
                var veiculo = new Veiculo()
                {
                    Id = Id,
                    PerfilId = PerfilId,
                    Ano = Ano,
                    Especificacao = Especificacao,
                    Kilometragem = Kilometragem,
                    Marca = Marca,
                    Modelo = Modelo,
                    Nome = Nome,
                    Placa = Placa
                };

                try
                {
                    await VeiculoService.Alterar(veiculo);
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
            PerfilId = int.Parse(parameters.GetValue<string>("perfilId"));
            Marca = parameters.GetValue<string>("marca");
            Nome = parameters.GetValue<string>("nome");
            Especificacao = parameters.GetValue<string>("especificacao");
            Ano = int.Parse(parameters.GetValue<string>("ano"));
            Modelo = parameters.GetValue<string>("modelo");
            Kilometragem = int.Parse(parameters.GetValue<string>("kilometragem"));
            Placa = parameters.GetValue<string>("placa");
        }

        public Command AlterarCommand { get; }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private int _PerfilId;

        public int PerfilId
        {
            get { return _PerfilId; }
            set { SetProperty(ref _PerfilId, value); }
        }

        private string _Nome;

        public string Nome
        {
            get { return _Nome; }
            set { SetProperty(ref _Nome, value); }
        }

        private string _Marca;

        public string Marca
        {
            get { return _Marca; }
            set { SetProperty(ref _Marca, value); }
        }

        private string _Especificacao;

        public string Especificacao
        {
            get { return _Especificacao; }
            set { SetProperty(ref _Especificacao, value); }
        }

        private int _Ano;

        public int Ano
        {
            get { return _Ano; }
            set { SetProperty(ref _Ano, value); }
        }

        private string _Modelo;

        public string Modelo
        {
            get { return _Modelo; }
            set { SetProperty(ref _Modelo, value); }
        }

        private int _Kilometragem;

        public int Kilometragem
        {
            get { return _Kilometragem; }
            set { SetProperty(ref _Kilometragem, value); }
        }

        private string _Placa;

        public string Placa
        {
            get { return _Placa; }
            set { SetProperty(ref _Placa, value); }
        }
    }
}
