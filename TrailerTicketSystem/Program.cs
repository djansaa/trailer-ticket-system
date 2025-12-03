using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();

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
        o.Cookie.SameSite = SameSiteMode.Strict; // mitigate CSRF
        o.Cookie.HttpOnly = true; // mitigate XSS
        o.Cookie.SecurePolicy = CookieSecurePolicy.Always; // require HTTPS
    });

builder.Services.AddAuthorization(o =>
{
    // all controllers require authenticated users by default (except Account - [AllowAnonymous])
    o.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    o.AddPolicy("MechanicOnly", p => p.RequireRole("mechanic"));
    o.AddPolicy("TechnicianOnly", p => p.RequireRole("technician"));
    o.AddPolicy("AdminOnly", p => p.RequireRole("admin"));
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
