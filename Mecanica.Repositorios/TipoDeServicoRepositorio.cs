using Mecanica.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Mecanica.Repositorios
{
    public class TipoDeServicoRepositorio : BaseRepositorio
    {
        public TipoDeServicoRepositorio():base()
        {

        }

        public TipoDeServico Get(Guid id)
        {
            return db.TipoDeServicos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Adicionar(TipoDeServico tipoDeServico)
        {
            db.TipoDeServicos.Add(tipoDeServico);

            db.SaveChanges();
        }

        public void Remover(Guid id)
        {
            var tipoDeServico = db.TipoDeServicos.Where(v => v.Id == id).FirstOrDefault();

            db.TipoDeServicos.Remove(tipoDeServico);

            db.SaveChanges();
        }

        public void Atualizar(Guid id, TipoDeServico novoTipoDeServico)
        {
            var tipoDeServico = Get(id);

            tipoDeServico = novoTipoDeServico;

            db.Entry(tipoDeServico).State = EntityState.Modified;

            db.SaveChanges();
        }
    }
}
