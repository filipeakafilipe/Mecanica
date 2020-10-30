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

    public class CriarPerfilPageViewModel : ViewModelBase
    {
        public CriarPerfilPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Criar perfil";

            CadastrarCommand = new Command(async () =>
            {
                if (Senha == SenhaConfirmada)
                {
                    var perfil = new Perfil()
                    {
                        RoleId = SelectedItem.Key,
                        Nome = Nome,
                        Telefone = Telefone,
                        Login = Usuario,
                        Senha = Senha
                    };

                    try
                    {
                        await PerfilService.Cadastrar(perfil);
                    }
                    catch
                    {
                        await navigationService.NavigateAsync("MenuPage");
                    }
                }
            });
        }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string SenhaConfirmada { get; set; }

        private Dictionary<int, string> Roles = new RoleDictionary().Nomes;

        public Command CadastrarCommand { get; }

        public List<KeyValuePair<int, string>> PickerItemList
        {
            get => Roles.ToList();
        }

        private KeyValuePair<int, string> _selectedItem;
        public KeyValuePair<int, string> SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }
    }
}
