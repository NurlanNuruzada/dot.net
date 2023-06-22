
using Microsoft.EntityFrameworkCore;
using Pronia.DataAcces.DBContext;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
