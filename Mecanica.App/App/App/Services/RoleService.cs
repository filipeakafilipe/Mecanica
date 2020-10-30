using App.Modelos;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class RoleService
    {
        public static Task<List<Role>> GetTodos()
        {
            return $"{Base.Uri}api/role".GetJsonAsync<List<Role>>();
        }
    }
}
