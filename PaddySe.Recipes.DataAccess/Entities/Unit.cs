using System.ComponentModel.DataAnnotations;
using PaddySe.Recipes.DataAccess.Enums;
using PaddySe.Recipes.DataAccess.Interfaces;

namespace PaddySe.Recipes.DataAccess.Entities;

public class Unit : ITrackCreation
{
	public decimal BaseUnitQuantity { get; set; } = 1;

	[Required]
	public BaseUnitType BaseUnitType { get; set; } = BaseUnitType.Undefined;

	public string? Description { get; set; }

	public int Id { get; set; }

	[Required]
	public string LongName { get; set; } = string.Empty;

	[Required]
	public string Name { get; set; } = string.Empty;

	public DateTime CreatedDate { get; set; }
}
