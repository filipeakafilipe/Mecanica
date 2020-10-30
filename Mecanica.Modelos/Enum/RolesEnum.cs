using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mecanica.Modelos.Enum
{
    public enum SLAEnum
    {
        Criado = 1,
        [Display(Name = "Em trabalho")]
        EmTrabalho = 2,
        Finalizado = 3
    }
}
