using Microsoft.AspNetCore.Identity;
using Users.API.DataBase;
using Users.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserContext>();
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
    .AddEntityFrameworkStores<UserContext>();

builder.Services.AddScoped<UserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
