using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modelos
{
    public class Pedido
    {
        public int Id { get; set; }

        public TipoDeServico TipoDeServico { get; set; }

        public int TipoDeServicoId { get; set; }

        public Veiculo Veiculo { get; set; }

        public int VeiculoId { get; set; }

        public double ValorMaoDeObra { get; set; }

        public double ValorPecas { get; set; }

        public string SLA { get; set; }
    }
}
