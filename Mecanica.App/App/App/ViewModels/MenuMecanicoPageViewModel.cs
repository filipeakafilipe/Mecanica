using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class MenuMecanicoPageViewModel : ViewModelBase
    {
        public MenuMecanicoPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Menu";

            AcompanhamentoPedidosAtuaisCommand = new Command(async () =>
            {
                await navigationService.NavigateAsync("AcompanhamentoPedidosAtuaisPage");
            });
        }

        public Command AcompanhamentoPedidosAtuaisCommand { get; }
    }
}
