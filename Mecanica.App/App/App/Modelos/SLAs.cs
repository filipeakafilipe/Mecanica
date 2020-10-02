using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modelos
{
    public class SLAs
    {
        // Alterar para pegar do banco

        public Dictionary<int, string> Nomes;

        public SLAs()
        {
            Nomes = new Dictionary<int, string>
            {
                {1, "SLA 1"},
                {2, "SLA 2"},
                {3, "SLA 3" }
            };
        }
    }
}
