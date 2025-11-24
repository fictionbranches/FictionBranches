using Coravel;
using FictionBranches.Web.Components;
using FictionBranches.Web.Configuration;
using FictionBranches.Web.Data;
using FictionBranches.Web.Data.Models;
using FictionBranches.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseNpgsql(connectionString).UseLowerCaseNamingConvention());

builder.Services.AddIdentity<Fbuser, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = false;
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager<CustomSignInManager<Fbuser>>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/fb/account/login";
    options.LogoutPath = "/fb/account/logout";
    options.AccessDeniedPath = "/fb/AccessDenied";
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<IPasswordHasher<Fbuser>, BCryptPasswordHasher<Fbuser>>();
builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.Configure<FictionBranchesOptions>(builder.Configuration.GetSection(FictionBranchesOptions.Section));

builder.Services.AddSingleton<RootEpisodeCache>();
builder.Services.AddScoped<RootEpisodeCacheUpdater>();

builder.Services.AddQueue();
builder.Services.AddScheduler();

var app = builder.Build();

// Check for migration command line argument
if (args.Contains("--migrate") || args.Contains("migrate"))
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        Console.WriteLine("Applying migrations...");
        context.Database.Migrate();
        Console.WriteLine("Migrations applied successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
        return 1; // Exit with error code
    }
    return 0; // Exit successfully
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetService<RootEpisodeCacheUpdater>()!.Invoke();
}

app.Services.UseScheduler(scheduler =>
{
    scheduler.Schedule<RootEpisodeCacheUpdater>().EveryFiveMinutes();
});

app.Run();

return 0;