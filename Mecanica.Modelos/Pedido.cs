using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mecanica.Modelos
{
    public class Pedido
    {
        public Pedido()
        {
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual TipoDeServico TipoDeServico { get; set; }

        [Required]
        public int TipoDeServicoId { get; set; }

        public virtual Veiculo Veiculo { get; set; }

        [Required]
        public int VeiculoId { get; set; }

        [Required]
        public double ValorMaoDeObra { get; set; }

        [Required]
        public double ValorPecas { get; set; }

        [Required]
        public string SLA { get; set; }

        //[Required]
        //public double ValorTotal { get; set; }
    }
}
