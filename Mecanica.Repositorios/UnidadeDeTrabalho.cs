using Mecanica.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mecanica.Repositorios
{
    public class UnidadeDeTrabalho
    {
        public UnidadeDeTrabalho()
        {
            VeiculoRepositorio = new VeiculoRepositorio();
            TipoDeServicoRepositorio = new TipoDeServicoRepositorio();
            SLARepositorio = new SLARepositorio();
            RoleRepositorio = new RoleRepositorio();
            PerfilRepositorio = new PerfilRepositorio();
            PedidoRepositorio = new PedidoRepositorio();
        }

        public VeiculoRepositorio VeiculoRepositorio { get; set; }
        public TipoDeServicoRepositorio TipoDeServicoRepositorio { get; set; }
        public SLARepositorio SLARepositorio { get; set; }
        public RoleRepositorio RoleRepositorio { get; set; }
        public PerfilRepositorio PerfilRepositorio { get; set; }
        public PedidoRepositorio PedidoRepositorio { get; set; }
    }
}
