namespace PaddySe.Recipes.DataAccess.Entities;

public class Step
{
	public string? Description { get; set; }

	public int Id { get; set; }

	public bool IsHeader { get; set; }

	public string? Notes { get; set; }

	public int Order { get; set; } = 1;

	public Recipe Recipe { get; set; } = null!;
}
