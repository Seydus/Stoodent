using HelloMVCWorld.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Razor Pages services to the dependency injection container.
builder.Services.AddRazorPages();

// Add Controllers services to the dependency injection container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=.\\sqlexpress;Initial Catalog=ABCDB;Integrated Security=True; TrustServerCertificate=True")));

// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Show detailed error page during development.
    app.UseMigrationsEndPoint();
}
else
{
    // Use custom error handling page.
    app.UseExceptionHandler("/Error");

    // Use HTTP Strict Transport Security (HSTS) for secure communication.
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Serve static files (e.g., CSS, JavaScript, images).
app.UseStaticFiles();

// Enable routing.
app.UseRouting();

// Enable Authentication
app.UseAuthentication();

// Enable authorization.
app.UseAuthorization();

app.MapRazorPages();

// Configure the default controller route.
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();

    endpoints.MapControllerRoute(
        name: "Home",
        pattern: "Home/{action}/{id?}",
        defaults: new { controller = "Home" }
    );

    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

// Start the application.
app.Run();
