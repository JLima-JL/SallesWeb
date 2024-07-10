using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.Services;


var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
builder.Services.AddDbContext<WebApplication1Context>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("WebApplication1");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});

// Registrar o servi�o de seeding
builder.Services.AddScoped<SeedingService>();
// Registrar servi�o de Sellers
builder.Services.AddScoped<SellerService>();

// Adicionar controladores com views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Chamar o servi�o de seeding
SeedDatabase(app);

void SeedDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}

// Configurar o pipeline de requisi��es HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
