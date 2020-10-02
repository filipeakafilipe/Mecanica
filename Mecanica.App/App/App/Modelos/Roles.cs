using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modelos
{
    public class Roles
    {
        // Alterar para pegar do banco

        public Dictionary<int, string> Nomes;

        public Roles()
        {
            Nomes = new Dictionary<int, string>
            {
                {1, "Administrador"},
                {2, "Mecânico"},
                {3, "Cliente" }
            };
        }
    }
}
