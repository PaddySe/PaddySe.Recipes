using System.ComponentModel.DataAnnotations;
using PaddySe.Recipes.DataAccess.Interfaces;

namespace PaddySe.Recipes.DataAccess.Entities;

public class Tag : ITrackCreation
{
	public string? Description { get; set; }

	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = string.Empty;

	public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

	public DateTime CreatedDate { get; set; }
}
