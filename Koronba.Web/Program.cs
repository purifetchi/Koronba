using Koronba.Core;
using Koronba.External;
using Koronba.Core.Configuration;
using Hangfire;
using Koronba.External.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<KoronbaCoreConfiguration>(
    builder.Configuration.GetSection("KoronbaCoreConfiguration")
);

builder.Services.Configure<KoronbaExternalConfiguration>(
    builder.Configuration.GetSection("KoronbaExternalConfiguration")
);

builder.Services
    .AddHangfire(c => 
        c.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseInMemoryStorage());

builder.Services
    .AddHangfireServer()
    .AddKoronbaCore()
    .AddKoronbaExternal()
    .AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseHangfireDashboard("/hangfire");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();