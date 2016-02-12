using PauloRodrigues.LojaVirtual.Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PauloRodrigues.LojaVirtual.Dominio.Repositorio
{
    public class EntityFrameDbContext: DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
        }
    }
}