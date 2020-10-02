using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modelos
{
    public class Veiculo
    {
        public int Id { get; set; }

        public Perfil Perfil { get; set; }

        public int PerfilId { get; set; }

        public string Marca { get; set; }

        public string Nome { get; set; }

        public string Especificacao { get; set; }

        public int Ano { get; set; }

        public string Modelo { get; set; }

        public int Kilometragem { get; set; }

        public string Placa { get; set; }
    }
}
