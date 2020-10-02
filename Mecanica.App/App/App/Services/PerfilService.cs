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
    public static class PerfilService
    {
        public static async Task Cadastrar(Perfil perfil)
        {
            await $"{Base.Uri}api/perfil".PostJsonAsync(perfil);
        }

        public static Task<List<Perfil>> GetPerfis()
        {
            return $"{Base.Uri}api/perfil/todos".GetJsonAsync<List<Perfil>>();
        }

        public static async Task Alterar(Perfil perfil)
        {
            await $"{Base.Uri}api/perfil/".PutJsonAsync(perfil);
        }
    }
}
