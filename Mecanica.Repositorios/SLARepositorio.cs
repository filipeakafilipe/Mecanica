using Mecanica.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecanica.Repositorios
{
    public class SLARepositorio : BaseRepositorio
    {
        public SLARepositorio() : base()
        {

        }

        public SLA Get(int id)
        {
            return db.SLAs.Where(v => v.Id == id).FirstOrDefault();
        }

        public List<SLA> GetTodos()
        {
            return db.SLAs.ToList();
        }

        public void Adicionar(SLA sla)
        {
            db.SLAs.Add(sla);

            db.SaveChanges();
        }

        public void Remover(int id)
        {
            var SLA = db.SLAs.Where(v => v.Id == id).FirstOrDefault();

            db.SLAs.Remove(SLA);

            db.SaveChanges();
        }

        public void Atualizar(int id, SLA novoSLA)
        {
            var SLA = Get(id);

            if(SLA != null)
            {
                SLA.Nome = novoSLA.Nome;

                db.Entry(SLA).State = EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
