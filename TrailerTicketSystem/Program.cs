using Microsoft.EntityFrameworkCore;
using TrailerTicketSystem.Data;
using TrailerTicketSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// load connection string from user-secrets
var cs = builder.Configuration["Db:ConnectionString"] ?? throw new InvalidOperationException("Missing Db:ConnectionString");

builder.Services.AddDbContextFactory<AppDbContext>(o => o.UseNpgsql(cs));

builder.Services.AddScoped<ITrailerRepository, TrailerRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
