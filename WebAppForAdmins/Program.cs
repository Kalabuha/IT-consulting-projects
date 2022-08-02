using Microsoft.EntityFrameworkCore;
using DbContextProfi.Extensions;
using Repositories.Extensions;
using Services.Extensions;
using WebAppForAdmins.UserContext.Interfaces;
using WebAppForAdmins.UserContext;

//Admins
var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddControllersWithViews();

//if (builder.Environment.IsDevelopment())
//{
//    mvcBuilder.AddRazorRuntimeCompilation();
//}

var connectionString = builder.Configuration.GetConnectionString("DataBase");

if (string.IsNullOrEmpty(connectionString))
    throw new ArgumentNullException(nameof(connectionString));

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContextAccessor>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Applications}/{action=Index}/{id?}");

app.Run();
