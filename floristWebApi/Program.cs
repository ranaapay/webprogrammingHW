using CompanyEmployees.Extensions;
using floristWebApi;
using floristWebApi.Entities;
using floristWebApi.Interfaces;
using floristWebApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureSqlContext();
builder.Services.ConfigureIdentity();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

builder.Services.AddIdentity<User, IdentityRole>();

var app = builder.Build();

var scope = app.Services
    .GetService<IServiceScopeFactory>()
    ?.CreateScope();

if (scope is not null)
{
    using (scope)
    { 
        var userManager = (UserManager<User>)scope.ServiceProvider.GetService(typeof(UserManager<User>));
        var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));

        IdentityInitializer.CreateAdmin(userManager, roleManager);
    }
}

/*
using (var scope = app.Services.CreateScope())
{
    //Resolve ASP .NET Core Identity with DI help
    // do you things here

    var userManager = (UserManager<User>)scope.ServiceProvider.GetService(typeof(UserManager < User >));
    var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));

    IdentityInitializer.CreateAdmin(userManager, roleManager);
}
*/

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
