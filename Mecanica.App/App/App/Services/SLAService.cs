using App.Modelos;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class SLAService
    {
        public static Task<List<SLA>> GetTodos()
        {
            return $"{Base.Uri}api/sla".GetJsonAsync<List<SLA>>();
        }
    }
}
