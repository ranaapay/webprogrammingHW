using System;
using floristWebApp.Client.FloristApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();

builder.Services.AddSession();
//builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IFloristClient, FloristClient>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ApiSettings:FloristWebApiUrl"]));


builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/Home/Login");
    opt.Cookie.Name = "FloristAspNetCore";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();
//add node_modules by npm
/*app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/content",
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules"))
});
*/
app.UseStaticFiles();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
    //endpoints.MapDefaultControllerRoute();
    app.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{Action=Index}/{id?}");
    
});

app.Run();