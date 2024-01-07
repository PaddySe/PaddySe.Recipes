namespace PaddySe.Recipes.DataAccess.Entities;

public class RecipeIngredient
{
	public int Id { get; set; }

	public Ingredient? Ingredient { get; set; }

	public bool IsHeader { get; set; }

	public int Order { get; set; } = 1;

	public decimal? Quantity { get; set; }

	public Recipe Recipe { get; set; } = null!;

	public string? Text { get; set; }

	public Unit? Unit { get; set; }
}
