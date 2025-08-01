using Coravel;
using FictionBranches.Web.Components;
using FictionBranches.Web.Configuration;
using FictionBranches.Web.Data;
using FictionBranches.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString).UseLowerCaseNamingConvention());

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
