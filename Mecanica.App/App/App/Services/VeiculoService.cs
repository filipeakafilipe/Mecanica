using App.Modelos;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public static class VeiculoService
    {
        public static async Task Cadastrar(Veiculo veiculo)
        {
            await $"{Base.Uri}api/veiculo".PostJsonAsync(veiculo);
        }

        public static Task<List<Veiculo>> GetVeiculos()
        {
            return $"{Base.Uri}api/veiculo/todos".GetJsonAsync<List<Veiculo>>();
        }

        public static Task<List<Veiculo>> GetVeiculosCliente(int PerfilId)
        {
            return $"{Base.Uri}api/veiculo/cliente/{PerfilId}".GetJsonAsync<List<Veiculo>>();
        }

        public static async Task Alterar(Veiculo veiculo)
        {
            await $"{Base.Uri}api/veiculo/".PutJsonAsync(veiculo);
        }
    }
}
