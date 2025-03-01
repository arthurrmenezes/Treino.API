using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Users.API.DataBase;

public class UserContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    public string sqlStringConnectionUltra = "Data Source=ULTRANOTE;Initial Catalog=TreinoAPI;Integrated Security=True;Trust Server Certificate=True";

    public string sqlStringConnectionPersonalPc = "Data Source=DESKTOP-SD3LB7D;Initial Catalog=Treino;Integrated Security=True;Trust Server Certificate=True";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseSqlServer(sqlStringConnectionPersonalPc));
    }
}
