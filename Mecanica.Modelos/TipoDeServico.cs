using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mecanica.Modelos
{
    public class TipoDeServico
    {
        public TipoDeServico()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Observacoes { get; set; }
    }
}
