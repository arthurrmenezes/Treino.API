using Microsoft.EntityFrameworkCore;
using TreinoAPI.Modelos;

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
