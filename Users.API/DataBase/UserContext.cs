using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Users.API.DataBase;

public class UserContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    public UserContext() { }

    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}
