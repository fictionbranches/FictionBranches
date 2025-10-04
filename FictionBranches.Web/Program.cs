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
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString).UseLowerCaseNamingConvention());

builder.Services.AddIdentity<Fbuser, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = false;
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager<CustomSignInManager<Fbuser>>();

// builder.Services.AddScoped<IUserStore<Fbuser>, UserOnlyStore<Fbuser, ApplicationDbContext>>();
builder.Services.AddScoped<IPasswordHasher<Fbuser>, BCryptPasswordHasher<Fbuser>>();
builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.Configure<FictionBranchesOptions>(builder.Configuration.GetSection(FictionBranchesOptions.Section));

builder.Services.AddSingleton<RootEpisodeCache>();
builder.Services.AddScoped<RootEpisodeCacheUpdater>();

builder.Services.AddQueue();
builder.Services.AddScheduler();

var app = builder.Build();

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
