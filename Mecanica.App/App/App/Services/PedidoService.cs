using App.Modelos;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public static class PedidoService
    {
        public static async Task Cadastrar(Pedido pedido)
        {
            try
            {
                await $"{Base.Uri}api/pedido".PostJsonAsync(pedido);
            }
            catch
            {
                throw new Exception();
            }
        }

        public static Task<List<Pedido>> GetPedidos()
        {
            try
            {
                return $"{Base.Uri}api/pedido/todos".GetJsonAsync<List<Pedido>>();
            }
            catch
            {
                throw new Exception();
            }
        }

        public static async Task Alterar(Pedido pedido)
        {
            try
            {
                await $"{Base.Uri}api/pedido/".PutJsonAsync(pedido);
            }
            catch
            {
                throw new Exception();
            }
        }

        public static Task<List<Pedido>> GetPedidosDoCliente(int idCliente)
        {
            try
            {
                return $"{Base.Uri}api/pedido/cliente/{idCliente}".GetJsonAsync<List<Pedido>>();
            }
            catch
            {
                throw new Exception();
            }
        }

        public static Task<List<Pedido>> GetPedidosNaoFinalizados()
        {
            try
            {
                return $"{Base.Uri}api/pedido/atuais".GetJsonAsync<List<Pedido>>();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
