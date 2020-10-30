using App.Modelos;
using App.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.ViewModels
{
    public class PerfilPageViewModel : ViewModelBase
    {
        public PerfilPageViewModel(INavigationService navigationService, IUsuarioLogado usuarioLogadoService) : base(navigationService)
        {
            Title = "Meu Perfil";

            Usuario = usuarioLogadoService.GetUsuarioLogado();
        }

        public Perfil Usuario { get; set; }
    }
}
