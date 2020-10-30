using App.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Dictionary
{
    public class RoleDictionary
    {
        public Dictionary<int, string> Nomes;

        public RoleDictionary()
        {
            try
            {
                var roles = RoleService.GetTodos().Result;

                Nomes = new Dictionary<int, string>();

                foreach (var role in roles)
                {
                    Nomes.Add(role.Id, role.Nome);
                }
            }
            catch
            {
                Nomes = new Dictionary<int, string>();
            }
        }
    }
}
