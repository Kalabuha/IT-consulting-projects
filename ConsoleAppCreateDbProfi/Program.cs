using Microsoft.Extensions.DependencyInjection;
using ConsoleAppCreateDbProfi.CreatorSystem;

var container = ContainerBuilder.Build("appsettings.json");

var creator = container.GetService<CreatorDbProfi>() ?? throw new ApplicationException("Не удалось создать creator");

creator.CreateDbProfi();