using Identity.Data;
using Identity.DataSeeding;
using Identity.Models;
using Identity.Models.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
    AddEntityFrameworkStores<ApplicationDbContext>().
    AddDefaultTokenProviders();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();


builder.Services.AddRazorPages();
builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(CommanIdentityDetails.GetIdentityResources)
.AddInMemoryApiScopes(CommanIdentityDetails.GetApiScopes)
.AddInMemoryClients(CommanIdentityDetails.Clients)
.AddAspNetIdentity<ApplicationUser>()
.AddDeveloperSigningCredential();




var app = builder.Build();

void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitilizer = scope.ServiceProvider
            .GetRequiredService<IDbInitializer>();
        dbInitilizer.Initialize();

    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages().RequireAuthorization();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
DataSeeding();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
