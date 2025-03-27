using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using TopTenShop.Core.Convertors;
using TopTenShop.Core.Services;
using TopTenShop.Core.Services.Interface;
using TopTenShop.DataLayer.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
#region Athentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Login";
    option.LogoutPath = "/LogOut";
    option.ExpireTimeSpan = TimeSpan.FromDays(10);
});
#endregion

#region Context
builder.Services.AddDbContext<MyTopContext>(option => option.UseSqlServer(
    
"Data Source =. ; Initial Catalog = MyTopTen_DB ; Integrated Security = True"
    ));

#endregion

#region IOC

builder.Services.AddScoped<IUserService , UserService>();
builder.Services.AddTransient<IViewRenderService, RenderViewToString>();
#endregion

builder.Services.AddControllers(option => option.EnableEndpointRouting = false);

var app = builder.Build();

//app.UseMvc();

app.UseRouting();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseMvcWithDefaultRoute(); 
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")),
//    RequestPath = "/root/"
//});


//app.MapGet("/", () => "Hello World!");

app.Run();
