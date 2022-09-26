using DbContextProfi.Extensions;
using Microsoft.EntityFrameworkCore;
using DbRepositories.Extensions;
using AppearanceDataServices.Extensions;
using ContentDataServices.Extensions;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.RegisterDbRepositories();
builder.Services.RegisterAppearanceDataServices();
builder.Services.RegisterContentDataServices();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();