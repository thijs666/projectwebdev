using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projectwebdev.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Load the database connection from appsettings in a var
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// declare serverversion
// todo load from appsettings
var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

// Connect with MySQL Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Adjust the paths to the right URL
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login";
    config.AccessDeniedPath = "/AccessDenied";
});

// Register IHttpContextAccessor
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();