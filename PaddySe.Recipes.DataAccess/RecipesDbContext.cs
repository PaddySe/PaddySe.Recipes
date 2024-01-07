using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaddySe.Recipes.DataAccess.Entities;
using PaddySe.Recipes.DataAccess.Interceptors;

namespace PaddySe.Recipes.DataAccess;

public class RecipesDbContext(DbContextOptions<RecipesDbContext> options) : IdentityDbContext(options)
{
	public DbSet<Category> Categories { get; set; } = null!;

	public DbSet<Ingredient> Ingredients { get; set; } = null!;

	public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;

	public DbSet<Recipe> Recipes { get; set; } = null!;

	public DbSet<Step> Steps { get; set; } = null!;

	public DbSet<Tag> Tags { get; set; } = null!;

	public DbSet<Unit> Units { get; set; } = null!;

	#region Overrides

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.AddInterceptors(
									   TrackCreationInterceptor.Instance.Value,
									   TrackModificationInterceptor.Instance.Value
									  );

		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Unit>()
			   .Property(u => u.BaseUnitType)
			   .HasConversion<string>();

		base.OnModelCreating(builder);
	}

	#endregion
}
