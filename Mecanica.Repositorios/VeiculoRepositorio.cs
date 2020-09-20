using Mecanica.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Mecanica.Repositorios
{
    public class VeiculoRepositorio : BaseRepositorio
    {
        public VeiculoRepositorio() : base()
        {
        }

        public Veiculo Get(Guid id)
        {
            return db.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        } 

        public void Adicionar(Veiculo veiculo)
        {
            db.Veiculos.Add(veiculo);

            db.SaveChanges();
        }

        public void Remover(Guid id)
        {
            var veiculo = db.Veiculos.Where(v => v.Id == id).FirstOrDefault();

            db.Veiculos.Remove(veiculo);

            db.SaveChanges();
        }

        public void Atualizar(Guid id, Veiculo novoVeiculo)
        {
            var veiculo = Get(id);

            veiculo = novoVeiculo;

            db.Entry(veiculo).State = EntityState.Modified;

            db.SaveChanges();
        }
    }
}
