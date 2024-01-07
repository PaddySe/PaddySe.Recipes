using Microsoft.AspNetCore.Identity;
using PaddySe.Recipes.DataAccess.Interfaces;

namespace PaddySe.Recipes.DataAccess.Entities;

public class Recipe : ITrackCreation, ITrackModification
{
	public ICollection<Category> Categories { get; set; } = new List<Category>();

	public int? CookTime { get; set; }

	public DateTime CreatedDate { get; set; }

	public string Description { get; set; } = string.Empty;

	public int Id { get; set; }

	public string? ImageUrl { get; set; }

	public ICollection<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();

	public DateTime? LastModifiedDate { get; set; }

	public string Name { get; set; } = string.Empty;

	public IdentityUser Owner { get; set; } = null!;

	public int? PrepTime { get; set; }

	public int? Servings { get; set; }

	public string? SourceUrl { get; set; }

	public ICollection<Step> Steps { get; set; } = new List<Step>();

	public ICollection<Tag> Tags { get; set; } = new List<Tag>();

	public int? TotalTime { get; set; }
}
