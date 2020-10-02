using Prism;
using Prism.Ioc;
using App.ViewModels;
using App.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;

namespace App
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
#if DEBUG
            HotReloader.Current.Run(this);
#endif
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CriarPerfilPage, CriarPerfilPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<AcompanhamentoPerfilPage, AcompanhamentoPerfilPageViewModel>();
            containerRegistry.RegisterForNavigation<AlterarUsuarioPage, AlterarUsuarioPageViewModel>();
            containerRegistry.RegisterForNavigation<CriarTipoDeServicoPage, CriarTipoDeServicoPageViewModel>();
            containerRegistry.RegisterForNavigation<AcompanhamentoTipoDeServicoPage, AcompanhamentoTipoDeServicoPageViewModel>();
            containerRegistry.RegisterForNavigation<AlterarTipoDeServicoPage, AlterarTipoDeServicoPageViewModel>();
            containerRegistry.RegisterForNavigation<CadastrarVeiculoPage, CadastrarVeiculoPageViewModel>();
            containerRegistry.RegisterForNavigation<SelecionarUsuarioVeiculoPage, SelecionarUsuarioVeiculoPageViewModel>();
            containerRegistry.RegisterForNavigation<AcompanhamentoVeiculoPage, AcompanhamentoVeiculoPageViewModel>();
            containerRegistry.RegisterForNavigation<AlterarVeiculoPage, AlterarVeiculoPageViewModel>();
            containerRegistry.RegisterForNavigation<SelecionarUsuarioPedidoPage, SelecionarUsuarioPedidoPageViewModel>();
            containerRegistry.RegisterForNavigation<SelecionarVeiculoPedidoPage, SelecionarVeiculoPedidoPageViewModel>();
            containerRegistry.RegisterForNavigation<CriarPedidoPage, CriarPedidoPageViewModel>();
            containerRegistry.RegisterForNavigation<AcompanhamentoPedidoPage, AcompanhamentoPedidoPageViewModel>();
            containerRegistry.RegisterForNavigation<AlterarPedidoPage, AlterarPedidoPageViewModel>();
        }
    }
}
