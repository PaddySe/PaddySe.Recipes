using System.ComponentModel.DataAnnotations;

namespace PaddySe.Recipes.DataAccess.Enums;

public enum BaseUnitType
{
	Undefined,

	[Display(Name = "Grams")]
	Grams,

	[Display(Name = "Millilitres")]
	Millilitres,

	[Display(Name = "Pieces")]
	Pieces
}
