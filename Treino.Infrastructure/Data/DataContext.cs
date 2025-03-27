using Microsoft.EntityFrameworkCore;
using TreinoApp.Domain.BoundedContexts.UsuarioContext.Entities;

namespace TreinoApp.Infrastructure.Data;

public sealed class DataContext : DbContext
{
    public DbSet<Treino> Treinos { get; set; }

    public DataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseNpgsql();
    }
}
