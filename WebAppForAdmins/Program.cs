using Microsoft.EntityFrameworkCore;
using DbContextProfi.Extensions;
using Repositories.Extensions;
using Services.Extensions;
using WebAppForAdmins.UserContext.Interfaces;
using WebAppForAdmins.UserContext;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            _ => "Это поле является обязательным.");
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(_ => "Некорректное значение поля.");
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(_ => "Значением поля должно быть число.");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((_, _) => "Некорректное значение поля.");
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

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
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
