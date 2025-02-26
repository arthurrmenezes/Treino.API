using Microsoft.EntityFrameworkCore;
using Treino.API.Models;

namespace TreinoAPI.DataBase;

public class TreinoContext : DbContext
{
    public DbSet<TreinoModel> Treinos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=ULTRANOTE;Initial Catalog=TreinoAPI;" +
            "Integrated Security=True;Trust Server Certificate=True");
    }
}
