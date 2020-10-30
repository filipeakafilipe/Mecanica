using App.Modelos;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public static class TipoDeServicoService
    {
        public static async Task Cadastrar(TipoDeServico tipoDeServico)
        {
            try
            {
            await $"{Base.Uri}api/tipodeservico".PostJsonAsync(tipoDeServico);
            }
            catch
            {
                throw new Exception();
            }
        }

        public static Task<List<TipoDeServico>> GetTipoDeServicos()
        {
            try
            {
            return $"{Base.Uri}api/tipodeservico/todos".GetJsonAsync<List<TipoDeServico>>();
            }
            catch
            {
                throw new Exception();
            }
        }

        public static async Task Alterar(TipoDeServico tipoDeServico)
        {
            try
            {
            await $"{Base.Uri}api/tipodeservico/".PutJsonAsync(tipoDeServico);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
