using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Users.API.DataBase;
using Users.API.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<RegisterService, RegisterService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<EmailService, EmailService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
});


builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
    opt => opt.SignIn.RequireConfirmedEmail = true)
    .AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
