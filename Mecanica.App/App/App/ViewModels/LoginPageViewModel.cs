using App.Enum;
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
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService, IUsuarioLogado usuarioLogadoService) : base(navigationService)
        {
            Title = "Entrar";

            MenuPageCommand = new Command(async () =>
            {
                var usuario = new Perfil() { Login = Usuario, Senha = Senha };

                try
                {
                    var user = PerfilService.Logar(usuario).Result;

                        usuarioLogadoService.SetUsuarioLogado(user);

                    if (user.RoleId == (int)RolesEnum.Administrador)
                    {
                        await navigationService.NavigateAsync("MenuPage");
                    }
                    if (user.RoleId == (int)RolesEnum.Mecanico)
                    {
                        await navigationService.NavigateAsync("MenuMecanicoPage");
                    }
                    if (user.RoleId == (int)RolesEnum.Cliente)
                    {
                        await navigationService.NavigateAsync("MenuClientePage");
                    }
                }
                catch(Exception ex)
                {
                    await navigationService.NavigateAsync("LoginPage");
                }
            });
        }

        public Command MenuPageCommand { get; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }
}

