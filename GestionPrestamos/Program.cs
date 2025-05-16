using GestionPrestamos.Components;
using GestionPrestamos.DAL;
using Microsoft.EntityFrameworkCore;
using GestionPrestamos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();




var ConStr = builder.Configuration.GetConnectionString("SQLiteConnection");

builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlite(ConStr));

//Inyeccion del PrestamosServicies
builder.Services.AddScoped<PrestamosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
