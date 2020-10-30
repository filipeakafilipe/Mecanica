using App.Modelos;
using App.Dictionary;
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
    public class AlterarPedidoPageViewModel : ViewModelBase
    {
        public AlterarPedidoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Alterar Pedido";

            AlterarCommand = new Command(async () =>
            {
                var pedido = new Pedido()
                {
                    Id = Id,
                    SLA = SelectedSLAItem.Value,
                    TipoDeServicoId = SelectedItem.Key,
                    ValorMaoDeObra = ValorMaoDeObra,
                    ValorPecas = ValorPecas,
                    VeiculoId = VeiculoId
                };

                try
                {
                    await PedidoService.Alterar(pedido);

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
            ValorMaoDeObra = parameters.GetValue<double>("valorMaoDeObra");
            ValorPecas = parameters.GetValue<double>("valorPecas");
            VeiculoId = parameters.GetValue<int>("veiculoId");

            var tipoDeServico = parameters.GetValue<int>("tipoDeServicoId");
            SelectedItem = PickerItemList.Where(p => p.Key == tipoDeServico).FirstOrDefault();

            var sla = parameters.GetValue<string>("SLA");
            SelectedSLAItem = PickerSLAItemList.Where(s => s.Value == sla).FirstOrDefault();
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        private int _VeiculoId;

        public int VeiculoId
        {
            get { return _VeiculoId; }
            set { SetProperty(ref _VeiculoId, value); }
        }


        private double _ValorMaoDeObra;

        public double ValorMaoDeObra
        {
            get { return _ValorMaoDeObra; }
            set { SetProperty(ref _ValorMaoDeObra, value); }
        }

        private double _ValorPecas;

        public double ValorPecas
        {
            get { return _ValorPecas; }
            set { SetProperty(ref _ValorPecas, value); }
        }

        public Command AlterarCommand { get; }

        private Dictionary<int, string> SLAs = new SLADictionary().Nomes;

        public List<KeyValuePair<int, string>> PickerSLAItemList
        {
            get => SLAs.ToList();
        }

        private KeyValuePair<int, string> _selectedSLAItem;
        public KeyValuePair<int, string> SelectedSLAItem
        {
            get => _selectedSLAItem;
            set => SetProperty(ref _selectedSLAItem, value);
        }

        public List<KeyValuePair<int, string>> PickerItemList
        {
            get => new TipoDeServico().PopulaTipos();
        }

        private KeyValuePair<int, string> _selectedItem;
        public KeyValuePair<int, string> SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
    }
}
