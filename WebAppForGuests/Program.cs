using DbContextProfi.Extensions;
using Microsoft.EntityFrameworkCore;
using Repositories.Extensions;
using Services.Extensions;

//Guests
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var mvcBuilder = builder.Services.AddControllersWithViews();

//if (builder.Environment.IsDevelopment())
//{
//    mvcBuilder.AddRazorRuntimeCompilation();
//}

var connectionString = builder.Configuration.GetConnectionString("DataBase");

//    Db UseSqlServer
if (string.IsNullOrEmpty(connectionString))
    throw new ArgumentNullException(nameof(connectionString));

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();