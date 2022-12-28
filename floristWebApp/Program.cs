using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

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