using EmailTemplateUI.Services;
using Microsoft.EntityFrameworkCore;
using EmailTemplateUI.Models;

var builder = WebApplication.CreateBuilder(args);

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("DBConnection");
builder.Services.AddDbContext<EmailTemplatesContext>(option => option.UseSqlServer(connectionString));
//builder.Services.AddDbContext<EmailTemplatesContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ITemplatesDB, TemplatesDB>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Template/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
