using Mecanica.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecanica.Repositorios
{
    public class PerfilRepositorio : BaseRepositorio, IPerfilRepository<Perfil>
    {
        public PerfilRepositorio() : base()
        {

        }

        public Perfil Get(int id)
        {
            return db.Perfils.Where(v => v.Id == id).AsNoTracking().FirstOrDefault();
        }

        public Perfil Get(string login)
        {
            return db.Perfils.Where(v => v.Login == login).AsNoTracking().FirstOrDefault();
        }

        public void Adicionar(Perfil perfil)
        {
            db.Perfils.Add(perfil);

            db.SaveChanges();
        }

        public void Remover(int id)
        {
            var perfil = db.Perfils.Where(v => v.Id == id).FirstOrDefault();

            db.Perfils.Remove(perfil);

            db.SaveChanges();
        }

        public void Atualizar(int id, Perfil novoPerfil)
        {
            var perfil = Get(id);

            if (perfil != null)
            {
                perfil.Login = novoPerfil.Login;
                perfil.Nome = novoPerfil.Nome;
                perfil.RoleId = novoPerfil.RoleId;
                perfil.Senha = novoPerfil.Senha;
                perfil.Telefone = novoPerfil.Telefone;

                db.Entry(perfil).State = EntityState.Modified;

                db.SaveChanges();
            }

        }

        public List<Perfil> GetTodos()
        {
            return db.Perfils.ToList();
        }

        public Perfil Login(string login, string senha)
        {
            return db.Perfils.FirstOrDefault(p => p.Login == login && p.Senha == senha);
        }
    }
}
