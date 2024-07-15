using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;


var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddDbContext<WebApplication1Context>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("WebApplication1");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});

// Registrar o serviço de seeding
builder.Services.AddScoped<SeedingService>();
// Registrar serviço de Sellers
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();

// Adicionar controladores com views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Chamar o serviço de seeding
SeedDatabase(app);

void SeedDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}

// Configurar o pipeline de requisições HTTP.
if (!app.Environment.IsDevelopment())
{
    var enUS = new CultureInfo("en-US");
    var localizationOption = new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture(enUS),
        SupportedCultures = new List<CultureInfo> { enUS },
        SupportedUICultures = new List<CultureInfo> { enUS }
    };
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
