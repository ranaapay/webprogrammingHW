using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IFloristClient, FloristClient>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ApiSettings:FloristWebApiUrl"]));

builder.Services.AddSession();

//builder.Services.AddAuthentication();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/Home/LogIn");
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
app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{Action=Index}");
});

app.Run();