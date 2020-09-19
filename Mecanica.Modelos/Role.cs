using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mecanica.Modelos
{
    public class Role
    {
        public Role()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
