using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Parcial2.Data;
using Parcial2.Services;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AlfajorContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("AlfajorContext") ?? throw new InvalidOperationException("Connection string 'AlfajorContext' not found.")));




// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMarcaService, MarcaService>();

builder.Services.AddScoped<IAlfajorService,AlfajorServices>();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
