using App.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dictionary
{
    public class SLADictionary
    {
        public Dictionary<int, string> Nomes;

        public SLADictionary()
        {
            try
            {
                var slas = SLAService.GetTodos().Result;

                Nomes = new Dictionary<int, string>();

                foreach (var sla in slas)
                {
                    Nomes.Add(sla.Id, sla.Nome);
                }
            }
            catch
            {
                Nomes = new Dictionary<int, string>();
            }
        }
    }
}
