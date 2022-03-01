using Microsoft.EntityFrameworkCore;
using TodoList.DataLayers;
using TodoList.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultContext");
builder.Services.AddEntityFrameworkSqlite().AddDbContext<DefaultContext>(options => options.UseSqlite(connectionString));

builder.Services.AddTransient<CategorieDataLayer, CategorieDataLayer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "apiEvent",
    pattern: "api/events",
    defaults: new
    {
        controller = "Event",
        action = "GetEvents"
    });

app.MapControllerRoute(
    name: "taches",
    pattern: "Mes-Taches",
    defaults: new
    {
        controller = "Tache",
        action = "Index"
    });

app.MapControllerRoute(
    name: "notes",
    pattern: "Mes-Notes",
    defaults: new
    {
        controller = "Note",
        action = "Index"
    });

app.MapControllerRoute(
    name: "events",
    pattern: "Mes-Events",
    defaults: new
    {
        controller = "Event",
        action = "Index"
    });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
