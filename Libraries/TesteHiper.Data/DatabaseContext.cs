using Microsoft.EntityFrameworkCore;
using TesteHiper.Data.Entidade;

namespace TesteHiper.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>()
                .HasOne(e => e.Estoque)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.EstoqueId)
                .IsRequired();
        }
    }
}
