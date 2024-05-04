

using Core.Application.Extensions;
using Infrastructure.Persistance;
using Presentation.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddPresentationServices();


builder.Services.AddRedisServices(redisSettings=>
{
    redisSettings.ConnectionString = builder.Configuration.GetConnectionString("Redis");
    redisSettings.IsRedisOpen = builder.Configuration.GetSection("AppSettings").GetValue<bool>("RedisStatus");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapFallbackToController("CreatePage","Main");



app.Run();
