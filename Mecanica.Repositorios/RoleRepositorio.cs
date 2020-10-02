using Mecanica.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Mecanica.Repositorios
{
    public class RoleRepositorio : BaseRepositorio
    {
        public RoleRepositorio() : base()
        {

        }

        public Role Get(int id)
        {
            return db.Roles.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Adicionar(Role role)
        {
            db.Roles.Add(role);

            db.SaveChanges();
        }

        public void Remover(int id)
        {
            var role = db.Roles.Where(v => v.Id == id).FirstOrDefault();

            db.Roles.Remove(role);

            db.SaveChanges();
        }

        public void Atualizar(int id, Role novaRole)
        {
            var role = Get(id);

            role = novaRole;

            db.Entry(role).State = EntityState.Modified;

            db.SaveChanges();
        }
    }
}
