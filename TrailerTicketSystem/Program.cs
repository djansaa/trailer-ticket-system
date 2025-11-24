using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrailerTicketSystem.Data;
using TrailerTicketSystem.Models;
using TrailerTicketSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);

// add services to the container.
builder.Services.AddControllersWithViews();

// db
var cs = builder.Configuration["Db:ConnectionString"] ?? throw new InvalidOperationException("Missing Db:ConnectionString");
builder.Services.AddDbContextFactory<AppDbContext>(o => o.UseNpgsql(cs));

builder.Services.AddScoped<ITrailerRepository, TrailerRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = "/Account/Login";
        o.LogoutPath = "/Account/Logout";
        o.AccessDeniedPath = "/Account/AccessDenied";
        o.SlidingExpiration = true;
        o.ExpireTimeSpan = TimeSpan.FromHours(1);
        o.Cookie.Name = "TTSCookie";
    });

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("MechanicOnly", p => p.RequireRole("Mechanic"));
    o.AddPolicy("TechnicianOnly", p => p.RequireRole("Technician"));
    o.AddPolicy("AdminOnly", p => p.RequireRole("Admin"));
});

builder.Services.AddSingleton<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();

// build app
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
