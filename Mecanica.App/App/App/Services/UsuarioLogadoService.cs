using App.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services
{
    public class UsuarioLogadoService : IUsuarioLogado
    {
        private Perfil _Usuario { get; set; }

        public UsuarioLogadoService()
        {
            _Usuario = new Perfil();
        }

        public Perfil GetUsuarioLogado()
        {
            return _Usuario;
        }

        public void SetUsuarioLogado(Perfil usuario)
        {
            _Usuario = usuario;
        }
    }
}
