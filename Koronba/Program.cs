using Koronba.Core;
using Koronba.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<KoronbaCoreConfiguration>(
    builder.Configuration.GetSection("KoronbaCoreConfiguration")
);

builder.Services
    .AddKoronbaCore()
    .AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();