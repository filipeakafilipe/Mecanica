using App.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services
{
    public interface IUsuarioLogado
    {
        Perfil GetUsuarioLogado();

        void SetUsuarioLogado(Perfil usuario);
    }
}
