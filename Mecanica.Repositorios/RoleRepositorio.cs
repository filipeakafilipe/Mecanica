using Mecanica.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public List<Role> GetTodos()
        {
            return db.Roles.ToList();
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

            if(role != null)
            {
                role.Nome = novaRole.Nome;

                db.Entry(role).State = EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
