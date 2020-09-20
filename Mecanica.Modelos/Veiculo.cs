using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mecanica.Modelos
{
    public class Veiculo
    {
        public Veiculo()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Perfil Perfil { get; set; }

        [Required]
        public virtual int PerfilId { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Especificacao { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Kilometragem { get; set; }

        [Required]
        public string Placa { get; set; }
    }
}
