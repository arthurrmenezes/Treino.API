using Microsoft.EntityFrameworkCore;
using TreinoAPI.Modelos;

namespace TreinoAPI.DataBase;

public class TreinoContext : DbContext
{
    public DbSet<Treino> Treinos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }
}
