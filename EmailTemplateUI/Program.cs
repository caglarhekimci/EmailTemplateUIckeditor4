using EmailTemplateUI.Services;
using Microsoft.EntityFrameworkCore;
using EmailTemplateUI.Models;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("DBConnection");
builder.Services.AddDbContext<EmailTemplatesContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ITemplatesDB, TemplatesDB>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Template/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Template}/{action=Index}/{id?}");

app.Run();
