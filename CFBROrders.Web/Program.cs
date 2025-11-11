using CFBROrders.SDK.DataModel;
using CFBROrders.SDK.Interfaces;
using CFBROrders.SDK.Interfaces.Services;
using CFBROrders.SDK.Repositories;
using CFBROrders.SDK.Services;
using CFBROrders.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Radzen;

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CFBROrdersConnectionString") ?? throw new InvalidOperationException("Connection string 'CFBROrdersConnectionString' not found.");

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddRadzenComponents();
builder.Services.AddServerSideBlazor();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin",
        policy => policy.RequireRole("Admin"));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.Cookie.SameSite = SameSiteMode.None;

    options.LoginPath = "/login";
    options.AccessDeniedPath = "/access-denied";
    options.SlidingExpiration = true;
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = false;
    options.Cookie.SameSite = SameSiteMode.None;
});

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
builder.Host.UseNLog();

CFBROrdersDatabaseFactory.Setup(connectionString);

//builder.Services.AddScoped<IOperationResult, DBOperationResult>();
builder.Services.AddScoped<IUnitOfWork, NPocoUnitOfWork>();
//builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ITerritoriesService, TerritoriesService>();
builder.Services.AddScoped<ITeamsService, TeamsService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();