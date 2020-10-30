using App.Modelos;
using App.Dictionary;
using App.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace App.ViewModels
{
    public class AlterarUsuarioPageViewModel : ViewModelBase
    {
        public AlterarUsuarioPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Alterar perfil";

            AlterarCommand = new Command(async () =>
            {
                if (Senha == SenhaConfirmada)
                {
                    var perfil = new Perfil()
                    {
                        Id = Id,
                        RoleId = SelectedItem.Key,
                        Nome = Nome,
                        Telefone = Telefone,
                        Login = Usuario,
                        Senha = Senha
                    };

                    try
                    {
                        await PerfilService.Alterar(perfil);
                    }
                    catch
                    {
                        await navigationService.NavigateAsync("MenuPage");
                    }
                }
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Id = int.Parse(parameters.GetValue<string>("id"));
            Nome = parameters.GetValue<string>("nome");
            Telefone = parameters.GetValue<string>("telefone");
            Usuario = parameters.GetValue<string>("login");
            Senha = parameters.GetValue<string>("senha");
            SenhaConfirmada = parameters.GetValue<string>("senha");

            var roleId = int.Parse(parameters.GetValue<string>("roleId"));
            SelectedItem = PickerItemList.Where(p => p.Key == roleId).FirstOrDefault();
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

        private string _Telefone;

        public string Telefone
        {
            get { return _Telefone; }
            set { SetProperty(ref _Telefone, value); }
        }

        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { SetProperty(ref _Usuario, value); }
        }

        private string _Senha;

        public string Senha
        {
            get { return _Senha; }
            set { SetProperty(ref _Senha, value); }
        }

        private string _SenhaConfirmada;

        public string SenhaConfirmada
        {
            get { return _SenhaConfirmada; }
            set { SetProperty(ref _SenhaConfirmada, value); }
        }

        private Dictionary<int, string> Roles = new RoleDictionary().Nomes;

        public Command AlterarCommand { get; }

        public List<KeyValuePair<int, string>> PickerItemList
        {
            get => Roles.ToList();
        }

        private KeyValuePair<int, string> _selectedItem;
        public KeyValuePair<int, string> SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
    }
}
