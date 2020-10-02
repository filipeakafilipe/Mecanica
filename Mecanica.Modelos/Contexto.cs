using Microsoft.EntityFrameworkCore;

namespace Mecanica.Modelos
{
    public class Contexto : DbContext
    {
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<TipoDeServico> TipoDeServicos { get; set; }
        public DbSet<SLA> SLAs { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=Mecanica;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SLA>().HasData(
                    new SLA() { Id = 1, Nome = "Criado" },
                    new SLA() { Id = 2, Nome = "Em trabalho" },
                    new SLA() { Id = 3, Nome = "Finalizado" }
                );

            modelBuilder.Entity<Role>().HasData(
                    new Role() { Id = 1, Nome = "Administrador" },
                    new Role() { Id = 2, Nome = "Mecânico" },
                    new Role() { Id = 3, Nome = "Cliente" }
                );
        }
    }
}
