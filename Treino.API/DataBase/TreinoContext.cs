using Microsoft.EntityFrameworkCore;
using TreinoAPI.Modelos;

namespace TreinoAPI.DataBase;

public class TreinoContext : DbContext
{
    public DbSet<TreinoModel> Treinos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-SD3LB7D;Initial Catalog=Treino;" +
            "Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
    }
}
