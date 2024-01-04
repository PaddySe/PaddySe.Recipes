using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaddySe.Recipes.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RecipesDbContext>(options =>
{
	var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
	options.UseSqlite(connetionString, optionsBuilder =>
	{
		optionsBuilder.MigrationsAssembly(typeof(RecipesDbContext).Assembly.FullName);
		optionsBuilder.MigrationsHistoryTable("_MigrationsHistory", "Recipes");
	}).EnableDetailedErrors();
});

if (builder.Environment.IsDevelopment())
{
	builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	   .AddEntityFrameworkStores<RecipesDbContext>();

var application = builder.Build();

// Configure the HTTP request pipeline.
if (!application.Environment.IsDevelopment())
{
	application.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	application.UseHsts();
}

application.UseHttpsRedirection()
		   .UseStaticFiles()
		   .UseRouting()
		   .UseAuthorization();

application.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
application.MapRazorPages();

ApplyMigrations(application);

await application.RunAsync();

return;

static void ApplyMigrations(WebApplication application)
{
	using (var scope = application.Services.CreateScope())
	{
		var db = scope.ServiceProvider.GetRequiredService<RecipesDbContext>();
		db.Database.Migrate();
	}
}
