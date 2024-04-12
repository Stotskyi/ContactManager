using ContactManager.DAL;
using ContactManager.DAL.Db;
using ContactManager.DAL.Models;
using ContactManager.DAL.Repo;
using ContactManager.DAL.Repo.Interfaces;
using ContactManager.Services;
using ContactManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
    options.EnableDetailedErrors();
});
builder.Services.AddScoped<ICsvService, CsvService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
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
app.UseCors(opts =>
{
    opts.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();