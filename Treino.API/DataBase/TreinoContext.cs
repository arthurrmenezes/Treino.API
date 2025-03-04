using Microsoft.EntityFrameworkCore;
using Treino.API.Models;

namespace TreinoAPI.DataBase;

public class TreinoContext : DbContext
{
    public DbSet<TreinoModel> Treinos { get; set; }

    public TreinoContext(DbContextOptions options) : base(options) { }

    protected TreinoContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }
}
