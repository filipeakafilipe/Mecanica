using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modelos
{
    public class Perfil
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }
    }
}
