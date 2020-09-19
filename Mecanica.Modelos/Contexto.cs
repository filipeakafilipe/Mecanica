using Microsoft.EntityFrameworkCore;

namespace Mecanica.Modelos
{
    public class Contexto : DbContext
    {
        //public Contexto(DbContextOptions<Contexto> options) : base(options) { }

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
    }
}
