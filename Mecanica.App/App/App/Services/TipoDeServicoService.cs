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
            await $"{Base.Uri}api/tipodeservico".PostJsonAsync(tipoDeServico);
        }

        public static Task<List<TipoDeServico>> GetTipoDeServicos()
        {
            return $"{Base.Uri}api/tipodeservico/todos".GetJsonAsync<List<TipoDeServico>>();
        }

        public static async Task Alterar(TipoDeServico tipoDeServico)
        {
            await $"{Base.Uri}api/tipodeservico/".PutJsonAsync(tipoDeServico);
        }
    }
}
