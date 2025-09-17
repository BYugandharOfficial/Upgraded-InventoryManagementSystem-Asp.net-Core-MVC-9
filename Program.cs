using DinkToPdf;
using DinkToPdf.Contracts;
using InevntoryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Business") ?? throw new InvalidOperationException("Connection string 'Business' not found.");
var connectionStringNew = builder.Configuration.GetConnectionString("Identity") ?? throw new InvalidOperationException("Connection string 'Identity' not found.");



// ---------------------------------------Database----------------------------------------------------
builder.Services.AddDbContext<AppDbContext>(optionsAction =>
optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("Business")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));



//----------------------------------------Identity Configuration----------------------------------------------------

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
   options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8; 
   
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



//--------------------------------Authentication Cookies---------------------------------------------
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.LoginPath = "/AccountsLogin/Login";
//    options.LogoutPath = "/AccountsNew/Logout";
//    options.AccessDeniedPath = "/AccountsNew/AccessDenied";
//    options.SlidingExpiration = true;
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Accounts/Login";
    options.AccessDeniedPath = "/AccountsLogin/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});




//---------------------------------------------MiddleWare--------------------------------------

// Add services to the container
builder.Services.AddControllersWithViews();

// Add Authentication + Authorization
builder.Services.AddAuthentication(); // (configure schemes if needed)
builder.Services.AddAuthorization();
builder.Services.AddRazorPages();

var app = builder.Build();
//var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    var db1 = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseMigrationsEndPoint();
} 
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




// other middleware
app.MapControllers();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");
//.WithStaticAssets();

app.MapRazorPages();


app.Run();

