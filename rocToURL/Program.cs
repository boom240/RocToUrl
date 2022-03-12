using rocToURL.Abstractions;
using Microsoft.EntityFrameworkCore;
using rocToURL.Data;
using rocToURL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

//create and register db context
builder.Services.AddDbContext<rocToURLContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("rocToURLContext")));

// register types
builder.Services.AddScoped<IUrlService, UrlServiceImplementation>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
